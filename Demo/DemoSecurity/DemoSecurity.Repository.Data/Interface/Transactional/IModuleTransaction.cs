using DemoSecurity.Application.TransferObject.Request.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.Transactional
{
    public interface IModuleTransaction
    {
        bool CreateModule(ModuleRequest moduleRequest);
        bool UpdateModule(ModuleRequest moduleRequest);
        bool DeleteModule(int idModule,int currentUser);
    }
}
