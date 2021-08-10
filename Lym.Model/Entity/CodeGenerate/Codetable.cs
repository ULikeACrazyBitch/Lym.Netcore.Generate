using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.codetable")]
    public class Codetable
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DbId"  )]
         public int DbId { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="ClassName"  )]
         public string ClassName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="TableName"  )]
         public string TableName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Description"  )]
         public string Description { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"  )]
         public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="PreUpdateTime"  )]
         public DateTime PreUpdateTime { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="UpdateTime"  )]
         public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsDeleted"  )]
         public bool IsDeleted { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsLock"  )]
         public bool IsLock { get; set; }
    }
}
