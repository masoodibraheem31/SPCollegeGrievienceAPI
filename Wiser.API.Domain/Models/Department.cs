using System;
using System.Collections.Generic;
using System.Text;

namespace Wiser.API.Entities.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
