using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Model.Entity.CodeGenerate
{
    [SugarTable("Codegenerate.GenerateType")]
    public class GenerateType
    {
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "GenerateTypeName")]
        public string GenerateTypeName { get; set; }
    }
}
