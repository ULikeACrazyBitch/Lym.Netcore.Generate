using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.database")]
    public class Database
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Desc"  )]
         public string Desc { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Connection"  )]
         public string Connection { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DbType"  )]
         public DbType DbType { get; set; }
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
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="DatabaseName"  )]
         public string DatabaseName { get; set; }
    }
}
