using Lym.Business.CodeGenerate;
using Lym.Respository.Interface.CodeGenerate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.Mvc.Admin.Controllers
{
    public class ProjectCodeGenerateController : Controller
    {
        private readonly IFileProjectRepository _fileProjectRepository;
        private readonly IFileProjectTypeRepository _fileProjectTypeRepository;
        private readonly ProjectCodeBusiness _projectCodeBusiness;
        private readonly IDatabaseRepository _databaseRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectCodeGenerateController(IFileProjectRepository fileProjectRepository, IFileProjectTypeRepository fileProjectTypeRepository, ProjectCodeBusiness projectCodeBusiness, IDatabaseRepository databaseRepository, IWebHostEnvironment webHostEnvironment)
        {
            _fileProjectRepository = fileProjectRepository;
            _fileProjectTypeRepository = fileProjectTypeRepository;
            _projectCodeBusiness = projectCodeBusiness;
            _databaseRepository = databaseRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult List()
        {
            var fileProjects = _fileProjectRepository.GetAll();
            var fileProjecttypes = _fileProjectTypeRepository.GetAll();
            var databaseList = _projectCodeBusiness.GetConnectionDatabaseList();
            ViewBag.fileProjects = fileProjects;
            ViewBag.fileProjecttypes = fileProjecttypes;
            ViewBag.databaseList = databaseList;
            return View();
        }

        public IActionResult GetProjectList(int page, int limit, int projectId, int projectTypeId, string databaseIds)
        {
            if (projectId == 0 && projectTypeId == 0)
            {
                return Json(new
                {
                    code = 0,
                });
            }

            var databaseIdList = databaseIds.Split(",").Select(a => int.Parse(a)).ToList();
            var result = _projectCodeBusiness.GetProjectList(page, limit, projectId, projectTypeId, databaseIdList);
            return Json(new
            {
                code = 0,
                data = result
            });
        }
        /// <summary>
        /// 生成项目-返回压缩文件地址
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="databaseIds"></param>
        /// <returns></returns>
        public IActionResult Generate(int projectId, int projectTypeId, string databaseIds)
        {
            var savePath = Path.Combine(_webHostEnvironment.WebRootPath, "generate", "file", DateTime.Now.ToString("yyyyMMdd"));
            var zipPath = Path.Combine(_webHostEnvironment.WebRootPath, "generate", "zip");
            var databaseIdList = databaseIds.Split(",").Select(a => int.Parse(a)).ToList();
            var zipFilePath = _projectCodeBusiness.GenerateFile(projectId, projectTypeId, savePath, zipPath, databaseIdList);

            return Json(new
            {
                code = 0,
                msg = "生成成功",
                data = zipFilePath
            });
        }
        /// <summary>
        /// 生成解决方案-返回压缩文件地址
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="savePath"></param>
        /// <param name="slnname"></param>
        /// <param name="databaseIds"></param>
        /// <returns></returns>
        public IActionResult Generatesln(int projectId, int projectTypeId, string slnname, string databaseIds)
        {
            var savePath = Path.Combine(_webHostEnvironment.WebRootPath, "generate", "file", DateTime.Now.ToString("yyyyMMdd"));
            var zipPath = Path.Combine(_webHostEnvironment.WebRootPath, "generate", "zip");
            var databaseIdList = databaseIds.Split(",").Select(a => int.Parse(a)).ToList();
            var zipFilePath = _projectCodeBusiness.Generatesln(projectId, projectTypeId, savePath, zipPath, slnname, databaseIdList);

            return Json(new
            {
                code = 0,
                msg = "生成成功",
                data = zipFilePath
            });
        }

        public IActionResult DownloadZip(string zipFilePath)
        {
            FileStream fileStream = System.IO.File.OpenRead(zipFilePath);//打开压缩文件
            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            fileStream.Close();
            return File(buffer, "application/zip", Path.GetFileName(zipFilePath));
        }

    }
}
