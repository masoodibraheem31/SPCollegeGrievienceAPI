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
    public class DepartmentService : IDepartmentService
    {
        private readonly WiserContext wiserContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public DepartmentService(WiserContext wiserContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.wiserContext = wiserContext;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
        public async Task<Response<bool>> DeleteDepartment(Guid Id)
        {
            Response<bool> response = new Response<bool>() { Success = true };
            var department = await wiserContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);
            if (department != null)
            {
                wiserContext.Departments.Remove(department);
                await wiserContext.SaveChangesAsync();
                response.Message = "Department Deleted Successfully";
                response.Data = true;
            }
            else
            {
                response.Message = "You are trying to delete the invalid department";
                response.Success = false;
            }
            return response;
        }

        public async Task<Response<List<DepartmentVM>>> GetDepartments()
        {
            var data=await this.wiserContext.Departments.ToListAsync();
            if (data.Any())
            {
                var departmentVm=mapper.Map<List<DepartmentVM>>(data);
                return new Response<List<DepartmentVM>>()
                {
                    Message = "Department data found",
                    Count = data.Count,
                    Data = departmentVm,
                    Success=true
                };
            }
            else
            {
                return new Response<List<DepartmentVM>>()
                {
                    Message = "Department data not found",              
                    Success = true
                };
            }
        }

        public async Task<Response<DepartmentVM>> SaveDepartment(DepartmentVM department)
        {
            var id = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Response<DepartmentVM> response = new Response<DepartmentVM>() { Success=true};
            if (department.Id== Constants.DEFAULT_GUID)
            {
                var departmentAdd=mapper.Map<Department>(department);
                departmentAdd.CreatedBy = new Guid(id);
                wiserContext.Departments.Add(departmentAdd);
                await wiserContext.SaveChangesAsync();
                response.Message = "Department Added";
                department.Id = departmentAdd.Id;
                response.Data = department;
            }
            else
            {
                var existingDepartment=await wiserContext.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);
                if (existingDepartment != null)
                {
                    mapper.Map(existingDepartment, department);
                    existingDepartment.ModifiedBy = new Guid(id);
                    existingDepartment.ModifiedDate = DateTime.UtcNow;
                    await wiserContext.SaveChangesAsync();
                    response.Message = "Department updated";
                    response.Data = department;
                }
                else
                {
                    response.Message = "You are trying to update the invalid department";
                    response.Success = false;
                }
            }
            return response;
        }
    }
}
