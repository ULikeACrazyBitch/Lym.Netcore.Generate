using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.codetype")]
    public class Codetype
    {
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Name"  )]
         public string Name { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="CSharepType"  )]
         public string CSharepType { get; set; }
        /// <summary>
        /// 
        ///</summary>

        [SugarColumn(ColumnDataType = "text", IsJson = true)]
        public DbTypeInfo[] DbType { get; set; }
        /// <summary>
        /// 
        ///</summary>
        [SugarColumn(ColumnName="Sort"  )]
         public int Sort { get; set; }
    }

    public class DbTypeInfo
    {
        public string Name { get; set; }
        public int? Length { get; set; }
        public int? DecimalDigits { get; set; }
    }
}
