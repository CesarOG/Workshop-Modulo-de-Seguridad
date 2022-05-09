using DemoSecurity.Application.TransferObject.Response.UserProfile;
using DemoSecurity.Repository.Data.Interface.NonTransactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.NonTransactional
{
    public class UserProfileQuery : IUserProfileQuery
    {
        public IEnumerable<GetUserProfileResponse> GetUserProfileByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
