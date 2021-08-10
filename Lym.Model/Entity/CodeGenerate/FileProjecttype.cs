using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.file_projecttype")]
    public class FileProjecttype
    {
        /// <summary>
        /// 项目类型Id
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 项目类型名称
        ///</summary>
         [SugarColumn(ColumnName="ProjectTypeName"  )]
         public string ProjectTypeName { get; set; }
        /// <summary>
        /// 
        ///</summary>
         [SugarColumn(ColumnName="FileProjectId"  )]
         public int FileProjectId { get; set; }
    }
}
