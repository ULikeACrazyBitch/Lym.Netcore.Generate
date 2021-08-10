using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lym.Common.Helpers
{
    public class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        static AppSettings()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
        /// <summary>
        /// 获得配置文件的对象值
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJson(string jsonPath, string key)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build(); //json文件地址
            string s = config.GetSection(key).Value; //json某个对象
            return s;
        }
        /// <summary>
        /// 获取配置文件数据库链接
        /// </summary>
        /// <param name="DbName">数据库名称</param>
        /// <returns></returns>
        public static DatabaseConnectionString GetDatabaseConnection(string DbName)
        {
            try
            {
                List<DatabaseConnectionString> databaseConnectionList = new List<DatabaseConnectionString>();
                Configuration.GetSection("DbConnection:dbList").Bind(databaseConnectionList);
                //var databaseConnectionList = JsonConvert.DeserializeObject<List<DatabaseConnectionString>>(Configuration.GetConnectionString("DbConnection"));
                var databaseConnection = databaseConnectionList.Where(a => a.Name == DbName).First();
                return databaseConnection;
            }
            catch (Exception)
            { 
                throw new Exception("appsettings.json 配置文件未能找到指定配置数据库信息");
            }  
        }
    }

    public class DatabaseConnectionString
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public int DbType { get; set; }
        public bool HasSlave { get; set; }

        public List<SlaveConnectionString> SlaveConnectionStringList { get; set; }
    }
    public class SlaveConnectionString
    {
        public int HitRate { get; set; }
        public string ConnectionString { get; set; }
    }
}
