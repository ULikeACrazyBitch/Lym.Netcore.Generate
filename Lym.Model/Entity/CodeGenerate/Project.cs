using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.project")]
    public class Project
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="TemplateId1"  )]
         public string TemplateId1 { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Path"  )]
         public string Path { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="FileInfo"  )]
         public string FileInfo { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="FileModel"  )]
         public string FileModel { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Sort"  )]
         public int Sort { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsDeleted"  )]
         public bool IsDeleted { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ModelId"  )]
         public int ModelId { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="FileSuffix"  )]
         public string FileSuffix { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ProjentName"  )]
         public string ProjentName { get; set; }
    }
}
