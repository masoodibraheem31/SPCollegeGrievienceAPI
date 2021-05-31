using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiser.API.BL.Config;
using Wiser.API.Entities.BusinessModels;
//using Wiser.API.Entities.BusinessModels;
using Wiser.API.Entities.Models;

namespace Wiser.API.BL.I_Services
{
    public interface ISystemUserAuthenticationService
    {
        Task<Response<IdentityResult>> RegisterSystemUser(UserProfile systemUser);
        Task<Response<LoginResponse>> LoginSystemUser(LoginModel model);
        Task<Response<string>> CreateRole(string RoleName);
        Task<Response<LoginResponse>> IsUserLoggedIn();
    }
}
