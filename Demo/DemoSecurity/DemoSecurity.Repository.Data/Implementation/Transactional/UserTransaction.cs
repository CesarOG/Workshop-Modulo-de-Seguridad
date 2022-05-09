using Dapper;
using DemoSecurity.Application.TransferObject.Request.User;
using DemoSecurity.Common.SystemVariable.Constant;
using DemoSecurity.Repository.Data.Interface.Transactional;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.Transactional
{
    public class UserTransaction : IUserTransaction
    {
        public bool CreateUser(UserRequest userRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NOMBRECOMPLETO", userRequest.NombreCompleto);
                parameters.Add("@USUARIO", userRequest.Usuario);
                parameters.Add("@CONTRASENA", userRequest.Contrasena);
                parameters.Add("@USUARIO_REGISTRA", userRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.CreateUser}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool DeleteUser(int idUser, int currentUser)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDUSUARIO", idUser);
                parameters.Add("@USUARIO_MODIFICA", currentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.DeleteUser}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool UpdateUser(UserRequest userRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDUSUARIO", userRequest.IdUsuario);
                parameters.Add("@NOMBRECOMPLETO", userRequest.NombreCompleto);
                parameters.Add("@USUARIO", userRequest.Usuario);
                parameters.Add("@CONTRASENA", userRequest.Contrasena);
                parameters.Add("@USUARIO_MODIFICA", userRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.UpdateUser}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }
    }
}
