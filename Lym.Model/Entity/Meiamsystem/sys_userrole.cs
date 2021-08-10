using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///用户角色
    ///</summary>
    [SugarTable("sys_userrole")]
    public partial class sys_userrole
    {
           public sys_userrole(){


           }
           /// <summary>
           /// Desc:UUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoleID {get;set;}

    }
}
