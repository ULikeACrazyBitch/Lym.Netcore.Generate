using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.template")]
    public class Template
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Title"  )]
         public string Title { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="TemplateTypeId"  )]
         public int TemplateTypeId { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Content"  )]
         public string Content { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="TemplateTypeName"  )]
         public string TemplateTypeName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Sort"  )]
         public int Sort { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ChangeTime"  )]
         public DateTime ChangeTime { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsDeleted"  )]
         public bool IsDeleted { get; set; }
    }
}
