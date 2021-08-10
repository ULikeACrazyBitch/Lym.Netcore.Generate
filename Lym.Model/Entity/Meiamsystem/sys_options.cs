using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lym.Model.Entity.Meiamsystem.Model
{
    ///<summary>
    ///选项框字典
    ///</summary>
    [SugarTable("sys_options")]
    public partial class sys_options
    {
           public sys_options(){


           }
           /// <summary>
           /// Desc:UUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ID {get;set;}

           /// <summary>
           /// Desc:分组（System_Menus_Status）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Option {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Label {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Value {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SortIndex {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CreateTime {get;set;}

           /// <summary>
           /// Desc:最后更新时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

           /// <summary>
           /// Desc:创建人编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CreateID {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CreateName {get;set;}

           /// <summary>
           /// Desc:更新人编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UpdateID {get;set;}

           /// <summary>
           /// Desc:更新人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UpdateName {get;set;}

    }
}
