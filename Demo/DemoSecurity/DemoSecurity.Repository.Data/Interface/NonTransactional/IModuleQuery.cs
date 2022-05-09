using DemoSecurity.Application.TransferObject.Response.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.NonTransactional
{
    public interface IModuleQuery
    {
        IEnumerable<ListModuleResponse> ListModule();
        GetModuleResponse GetModule(int moduleId);
    }
}
