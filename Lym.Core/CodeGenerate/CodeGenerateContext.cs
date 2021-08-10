using Lym.Common.Helpers;
using Lym.Core.Redis;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lym.Core.CodeGenerate
{
    public class CodeGenerateContext<T> : SimpleClient<T> where T : class, new()
    {
        public CodeGenerateContext(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {

            if (context == null)
            {
                //获取配置文件数据库配置信息
                var databaseConnection = AppSettings.GetDatabaseConnection("codegenerate");
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

        public static SqlSugarClient GetInstance(DbType type, string connection)
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                DbType = type,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                ConnectionString = connection
            });
        }
    }
}
