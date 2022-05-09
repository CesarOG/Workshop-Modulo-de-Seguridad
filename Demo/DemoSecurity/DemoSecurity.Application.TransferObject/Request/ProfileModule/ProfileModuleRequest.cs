using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Request.ProfileModule
{
    public class ProfileModuleRequest
    {
        public int IdPerfil { get; set; }
        public int IdModulo { get; set; }
        public bool Activo { get; set; }
        public int CurrentUser { get; set; }
    }
}
