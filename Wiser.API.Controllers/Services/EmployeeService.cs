using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wiser.API.BL.Config;
using Wiser.API.BL.I_Services;
using Wiser.API.Entities;
using Wiser.API.Entities.Models;
using Wiser.API.Entities.ViewModels;

namespace Wiser.API.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WiserContext wiserContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public EmployeeService(WiserContext wiserContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.wiserContext = wiserContext;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
        public Task<Response<bool>> DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<EmployeeVM>>> GetEmployees()
        {
            var data = await this.wiserContext.Employees.Include(x => x.Department).ToListAsync();
            if (data.Any())
            {
                var dataVms=mapper.Map<List<EmployeeVM>>(data);
                return new Response<List<EmployeeVM>>()
                {
                    Message = "Employee data found",
                    Count = data.Count,
                    Data = dataVms,
                    Success = true
                };
            }
            else
            {
                return new Response<List<EmployeeVM>>()
                {
                    Message = "Employee data not found",
                    Success = true
                };
            }
        }

        public async Task<Response<EmployeeVMv1>> SaveEmployee(EmployeeVMv1 employee)
        {
            var id = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Response<EmployeeVMv1> response = new Response<EmployeeVMv1>() { Success = true };
            if (employee.Id == Constants.DEFAULT_GUID)
            {
                var employeeToStore = mapper.Map<Employee>(employee);
                employeeToStore.CreatedBy = new Guid(id);
                wiserContext.Employees.Add(employeeToStore);
                await wiserContext.SaveChangesAsync();
                response.Message = "Employee Added";
                employee.Id = employeeToStore.Id;
                response.Data = employee;
            }
            else
            {
                var existing = await wiserContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
                if (existing != null)
                {
                    mapper.Map(existing, employee);
                    existing.ModifiedBy = new Guid(id);
                    existing.ModifiedDate = DateTime.UtcNow;
                    await wiserContext.SaveChangesAsync();
                    response.Message = "Employee updated";
                    response.Data = employee;
                }
                else
                {
                    response.Message = "You are trying to update the invalid employee";
                    response.Success = false;
                }
            }
            return response;
        }
    }
}
