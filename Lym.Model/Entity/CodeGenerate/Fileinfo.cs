using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.fileinfo")]
    public class Fileinfo
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
         [SugarColumn(ColumnName="Content"  )]
         public string Content { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Json"  )]
         public string Json { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="Suffix"  )]
         public string Suffix { get; set; }
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
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="IsInit"  )]
         public bool IsInit { get; set; }
    }
}
