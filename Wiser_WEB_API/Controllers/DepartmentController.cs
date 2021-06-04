using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiser.API.BL.I_Services;
using Wiser.API.Entities.Models;
using Wiser.API.Entities.ViewModels;

namespace Wiser_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [Authorize]
        [HttpPost, Route("/api/v1/save-department")]
        public async Task<IActionResult> SaveDepartment(DepartmentVM department)
        {
            var response = await this.departmentService.SaveDepartment(department);
            return Ok(response);
        }

        //[Authorize]
        [HttpGet, Route("/api/v1/get-departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await this.departmentService.GetDepartments();
            return Ok(response);
        }

        //[Authorize]
        [HttpPost, Route("/api/v1/delete-department")]
        public async Task<IActionResult> DeleteDepartment(Guid Id)
        {
            var response = await this.departmentService.DeleteDepartment(Id);
            return Ok(response);
        }
    }
}
