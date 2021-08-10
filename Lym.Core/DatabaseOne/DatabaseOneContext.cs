using Lym.Common.Helpers;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lym.Model.Entity.Meiamsystem.Model;
using Lym.Core.Redis;

namespace Lym.Core.DatabaseOne
{
    public class DatabaseOneContext<T> : SimpleClient<T> where T : class, new()
    {
        public DatabaseOneContext(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {

            if (context == null)
            {
                //获取配置文件数据库配置信息
                var databaseConnection = AppSettings.GetDatabaseConnection("meiamsystem");
                //从库信息
                var slaveConnectionList = databaseConnection.SlaveConnectionStringList.Select(a => new SlaveConnectionConfig
                {
                    HitRate = a.HitRate,
                    ConnectionString = a.ConnectionString
                }).ToList();

                base.Context = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = databaseConnection.ConnectionString,
                    DbType = (DbType)databaseConnection.DbType,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute,
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        DataInfoCacheService = new RedisCache()
                    },
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true
                    },
                    //从库
                    SlaveConnectionConfigs = slaveConnectionList
                });
            }
        }
    } 
}
