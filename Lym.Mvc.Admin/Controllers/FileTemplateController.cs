using Lym.Business.CodeGenerate;
using Lym.Models.Entity.Codegenerate;
using Lym.Respository.Interface.CodeGenerate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.Mvc.Admin.Controllers
{
    public class FileTemplateController : Controller
    {
        private readonly FileTemplateBusiness _fileTemplateBusiness;
        private readonly IFileTemplateRepository _fileTemplateRepository;
        private readonly IFileProjectRepository _fileProjectRepository;
        private readonly IFileProjectTypeRepository _fileProjectTypeRepository;
        private readonly IFileFileTypeRepository _fileFileTypeRepository;
        private readonly IGenerateTypeRepository _generateTypeRepository;

        public FileTemplateController(FileTemplateBusiness fileTemplateBusiness, IFileTemplateRepository fileTemplateRepository, IFileProjectRepository fileProjectRepository, IFileProjectTypeRepository fileProjectTypeRepository, IFileFileTypeRepository fileFileTypeRepository, IGenerateTypeRepository generateTypeRepository)
        {
            _fileTemplateBusiness = fileTemplateBusiness;
            _fileTemplateRepository = fileTemplateRepository;
            _fileProjectRepository = fileProjectRepository;
            _fileProjectTypeRepository = fileProjectTypeRepository;
            _fileFileTypeRepository = fileFileTypeRepository;
            _generateTypeRepository = generateTypeRepository;
        }
        public IActionResult List()
        {
            var fileProjects = _fileProjectRepository.GetAll();
            var fileProjecttypes = _fileProjectTypeRepository.GetAll();
            ViewBag.fileProjects = fileProjects;
            ViewBag.fileProjecttypes = fileProjecttypes;
            return View();
        }

        public IActionResult GetProjectList(int page, int limit, int projectId, int projectTypeId)
        {
            var result = _fileTemplateBusiness.GetDatabasePageList(page, limit, projectId, projectTypeId);
            return Json(result);

        }

        public IActionResult Add()
        {
            var fileProjects = _fileProjectRepository.GetAll();
            var fileProjecttypes = _fileProjectTypeRepository.GetAll();
            var fileFiletypes = _fileFileTypeRepository.GetAll();
            var fileTemplates = _fileTemplateRepository.GetWhere(a => a.FileTypeId == 2);//文件夹
            var generateTypes = _generateTypeRepository.GetAll();
            ViewBag.fileProjects = fileProjects;
            ViewBag.fileProjecttypes = fileProjecttypes;
            ViewBag.fileFiletypes = fileFiletypes;
            ViewBag.fileTemplates = fileTemplates;
            ViewBag.generateTypes = generateTypes;
            return View();
        }

        public IActionResult Save(FileTemplate project)
        {
            if (project.Id == 0)
            {
                project.ProjectName = _fileProjectRepository.GetById(project.ProjectId).ProjectName;
                project.ProjectType = _fileProjectTypeRepository.GetById(project.ProjectTypeId).ProjectTypeName;
                project.FileType = _fileFileTypeRepository.GetById(project.FileTypeId).FileTypeName;
                project.UpperlevelDirectoryName = project.UpperlevelDirectoryId > 0 ? _fileTemplateRepository.GetById(project.UpperlevelDirectoryId).FileName : "";
                project.IsDeleted = false;
                _fileTemplateRepository.Add(project);
            }
            else
            {
                project.ProjectName = _fileProjectRepository.GetById(project.ProjectId).ProjectName;
                project.ProjectType = _fileProjectTypeRepository.GetById(project.ProjectTypeId).ProjectTypeName;
                project.FileType = _fileFileTypeRepository.GetById(project.FileTypeId).FileTypeName;
                project.UpperlevelDirectoryName = project.UpperlevelDirectoryId > 0 ? _fileTemplateRepository.GetById(project.UpperlevelDirectoryId).FileName : "";
                _fileTemplateRepository.Update(project);
            }

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }

        public IActionResult Edit(int id)
        {
            var fileProjects = _fileProjectRepository.GetAll();
            var fileProjecttypes = _fileProjectTypeRepository.GetAll();
            var fileFiletypes = _fileFileTypeRepository.GetAll();
            var fileTemplates = _fileTemplateRepository.GetWhere(a => a.FileTypeId == 2);//文件夹
            var generateTypes = _generateTypeRepository.GetAll();
            ViewBag.fileProjects = fileProjects;
            ViewBag.fileProjecttypes = fileProjecttypes;
            ViewBag.fileFiletypes = fileFiletypes;
            ViewBag.fileTemplates = fileTemplates;
            ViewBag.generateTypes = generateTypes;

            var fileTemplate = _fileTemplateRepository.GetId(id);
            ViewBag.fileTemplate = fileTemplate;
            return View();
        }

        public IActionResult Del(int id)
        {
            _fileTemplateRepository.Delete(id);

            return Json(new
            {
                code = 0,
                msg = "成功"
            });
        }
        /// <summary>
        /// 获取项目类型下拉数据
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IActionResult GetProjectTypeSelect(int projectId)
        {
            var fileProjecttypeList = _fileProjectTypeRepository.GetWhere(a => a.FileProjectId == projectId);
            return Json(new
            {
                code = 0,
                msg = "成功",
                data = fileProjecttypeList
            });
        }
        /// <summary>
        /// 获取上级牡蛎
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectTypeId"></param>
        /// <returns></returns>
        public IActionResult GetUpperlevelDirectory(int projectId, int projectTypeId)
        {
            var fileTemplateList = _fileTemplateRepository.GetWhere(a => a.ProjectId == projectId && a.ProjectTypeId == projectTypeId);

            return Json(new
            {
                code = 0,
                msg = "成功",
                data = fileTemplateList
            });
        }
    }
}
