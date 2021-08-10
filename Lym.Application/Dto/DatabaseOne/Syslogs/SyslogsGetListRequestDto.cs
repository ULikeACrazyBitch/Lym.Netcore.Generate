using Lym.Application.DtoValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Application.Dto.DatabaseOne.Syslogs
{
    [DtoValidation]
    public class SyslogsGetListRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsTrue { get; set; }
    }
}
