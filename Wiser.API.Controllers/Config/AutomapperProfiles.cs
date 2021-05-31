using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wiser.API.Entities.BusinessModels;
using Wiser.API.Entities.Models;

namespace Wiser.API.BL.Config
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Institute, InstituteVM>().ReverseMap();
        }
    }
}
