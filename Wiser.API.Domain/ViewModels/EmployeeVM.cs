using System;
using System.Collections.Generic;
using System.Text;

namespace Wiser.API.Entities.ViewModels
{
    public class EmployeeVMv1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DepartmentId { get; set; }
    }
    public class EmployeeVM : EmployeeVMv1
    {        
        public string DepartmentName { get; set; }
       
        
    }
}
