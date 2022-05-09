using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.ProfileModule;
using DemoSecurity.Application.TransferObject.Response.ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Implementation
{
    public class ProfileModuleService : IProfileModuleService
    {
        public bool CreateProfileModule(ProfileModuleRequest moduleRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetProfileModuleResponse> GetProfileModuleByIdProfile(int idProfile)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfileModule(ProfileModuleRequest moduleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
