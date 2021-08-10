using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///用户权限
    ///</summary>
    [SugarTable("sys_userrelation")]
    public partial class sys_userrelation
    {
           public sys_userrelation(){


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
           /// Desc:数据权限ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ObjectID {get;set;}

           /// <summary>
           /// Desc:数据权限类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ObjectType {get;set;}

    }
}
