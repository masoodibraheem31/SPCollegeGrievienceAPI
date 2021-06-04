using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiser.API.BL.Config;
using Wiser.API.BL.Services;
using Wiser.API.Entities.Models;
using Wiser.API.Entities.ViewModels;

namespace Wiser.API.BL.I_Services
{
    public interface IDepartmentService
    {
        Task<Response<List<DepartmentVM>>> GetDepartments();
        Task<Response<DepartmentVM>> SaveDepartment(DepartmentVM department);
        Task<Response<bool>> DeleteDepartment(Guid Id);

    }
}
