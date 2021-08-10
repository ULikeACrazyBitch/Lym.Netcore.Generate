using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///日志管理
    ///</summary>
    [SugarTable("sys_logs")]
    public partial class sys_logs
    {
           public sys_logs(){


           }
           /// <summary>
           /// Desc:ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:日志类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Logger {get;set;}

           /// <summary>
           /// Desc:日志等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Level {get;set;}

           /// <summary>
           /// Desc:日志来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Url {get;set;}

           /// <summary>
           /// Desc:主机地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Host {get;set;}

           /// <summary>
           /// Desc:请求方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Method {get;set;}

           /// <summary>
           /// Desc:浏览器标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserAgent {get;set;}

           /// <summary>
           /// Desc:Cookie
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Cookie {get;set;}

           /// <summary>
           /// Desc:URL参数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QueryString {get;set;}

           /// <summary>
           /// Desc:请求内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Body {get;set;}

           /// <summary>
           /// Desc:日志信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Message {get;set;}

           /// <summary>
           /// Desc:请求耗时
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Elapsed {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:用户来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IPAddress {get;set;}

    }
}
