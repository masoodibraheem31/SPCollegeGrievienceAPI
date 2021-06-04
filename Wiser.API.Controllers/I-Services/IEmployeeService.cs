using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiser.API.BL.Config;
using Wiser.API.Entities.Models;
using Wiser.API.Entities.ViewModels;

namespace Wiser.API.BL.I_Services
{
    public interface IEmployeeService
    {
        Task<Response<List<EmployeeVM>>> GetEmployees();
        Task<Response<EmployeeVMv1>> SaveEmployee(EmployeeVMv1 employee);
        Task<Response<bool>> DeleteEmployee(Guid Id);
    }
}
