using Dapper;
using DemoSecurity.Application.TransferObject.Response.Profile;
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
    public class ProfileQuery : IProfileQuery
    {
        public GetProfileResponse GetProfile(int idProfile)
        {
            GetProfileResponse response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDPERFIL", idProfile);

                var resultResponse = connection.QueryAsync<GetProfileResponse>(
                    $"{IncomeDataProcedures.Procedure.GetProfileById}",
                    parameters,
                    commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                response = resultResponse;
            }

            return response;
        }

        public IEnumerable<ListProfileResponse> ListProfile()
        {
            IEnumerable<ListProfileResponse> response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var resultResponse = connection.QueryAsync<ListProfileResponse>(
                    $"{IncomeDataProcedures.Procedure.ListProfile}",
                    commandType: CommandType.StoredProcedure).Result;

                response = resultResponse;
            }

            return response;
        }
    }
}
