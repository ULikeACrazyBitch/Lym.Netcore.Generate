using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using System;
using System.Collections.Generic;
using System.Text;
using Lym.BaseRespository.Extensions;
namespace Lym.Business.CodeGenerate
{
    public class FileProjectTypeBusiness
    {
        private readonly IFileProjectTypeRepository _fileProjectTypeRepository;
        public FileProjectTypeBusiness(IFileProjectTypeRepository fileProjectTypeRepository)
        {
            _fileProjectTypeRepository = fileProjectTypeRepository;
        }

        public DTReturnData GetDatabasePageList(int pageIndex, int pageSize, int projectId, string projectTypeName)
        {
            DTReturnData dTReturnData = new Model.ApiResult.DTReturnData();
            PageParm pageParm = new PageParm();
            pageParm.PageIndex = pageIndex;
            pageParm.PageSize = pageSize;
            PagedInfo<FileProjecttype> databaseList = _fileProjectTypeRepository.AsQueryable()
                 .WhereIF(!string.IsNullOrEmpty(projectTypeName), a => a.ProjectTypeName.Contains(projectTypeName))
                 .WhereIF(projectId > 0, a => a.FileProjectId == projectId)
                 .ToPage(pageParm);

            dTReturnData.code = 0;
            dTReturnData.count = databaseList.TotalCount;
            dTReturnData.data = databaseList.DataSource;
            dTReturnData.msg = "成功";

            return dTReturnData;
        }
    }
}
