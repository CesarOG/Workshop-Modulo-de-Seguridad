using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Request.Module
{
    public class ModuleRequest
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int? IdModuloPadre { get; set; }
        public int CurrentUser { get; set; }
    }
}
