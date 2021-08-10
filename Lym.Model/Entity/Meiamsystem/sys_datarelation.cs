using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///数据关系
    ///</summary>
    [SugarTable("sys_datarelation")]
    public partial class sys_datarelation
    {
           public sys_datarelation(){


           }
           /// <summary>
           /// Desc:UID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:来源ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Form {get;set;}

           /// <summary>
           /// Desc:对应ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string To {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Type {get;set;}

    }
}
