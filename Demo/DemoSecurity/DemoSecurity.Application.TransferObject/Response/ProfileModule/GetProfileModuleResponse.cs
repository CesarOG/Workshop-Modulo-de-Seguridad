using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Response.ProfileModule
{
    public class GetProfileModuleResponse
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int IdModuloPadre { get; set; }
        public string ModuloPadre { get; set; }
        public bool Activo { get; set; }
    }
}
