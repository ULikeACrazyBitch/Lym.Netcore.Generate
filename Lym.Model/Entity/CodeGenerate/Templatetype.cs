using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.templatetype")]
    public class Templatetype
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
    }
}
