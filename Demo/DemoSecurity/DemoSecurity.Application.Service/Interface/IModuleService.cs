using DemoSecurity.Application.TransferObject.Request.Module;
using DemoSecurity.Application.TransferObject.Response.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Interface
{
    public interface IModuleService
    {
        IEnumerable<ListModuleResponse> ListModule();
        GetModuleResponse GetModule(int moduleId);
        bool CreateModule(ModuleRequest moduleRequest);
        bool UpdateModule(ModuleRequest moduleRequest);
        bool DeleteModule(int idModule, int currentUser);
    }
}
