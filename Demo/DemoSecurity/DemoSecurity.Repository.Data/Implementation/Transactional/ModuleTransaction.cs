using Dapper;
using DemoSecurity.Application.TransferObject.Request.Module;
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
    public class ModuleTransaction : IModuleTransaction
    {
        public bool CreateModule(ModuleRequest moduleRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NOMBRE", moduleRequest.Nombre);
                parameters.Add("@RUTA", moduleRequest.Ruta);
                parameters.Add("@IDMODULOPADRE", moduleRequest.IdModuloPadre);
                parameters.Add("@USUARIO_REGISTRA", moduleRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.CreateModule}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool DeleteModule(int idModule, int currentUser)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDMODULO", idModule);
                parameters.Add("@USUARIO_MODIFICA", currentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.DeleteModule}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }

        public bool UpdateModule(ModuleRequest moduleRequest)
        {
            bool response = false;

            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IDMODULO", moduleRequest.IdModulo);
                parameters.Add("@NOMBRE", moduleRequest.Nombre);
                parameters.Add("@RUTA", moduleRequest.Ruta);
                parameters.Add("@IDMODULOPADRE", moduleRequest.IdModuloPadre);
                parameters.Add("@USUARIO_MODIFICA", moduleRequest.CurrentUser);

                var result = connection.Query<string>(
                    $"{IncomeDataProcedures.Procedure.UpdateModule}",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //TODO: Validar la respuesta
                response = true;
            }
            return response;
        }
    }
}
