using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.UserProfile;
using DemoSecurity.Application.TransferObject.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        public bool CreateUserProfile(UserProfileRequest userProfileRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetUserProfileResponse> GetUserProfileByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserProfile(UserProfileRequest userProfileRequest)
        {
            throw new NotImplementedException();
        }
    }
}
