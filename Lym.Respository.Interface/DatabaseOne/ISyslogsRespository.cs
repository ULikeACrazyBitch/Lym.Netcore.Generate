using Lym.BaseRespository;
using Lym.Model.Entity.Meiamsystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Respository.Interface.DatabaseOne
{
    /// <summary>
    /// sys_logs表仓储接口
    /// </summary>
    public interface ISyslogsRespository : IBaseRespository<sys_logs>
    {
        #region 在此拓展接口

        void Test();

        #endregion
    }
}
