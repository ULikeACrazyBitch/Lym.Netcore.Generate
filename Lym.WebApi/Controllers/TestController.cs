using Lym.Application.Dto.DatabaseOne.Syslogs;
using Lym.Business.DatabaseOne.Syslogs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.WebApi.Controllers
{ 
    [ApiController]
    [Route("/QiantoonService/[Controller]/[Action]")]
    public class TestController : BaseController
    {

        private readonly SyslogsGetAllData _syslogsGetAllData;

        public TestController(SyslogsGetAllData syslogsGetAllData)
        {
            _syslogsGetAllData = syslogsGetAllData;
        }

        [HttpPost]
        public IActionResult GetSyslogsAll([FromBody] SyslogsGetListRequestDto param)
        {
            return toResponse(_syslogsGetAllData.GetAllData()); 
        }
    }
}
