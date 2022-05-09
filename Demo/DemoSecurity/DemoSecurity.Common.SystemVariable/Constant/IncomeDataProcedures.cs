using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Common.SystemVariable.Constant
{
    public class IncomeDataProcedures
    {
        public static class Schema
        {
            public const string Dbo = "dbo";
        }
        public static class Procedure
        {
            public const string ListUser = "SP_LISTAR_USUARIO";
            public const string GetUserById = "SP_OBTENER_USUARIO_PorID";
            public const string CreateUser = "SP_REGISTRA_USUARIO";
            public const string UpdateUser = "SP_ACTUALIZA_USUARIO";
            public const string DeleteUser = "SP_ELIMINA_USUARIO";

            public const string ListProfile = "SP_LISTAR_PERFIL";
            public const string GetProfileById = "SP_OBTENER_PERFIL_PorID";
            public const string CreateProfile = "SP_REGISTRA_PERFIL";
            public const string UpdateProfile = "SP_ACTUALIZA_PERFIL";
            public const string DeleteProfile = "SP_ELIMINA_PERFIL";

            public const string ListModule = "SP_LISTAR_MODULO";
            public const string GetModuleById = "SP_OBTENER_MODULO_PorID";
            public const string CreateModule = "SP_REGISTRA_MODULO";
            public const string UpdateModule = "SP_ACTUALIZA_MODULO";
            public const string DeleteModule = "SP_ELIMINA_MODULO";

            public const string GetProfileModuleByIds = "SP_OBTENER_PERFILMODULO_PorIDS";
            public const string CreateProfileModule = "SP_REGISTRA_PERFIL_MODULO";
            public const string UpdateProfileModule = "SP_ACTUALIZA_PERFIL_MODULO";

            public const string GetUserProfileByIds = "SP_OBTENER_USUARIOPERFIL_PorIDS";
            public const string CreateUserProfile = "SP_REGISTRA_USUARIO_PERFIL";
            public const string UpdateUserProfile = "SP_ACTUALIZA_USUARIO_PERFIL";
        }
    }
}
