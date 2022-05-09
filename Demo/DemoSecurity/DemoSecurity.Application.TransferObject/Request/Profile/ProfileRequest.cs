using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Request.Profile
{
    public class ProfileRequest
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public int CurrentUser { get; set; }
    }
}
