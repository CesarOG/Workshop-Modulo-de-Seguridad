using DemoSecurity.Application.TransferObject.Response.ProfileModule;
using DemoSecurity.Repository.Data.Interface.NonTransactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.NonTransactional
{
    public class ProfileModuleQuery : IProfileModuleQuery
    {
        public IEnumerable<GetProfileModuleResponse> GetProfileModuleByIdProfile(int idProfile)
        {
            throw new NotImplementedException();
        }
    }
}
