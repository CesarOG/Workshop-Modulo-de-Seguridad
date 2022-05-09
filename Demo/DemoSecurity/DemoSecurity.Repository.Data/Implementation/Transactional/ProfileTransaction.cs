using Dapper;
using DemoSecurity.Application.TransferObject.Request.Profile;
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
    public class ProfileTransaction : IProfileTransaction
    {
        public bool CreateProfile(ProfileRequest profileRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NOMBRE", profileRequest.Nombre);
                parameters.Add("@USUARIO_REGISTRA", profileRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.CreateProfile}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool DeleteProfile(int idProfile, int currentUser)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDPERFIL", idProfile);
                parameters.Add("@USUARIO_MODIFICA", currentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.DeleteProfile}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool UpdateProfile(ProfileRequest profileRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDPERFIL", profileRequest.IdPerfil);
                parameters.Add("@NOMBRE", profileRequest.Nombre);
                parameters.Add("@USUARIO_MODIFICA", profileRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.UpdateProfile}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }
    }
}
