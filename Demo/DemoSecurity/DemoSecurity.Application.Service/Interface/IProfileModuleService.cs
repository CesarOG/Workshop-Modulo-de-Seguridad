using DemoSecurity.Application.TransferObject.Request.ProfileModule;
using DemoSecurity.Application.TransferObject.Response.ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Interface
{
    public interface IProfileModuleService
    {
        IEnumerable<GetProfileModuleResponse> GetProfileModuleByIdProfile(int idProfile);
        bool CreateProfileModule(ProfileModuleRequest moduleRequest);
        bool UpdateProfileModule(ProfileModuleRequest moduleRequest);
    }
}
