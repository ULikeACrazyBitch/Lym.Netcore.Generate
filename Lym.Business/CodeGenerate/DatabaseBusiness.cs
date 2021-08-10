using Lym.Model.ApiResult;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Business.CodeGenerate
{
    public class DatabaseBusiness
    {
        private readonly IDatabaseRepository _databaseRespository;
        public DatabaseBusiness(IDatabaseRepository databaseRespository)
        {
            _databaseRespository = databaseRespository;
        }

        public DTReturnData GetDatabasePageList(string databasename)
        { 
            DTReturnData dTReturnData = new Model.ApiResult.DTReturnData(); 
            PageParm pageParm = new PageParm();
            PagedInfo<Database> databaseList = new PagedInfo<Database>();
            if (string.IsNullOrEmpty(databasename))
            {
                databaseList = _databaseRespository.GetPages(a => true, pageParm);
            }
            else
            {
                databaseList = _databaseRespository.GetPages(a => a.DatabaseName.Contains(databasename), pageParm);
            }


            dTReturnData.code = 0;
            dTReturnData.count = databaseList.TotalCount;
            dTReturnData.data = databaseList.DataSource;
            dTReturnData.msg = "成功";

            return dTReturnData;
        }
    }
}
