using System;
using System.Collections.Generic;
using System.Text;

namespace Wiser.API.Entities.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
