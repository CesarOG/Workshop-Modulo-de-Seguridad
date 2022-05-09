using Dapper;
using DemoSecurity.Application.TransferObject.Response.User;
using DemoSecurity.Common.SystemVariable.Constant;
using DemoSecurity.Repository.Data.Interface.NonTransactional;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.NonTransactional
{
    public class UserQuery : IUserQuery
    {
        public GetUserResponse GetUser(int idUser)
        {
            GetUserResponse response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDUSUARIO", idUser);

                var resultResponse = connection.QueryAsync<GetUserResponse>(
                    $"{IncomeDataProcedures.Procedure.GetUserById}",
                    parameters,
                    commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                response = resultResponse;
            }

            return response;
        }

        public IEnumerable<ListUserResponse> ListUser()
        {
            IEnumerable<ListUserResponse> response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var resultResponse = connection.QueryAsync<ListUserResponse>(
                    $"{IncomeDataProcedures.Procedure.ListUser}",
                    commandType: CommandType.StoredProcedure).Result;

                response = resultResponse;
            }

            return response;
        }
    }
}
