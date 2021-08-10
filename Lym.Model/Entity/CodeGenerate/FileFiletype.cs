using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Lym.Models.Entity.Codegenerate
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Codegenerate.file_filetype")]
    public class FileFiletype
    {
        /// <summary>
        /// 文件类型ID
        ///</summary>
         [SugarColumn(ColumnName="Id" ,IsPrimaryKey = true ,IsIdentity = true)]
         public int Id { get; set; }
        /// <summary>
        /// 文件类型名称
        ///</summary>
         [SugarColumn(ColumnName="FileTypeName"  )]
         public string FileTypeName { get; set; }
        /// <summary>
        /// 文件后缀名
        ///</summary>
         [SugarColumn(ColumnName="FileSuffix"  )]
         public string FileSuffix { get; set; }
    }
}
