using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.TransferObject.Request.User
{
    public class UserRequest
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int CurrentUser { get; set; }
    }
}
