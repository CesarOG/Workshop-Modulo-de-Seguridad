using DemoSecurity.Application.TransferObject.Response.ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.NonTransactional
{
    public interface IProfileModuleQuery
    {
        IEnumerable<GetProfileModuleResponse> GetProfileModuleByIdProfile(int idProfile);
    }
}
