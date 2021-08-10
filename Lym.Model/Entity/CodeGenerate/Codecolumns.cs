using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.codecolumns")]
    public class Codecolumns
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClassProperName"  )]
         public string ClassProperName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DbColumnName"  )]
         public string DbColumnName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Required"  )]
         public bool Required { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsIdentity"  )]
         public bool IsIdentity { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsPrimaryKey"  )]
         public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Description"  )]
         public string Description { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="CodeType"  )]
         public string CodeType { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="CodeTableId"  )]
         public int CodeTableId { get; set; }
    }
}
