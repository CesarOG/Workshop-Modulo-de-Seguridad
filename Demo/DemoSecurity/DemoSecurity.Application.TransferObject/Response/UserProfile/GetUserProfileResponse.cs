using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Response.UserProfile
{
    public class GetUserProfileResponse
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
