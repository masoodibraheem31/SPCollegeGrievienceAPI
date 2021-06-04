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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpPost, Route("/api/v1/save-employee")]
        public async Task<IActionResult> SaveEmployee(EmployeeVMv1 employee)
        {
            var response = await this.service.SaveEmployee(employee);
            return Ok(response);
        }

        //[Authorize]
        [HttpGet, Route("/api/v1/get-employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var response = await this.service.GetEmployees();
            return Ok(response);
        }
    }
}
