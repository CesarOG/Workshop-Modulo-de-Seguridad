using Dapper;
using DemoSecurity.Application.TransferObject.Request.ProfileModule;
using DemoSecurity.Common.SystemVariable.Constant;
using DemoSecurity.Repository.Data.Interface.Transactional;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.Transactional
{
    public class ProfileModuleTransaction : IProfileModuleTransaction
    {
        public bool CreateProfileModule(ProfileModuleRequest profileModuleRequest)
        {
            bool response = false;
            using (var connection = new SqlConnection(AppSettingValue.ConnectionDataBase))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IDMODULO", profileModuleRequest.IdModulo);


            }
            return response;
        }

        public bool UpdateProfileModule(ProfileModuleRequest profileModuleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
