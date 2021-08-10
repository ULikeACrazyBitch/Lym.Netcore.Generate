using Lym.Model.Entity.Meiamsystem.Model;
using Lym.Respository.Interface.DatabaseOne;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Business.DatabaseOne.Syslogs
{
    /// <summary>
    /// 业务层：数据库DatabaseOne,表Syslogs
    /// </summary>
    public class SyslogsGetAllData
    {
        private readonly ISyslogsRespository _syslogsRespository;

        public SyslogsGetAllData(ISyslogsRespository syslogsRespository)
        {
            _syslogsRespository = syslogsRespository;
        }

        public List<sys_logs> GetAllData()
        {
            return _syslogsRespository.GetAll();
        }
    }
}
