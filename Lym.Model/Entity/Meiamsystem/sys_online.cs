using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///在线用户
    ///</summary>
    [SugarTable("sys_online")]
    public partial class sys_online
    {
           public sys_online(){


           }
           /// <summary>
           /// Desc:用户
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:会话
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string SessionID {get;set;}

           /// <summary>
           /// Desc:IP地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IPAddress {get;set;}

           /// <summary>
           /// Desc:登录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LoginTime {get;set;}

           /// <summary>
           /// Desc:最后操作时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateTime {get;set;}

           /// <summary>
           /// Desc:来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Source {get;set;}

    }
}
