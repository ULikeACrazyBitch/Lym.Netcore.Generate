using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Business.CodeGenerate
{
    public class FileProjectBusiness
    {
        private readonly IFileProjectRepository _projectRespository;
        public FileProjectBusiness(IFileProjectRepository  projectRespository)
        {
            _projectRespository = projectRespository;
        }

        public DTReturnData GetDatabasePageList(string databasename)
        {
            DTReturnData dTReturnData = new Model.ApiResult.DTReturnData();

            PageParm pageParm = new PageParm();
            PagedInfo<FileProject> databaseList = new PagedInfo<FileProject>();
            if (string.IsNullOrEmpty(databasename))
            {
                databaseList = _projectRespository.GetPages(a => true, pageParm);
            }
            else
            {
                databaseList = _projectRespository.GetPages(a => a.ProjectName.Contains(databasename), pageParm);
            }


            dTReturnData.code = 0;
            dTReturnData.count = databaseList.TotalCount;
            dTReturnData.data = databaseList.DataSource;
            dTReturnData.msg = "成功";

            return dTReturnData;
        }
    }
}
