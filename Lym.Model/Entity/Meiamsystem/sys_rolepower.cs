using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///角色权限
    ///</summary>
    [SugarTable("sys_rolepower")]
    public partial class sys_rolepower
    {
           public sys_rolepower(){


           }
           /// <summary>
           /// Desc:UUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoleUID {get;set;}

           /// <summary>
           /// Desc:权限ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PowerUID {get;set;}

    }
}
