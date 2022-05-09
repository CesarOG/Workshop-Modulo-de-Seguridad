using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.Module;
using DemoSecurity.Application.TransferObject.Response.Module;
using DemoSecurity.Repository.Data.Implementation.NonTransactional;
using DemoSecurity.Repository.Data.Implementation.Transactional;
using DemoSecurity.Repository.Data.Interface.NonTransactional;
using DemoSecurity.Repository.Data.Interface.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Implementation
{
    public class ModuleService : IModuleService
    {
        public IModuleQuery _moduleQuery { get; private set; }
        public IModuleTransaction _moduleTransaction { get; private set; }
        public ModuleService()
        {
            this._moduleQuery = new ModuleQuery();
            this._moduleTransaction = new ModuleTransaction();
        }
        public bool CreateModule(ModuleRequest moduleRequest)
        {
            return _moduleTransaction.CreateModule(moduleRequest);
        }

        public bool DeleteModule(int idModule, int currentUser)
        {
            return _moduleTransaction.DeleteModule(idModule, currentUser);
        }

        public GetModuleResponse GetModule(int moduleId)
        {
            return _moduleQuery.GetModule(moduleId);
        }

        public IEnumerable<ListModuleResponse> ListModule()
        {
            return _moduleQuery.ListModule();
        }

        public bool UpdateModule(ModuleRequest moduleRequest)
        {
            return _moduleTransaction.UpdateModule(moduleRequest);
        }
    }
}
