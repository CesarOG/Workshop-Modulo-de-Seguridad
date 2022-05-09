using Dapper;
using DemoSecurity.Application.TransferObject.Response.Module;
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
    public class ModuleQuery : IModuleQuery
    {
        public GetModuleResponse GetModule(int moduleId)
        {
            GetModuleResponse response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDMODULO", moduleId);

                var resultResponse = connection.QueryAsync<GetModuleResponse>(
                    $"{IncomeDataProcedures.Procedure.GetModuleById}",
                    parameters,
                    commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                response = resultResponse;
            }

            return response;
        }

        public IEnumerable<ListModuleResponse> ListModule()
        {
            IEnumerable<ListModuleResponse> response;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var resultResponse = connection.QueryAsync<ListModuleResponse>(
                    $"{IncomeDataProcedures.Procedure.ListModule}",
                    commandType: CommandType.StoredProcedure).Result;

                response = resultResponse;
            }

            return response;
        }
    }
}
