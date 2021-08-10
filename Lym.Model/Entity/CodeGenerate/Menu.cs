using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.menu")]
    public class Menu
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ParentId"  )]
         public int ParentId { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Icon"  )]
         public string Icon { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="MenuName"  )]
         public string MenuName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Url"  )]
         public string Url { get; set; }
    }
}
