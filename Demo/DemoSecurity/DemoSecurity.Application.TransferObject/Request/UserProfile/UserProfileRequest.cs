using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Request.UserProfile
{
    public class UserProfileRequest
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public bool Activo { get; set; }
        public int CurrentUser { get; set; }
    }
}
