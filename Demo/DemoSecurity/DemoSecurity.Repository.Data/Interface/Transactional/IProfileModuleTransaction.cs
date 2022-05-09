using DemoSecurity.Application.TransferObject.Request.ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.Transactional
{
    public interface IProfileModuleTransaction
    {
        bool CreateProfileModule(ProfileModuleRequest profileModuleRequest);
        bool UpdateProfileModule(ProfileModuleRequest profileModuleRequest);
    }
}
