using Lym.BaseRespository.Extensions;
using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Lym.Common.Helpers;
using Newtonsoft.Json;
using Lym.Application.Dto.Generate;
using Lym.Common.Tools;
using SqlSugar;
using System.IO.Compression;

namespace Lym.Business.CodeGenerate
{
    public class ProjectCodeBusiness
    {
        private List<Database> m_connectionDatabaseList = new List<Database>();
        private List<FileTemplateDto> m_fileTemplates = new List<FileTemplateDto>();
        //
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IFileTemplateRepository _fileTemplateRepository;
        private readonly IGenerateTypeRepository _generateTypeRepository;
        private readonly ICodetypeRepository _codetypeRepository;
        private readonly IFileProjectTypeRepository _fileProjectTypeRepository;
        public ProjectCodeBusiness(IDatabaseRepository databaseRepository, IFileTemplateRepository fileTemplateRepository, IGenerateTypeRepository generateTypeRepository, ICodetypeRepository codetypeRepository, IFileProjectTypeRepository fileProjectTypeRepository)
        {
            _databaseRepository = databaseRepository;
            _fileTemplateRepository = fileTemplateRepository;
            _generateTypeRepository = generateTypeRepository;
            _codetypeRepository = codetypeRepository;
            _fileProjectTypeRepository = fileProjectTypeRepository;
        }

        public List<FileTemplateDto> GetProjectList(int page, int limit, int projectId, int projectTypeId, List<int> databaseIds)
        {
            return GetFileTemplateListData(projectId, projectTypeId, databaseIds);
        }
        /// <summary>
        /// 生成sln解决方案
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="savePath"></param>
        /// <param name="slnname"></param>
        /// <param name="databaseIdList"></param>
        public string Generatesln(int projectId, int projectTypeId, string savePath, string zipPath, string slnname, List<int> databaseIdList)
        {
            List<string> cmdcommandList = new List<string>();
            //
            string slncommand = $"dotnet new sln -n {slnname}";
            cmdcommandList.Add(slncommand);
            slnname = slnname.Contains(".sln") ? slnname : slnname + ".sln";
            //
            if (projectTypeId == 0)
            {
                var fileProjecttypes = getFileTemplateDto(projectId, projectTypeId);// _fileProjectTypeRepository.GetWhere(a => a.FileProjectId == projectId);
                foreach (var item in fileProjecttypes)
                {
                    var path = Path.Combine(savePath, (item.ProjectName + "." + item.ProjectTypeName), (item.ProjectName + "." + item.ProjectTypeName) + ".csproj");
                    string projectCommand = $"dotnet sln {slnname} add  {path}";
                    cmdcommandList.Add(projectCommand);
                }
            }
            else
            {
                var fileProjecttype = getFileTemplateDto(projectId, projectTypeId).First();
                var path = Path.Combine(savePath, (fileProjecttype.ProjectName + "." + fileProjecttype.ProjectTypeName), (fileProjecttype.ProjectName + "." + fileProjecttype.ProjectTypeName) + ".csproj");

                string projectCommand = $"dotnet sln {slnname} add  {path}";
                cmdcommandList.Add(projectCommand);

            }
            //生成
            foreach (var item in cmdcommandList)
            {
                //Task<Action> f = Action.CreateDelegate();
                var result = WinCmdHelper.ExcuteDosCommand(item, true, false, savePath);
            }
            //保存到zip压缩文件
            var zipFilePath = SaveFileToZip(savePath, zipPath);

            return zipFilePath; 
        }

        public List<ProjectTypeDto> getFileTemplateDto(int projectId , int projectTypeId)
        {
            List<ProjectTypeDto> fileTemplateList = _fileProjectTypeRepository.AsSugarClient().Queryable<FileProjecttype, FileProject>((a,b)=>a.FileProjectId == b.Id)
                
               .WhereIF(projectTypeId > 0, (a,b) => a.Id == projectTypeId)
               .WhereIF(projectId > 0, (a,b) => a.FileProjectId == projectId)
               .Select((a,b) => new ProjectTypeDto
               {
                  ProjectId =b.Id,
                  ProjectName = b.ProjectName,
                  ProjectTypeId = a.Id,
                  ProjectTypeName =a.ProjectTypeName

               }).ToList();

            return fileTemplateList;
        }
        /// <summary>
        /// 生成项目文件
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectTypeId"></param>
        public string GenerateFile(int projectId, int projectTypeId, string savePath, string zipPath, List<int> databaseIds)
        {
            var fileTemplateList = GetFileTemplateListData(projectId, projectTypeId, databaseIds);
            var codetypeList = _codetypeRepository.GetAll();
            //保存文件
            foreach (var fileTemplate in fileTemplateList)
            {
                var path = Path.Combine(savePath, fileTemplate.FileName);
                //文件夹
                if (fileTemplate.FileTypeId == 2)
                {
                    FileHelper.CreateDirectory(path);
                }
                else
                {
                    if (FileHelper.IsExistFile(path))
                    {
                        FileHelper.DeleteFile(path);
                    }
                    //模版替换：模型
                    GenerateDto generateDto = new GenerateDto();
                    generateDto.ProjectName = fileTemplate.ProjectName;
                    generateDto.ClassName = fileTemplate.ClassName;
                    generateDto.DatabaseName = fileTemplate.DatabaseName;
                    generateDto.NameSpace = Path.GetDirectoryName(fileTemplate.FileName).Replace("\\", ".");
                    generateDto.ProjectType = fileTemplate.ProjectType;
                    generateDto.TableName = fileTemplate.TableName;
                    generateDto.DatabaseFileName = fileTemplate.DatabaseFileName;
                    generateDto.PropertyGenList = new List<PropertyGens>();
                    //
                    if (!string.IsNullOrEmpty(generateDto.TableName))
                    {
                        var database = _databaseRepository.GetWhere(a => a.DatabaseName.ToLower() == generateDto.DatabaseName.ToLower()).First();
                        var db = GetTryDb(database);
                        foreach (var columnInfo in db.DbMaintenance.GetColumnInfosByTableName(generateDto.TableName))
                        {
                            PropertyGens column = new PropertyGens()
                            {
                                ClassProperName = HumpNameHelper.ToHumpName(columnInfo.DbColumnName),
                                DbColumnName = columnInfo.DbColumnName,
                                Description = columnInfo.ColumnDescription,
                                IsIdentity = columnInfo.IsIdentity,
                                IsPrimaryKey = columnInfo.IsPrimarykey,
                                Required = columnInfo.IsNullable == false,
                                //CodeTableId = entity.Id,
                                Type = GetEntityType(codetypeList, columnInfo)
                            };
                            generateDto.PropertyGenList.Add(column);
                        }
                        var s = JsonConvert.SerializeObject(generateDto);
                    } 
                    //
                    string key = TemplateHelper.EntityKey + fileTemplate.GetHashCode();
                    var content = TemplateHelper.GetTemplateValue(key, fileTemplate.Content, generateDto);
                    FileHelper.CreateFile(path, content, Encoding.UTF8);
                }
            }
            //保存到zip压缩文件
            var zipFilePath = SaveFileToZip(savePath, zipPath);

            return zipFilePath;
        }


        public string SaveFileToZip(string savePath, string zipPath)
        {
            FileHelper.CreateDirectory(zipPath);
            var zipFiltPath = Path.Combine(zipPath, DateTime.Now.Ticks.ToString() + ".zip");
            ZipFile.CreateFromDirectory(savePath, zipFiltPath);
            return zipFiltPath;
        }
        public List<FileTemplateDto> GetFileTemplateListData(int projectId, int projectTypeId, List<int> databaseIds)
        {
            //获取可用数据库链接
            m_connectionDatabaseList = GetConnectionDatabaseList(databaseIds);
            //
            List<FileTemplateDto> fileTemplateList = _fileTemplateRepository.AsQueryable()
            .WhereIF(projectTypeId > 0, a => a.ProjectTypeId == projectTypeId)
            .WhereIF(projectId > 0, a => a.ProjectId == projectId)
            .Select(a => new FileTemplateDto
            {
                Content = a.Content,
                FileName = a.FileName,
                FileType = a.FileType,
                FileTypeId = a.FileTypeId,
                Id = a.Id,
                IsDeleted = a.IsDeleted,
                ProjectId = a.ProjectId,
                ProjectName = a.ProjectName,
                ProjectType = a.ProjectType,
                ProjectTypeId = a.ProjectTypeId,
                UpperlevelDirectoryId = a.UpperlevelDirectoryId,
                UpperlevelDirectoryName = a.UpperlevelDirectoryName,
                GenerateTypeId = a.GenerateTypeId
               }).ToList();

                    fileTemplateList = GetFullPathTemplate(fileTemplateList);

            return fileTemplateList;
        }
        /// <summary>
        /// 获取文件 完整文件名称
        /// </summary>
        /// <param name="fileTemplateList"></param>
        /// <returns></returns>
        private List<FileTemplateDto> GetFullPathTemplate(List<FileTemplateDto> fileTemplateList)
        {

            //根据判断条件循环生成文件
            List<FileTemplateDto> addFileTemplateList = new List<FileTemplateDto>();
            List<FileTemplateDto> deleteFileTemplateList = new List<FileTemplateDto>();
            foreach (var item in fileTemplateList)
            {
                item.FileName = ReplaceProjectFileNmae(item.FileName, item.ProjectName);
                //项目
                if (item.GenerateTypeId == 1)
                {

                }
                //数据库
                else if (item.GenerateTypeId == 2 && item.FileName.Contains("@(Model.DatabaseName)"))
                {
                    deleteFileTemplateList.Add(item);
                    foreach (var database in m_connectionDatabaseList)
                    {
                        var databaseFileTemplate = new FileTemplateDto
                        {
                            Content = item.Content,
                            FileName = HumpNameHelper.ToHumpName(database.DatabaseName),
                            FileType = item.FileType,
                            FileTypeId = item.FileTypeId,
                            Id = item.Id,
                            IsDeleted = item.IsDeleted,
                            ProjectId = item.ProjectId,
                            ProjectName = item.ProjectName,
                            ProjectType = item.ProjectType,
                            ProjectTypeId = item.ProjectTypeId,
                            UpperlevelDirectoryId = item.UpperlevelDirectoryId,
                            UpperlevelDirectoryName = item.UpperlevelDirectoryName,
                            GenerateTypeId = item.GenerateTypeId,
                            DatabaseName = database.DatabaseName,
                            DatabaseFileName = HumpNameHelper.ToHumpName(database.DatabaseName)
                        };
                        addFileTemplateList.Add(databaseFileTemplate);
                    }
                }
                //模型
                else if (item.GenerateTypeId == 3 && item.FileName.Contains("@(Model.TableName)"))
                {
                    if (addFileTemplateList.Where(a => a.Id == item.UpperlevelDirectoryId && a.GenerateTypeId == 2).Any())
                    {
                        var upperlevelDirectoryFileTemplateList = addFileTemplateList.Where(a => a.Id == item.UpperlevelDirectoryId && a.GenerateTypeId == 2).ToList();
                        foreach (var upperlevelDirectoryFileTemplate in upperlevelDirectoryFileTemplateList)
                        {

                            //获取对应数据库的表信息 
                            if (m_connectionDatabaseList.Where(a => a.DatabaseName == upperlevelDirectoryFileTemplate.DatabaseName).Any())
                            {
                                var connectionDatabase = m_connectionDatabaseList.Where(a => a.DatabaseName == upperlevelDirectoryFileTemplate.DatabaseName).First();
                                var dbTableInfos = GetTryDb(connectionDatabase).DbMaintenance.GetTableInfoList();
                                foreach (var dbTableInfo in dbTableInfos)
                                {
                                    var tableFileTemplate = new FileTemplateDto
                                    {
                                        Content = item.Content,
                                        FileName = ReplaceTableFileNmae(item.FileName, HumpNameHelper.ToHumpName(dbTableInfo.Name)),
                                        FileType = item.FileType,
                                        FileTypeId = item.FileTypeId,
                                        Id = item.Id,
                                        IsDeleted = item.IsDeleted,
                                        ProjectId = item.ProjectId,
                                        ProjectName = item.ProjectName,
                                        ProjectType = item.ProjectType,
                                        ProjectTypeId = item.ProjectTypeId,
                                        UpperlevelDirectoryId = item.UpperlevelDirectoryId,
                                        UpperlevelDirectoryName = HumpNameHelper.ToHumpName(connectionDatabase.DatabaseName),
                                        GenerateTypeId = item.GenerateTypeId,
                                        DatabaseName = connectionDatabase.DatabaseName,
                                        TableName = dbTableInfo.Name,
                                        ClassName = HumpNameHelper.ToHumpName(dbTableInfo.Name),
                                        Description = dbTableInfo.Description,
                                        DatabaseFileName = HumpNameHelper.ToHumpName(connectionDatabase.DatabaseName)
                                    };
                                    addFileTemplateList.Add(tableFileTemplate);
                                }
                            }
                        }
                        //删除
                        deleteFileTemplateList.Add(item);
                    }
                }
                else
                {
                    //根据数据库循环生成+升级目录ID>0
                    if (item.FileName.Contains("@(Model.DatabaseName)") && item.UpperlevelDirectoryId > 0)
                    {
                        if (addFileTemplateList.Where(a => a.Id == item.UpperlevelDirectoryId && a.GenerateTypeId == 2).Any())
                        {
                            var upperlevelDirectoryFileTemplateList = addFileTemplateList.Where(a => a.Id == item.UpperlevelDirectoryId && a.GenerateTypeId == 2).ToList();
                            foreach (var upperlevelDirectoryFileTemplate in upperlevelDirectoryFileTemplateList)
                            {
                                var databaseFileTemplate = new FileTemplateDto
                                {
                                    Content = item.Content,
                                    FileName = HumpNameHelper.ToHumpName(ReplaceDatabaseFileNmae(item.FileName, upperlevelDirectoryFileTemplate.FileName)),
                                    FileType = item.FileType,
                                    FileTypeId = item.FileTypeId,
                                    Id = item.Id,
                                    IsDeleted = item.IsDeleted,
                                    ProjectId = item.ProjectId,
                                    ProjectName = item.ProjectName,
                                    ProjectType = item.ProjectType,
                                    ProjectTypeId = item.ProjectTypeId,
                                    UpperlevelDirectoryId = item.UpperlevelDirectoryId,
                                    UpperlevelDirectoryName = upperlevelDirectoryFileTemplate.FileName,
                                    GenerateTypeId = item.GenerateTypeId,
                                    DatabaseName = upperlevelDirectoryFileTemplate.FileName,
                                    DatabaseFileName = HumpNameHelper.ToHumpName(upperlevelDirectoryFileTemplate.FileName)
                                };
                                addFileTemplateList.Add(databaseFileTemplate);
                            }
                            //删除
                            deleteFileTemplateList.Add(item);
                        }
                    }
                }
            }
            //添加
            fileTemplateList.AddRange(addFileTemplateList);
            //删除
            foreach (var item in deleteFileTemplateList)
            {
                fileTemplateList.Remove(item);
            }

            //深度克隆数组
            m_fileTemplates = JsonConvert.DeserializeObject<List<FileTemplateDto>>(JsonConvert.SerializeObject(fileTemplateList));
            //重新 组装新显示内容
            foreach (var item in fileTemplateList.OrderBy(a => a.UpperlevelDirectoryId))
            {
                item.FileName = GetFileFullPath(fileTemplateList, item, item.UpperlevelDirectoryId);
            }
            return fileTemplateList;
        }

        private string GetFileFullPath(List<FileTemplateDto> fileTemplateList, FileTemplateDto currentFileTemplate, int upperlevelDirectoryId)
        {
            var json = JsonConvert.SerializeObject(fileTemplateList);
            if (upperlevelDirectoryId > 0)
            {
                FileTemplateDto upperlevelDirectoryFileTemplate = null;
                if (m_fileTemplates.Where(a => a.Id == upperlevelDirectoryId).Count() > 1)
                {
                    upperlevelDirectoryFileTemplate = m_fileTemplates.Where(a => a.Id == upperlevelDirectoryId && a.FileName == currentFileTemplate.UpperlevelDirectoryName).First();
                }
                else
                {
                    upperlevelDirectoryFileTemplate = m_fileTemplates.Where(a => a.Id == upperlevelDirectoryId).First();
                }
                currentFileTemplate.FileName = Path.Combine(upperlevelDirectoryFileTemplate.FileName, currentFileTemplate.FileName);
                GetFileFullPath(fileTemplateList, currentFileTemplate, upperlevelDirectoryFileTemplate.UpperlevelDirectoryId);
            }
            else
            {
                currentFileTemplate.FileName = $"{currentFileTemplate.ProjectName}.{currentFileTemplate.FileName}";
            }
            return currentFileTemplate.FileName;
        }
        /// <summary>
        /// 替换文件名中包含@(Model.DatabaseName)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private string ReplaceDatabaseFileNmae(string fileName, string databaseName)
        {
            if (fileName.Contains("@(Model.DatabaseName)"))
            {
                return fileName.Replace("@(Model.DatabaseName)", databaseName);
            }
            return fileName;
        }

        public string ReplaceTableFileNmae(string fileName, string tableName)
        {
            if (fileName.Contains("@(Model.TableName)"))
            {
                return fileName.Replace("@(Model.TableName)", tableName);
            }
            return fileName;
        }
        public string ReplaceProjectFileNmae(string fileName, string projectName)
        {
            if (fileName.Contains("@(Model.ProjectName)"))
            {
                return fileName.Replace("@(Model.ProjectName)", projectName);
            }
            return fileName;
        }
        /// <summary>
        /// 获取可连接的database数据库
        /// </summary>
        public List<Database> GetConnectionDatabaseList(List<int> dabataseIds)
        {
            List<Database> databases = new List<Database>();
            var databasesd = _databaseRepository.GetWhere(a => a.IsDeleted == false && !string.IsNullOrEmpty(a.Connection) && dabataseIds.Contains(a.Id));
            foreach (var database in databasesd)
            {
                if (IsConnectionDb(database))
                {
                    databases.Add(database);
                }
            }
            return databases;
        }
        public List<Database> GetConnectionDatabaseList()
        {
            List<Database> databases = new List<Database>();
            var databasesd = _databaseRepository.GetWhere(a => a.IsDeleted == false && !string.IsNullOrEmpty(a.Connection));
            foreach (var database in databasesd)
            {
                if (IsConnectionDb(database))
                {
                    databases.Add(database);
                }
            }
            return databases;
        }

        protected SqlSugarClient GetTryDb(Database db)
        {
            try
            {
                using (var Db = _databaseRepository.GetInstance(db.DbType, db.Connection))
                {
                    Db.Open();
                    return Db;
                }
            }
            catch
            {

                throw new Exception(db.Connection + " " + db.DbType + "无法连接到数据库，请认真检查DbType和连接字符串");
            }
        }
        private bool IsConnectionDb(Database db)
        {
            try
            {
                using (var Db = _databaseRepository.GetInstance(db.DbType, db.Connection))
                {
                    Db.Ado.CommandTimeOut = 1;
                    Db.Open();
                    Db.DbMaintenance.CreateDatabase();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetNameSpace(string fileName)
        {
            return Path.GetDirectoryName(fileName);
        }

        private string GetEntityType(List<Codetype> types, DbColumnInfo columnInfo)
        {
            var typeInfo = types.FirstOrDefault(y => y.DbType.Any(it => it.Name.Equals(columnInfo.DataType, StringComparison.OrdinalIgnoreCase)));
            if (typeInfo == null)
            {
                return "string";
            }
            else
            {
                return typeInfo.CSharepType;
            }
        }
    }

}
