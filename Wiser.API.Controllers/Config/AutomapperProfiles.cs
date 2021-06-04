using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wiser.API.Entities.BusinessModels;
using Wiser.API.Entities.Models;
using Wiser.API.Entities.ViewModels;

namespace Wiser.API.BL.Config
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Institute, InstituteVM>().ReverseMap();
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Employee, EmployeeVMv1>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
