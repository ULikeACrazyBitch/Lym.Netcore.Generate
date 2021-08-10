using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using System;
using System.Collections.Generic;
using System.Text;
using Lym.BaseRespository.Extensions;
using Lym.Respository.Service.CodeGenerate;

namespace Lym.Business.CodeGenerate
{
    public class FileTemplateBusiness
    {
        private readonly IFileTemplateRepository _fileTemplateRepository;
        public FileTemplateBusiness(IFileTemplateRepository fileTemplateRepository)
        {
            _fileTemplateRepository = fileTemplateRepository;
        }

        public DTReturnData GetDatabasePageList(int pageIndex, int pageSize, int projectId, int projectTypeId)
        {
            DTReturnData dTReturnData = new Model.ApiResult.DTReturnData();
            PageParm pageParm = new PageParm();
            pageParm.PageIndex = pageIndex;
            pageParm.PageSize = pageSize;
            PagedInfo<FileTemplate> databaseList = _fileTemplateRepository.AsQueryable()
                 .WhereIF(projectTypeId > 0, a => a.ProjectTypeId == projectTypeId)
                 .WhereIF(projectId > 0, a => a.ProjectId == projectId)
                 .Select(a => new FileTemplate
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
                     UpperlevelDirectoryName = a.UpperlevelDirectoryName
                 })
                 .ToPage(pageParm);

            dTReturnData.code = 0;
            dTReturnData.count = databaseList.TotalCount;
            dTReturnData.data = databaseList.DataSource;
            dTReturnData.msg = "成功";

            return dTReturnData;
        }
    }
}
