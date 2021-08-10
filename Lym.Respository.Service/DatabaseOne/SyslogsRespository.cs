using Lym.BaseRespository.DatabaseOne;
using Lym.Model.Entity.Meiamsystem.Model;
using Lym.Respository.Interface.DatabaseOne;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Respository.Service.DatabaseOne
{
    /// <summary>
    /// sys_logs表仓储接口实现
    /// </summary>
    public class SyslogsRespository : BaseCodeGenerateRespository<sys_logs>, ISyslogsRespository
    {
        #region 在实现自定义拓展接口

        public void Test()
        {
            Console.WriteLine("SyslogsRespository  Test 111111111111111111");
        }
        #endregion
    }
}
