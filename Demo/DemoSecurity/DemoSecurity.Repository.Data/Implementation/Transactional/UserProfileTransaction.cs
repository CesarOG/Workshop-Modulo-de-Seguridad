using DemoSecurity.Application.TransferObject.Request.UserProfile;
using DemoSecurity.Repository.Data.Interface.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Implementation.Transactional
{
    public class UserProfileTransaction : IUserProfileTransaction
    {
        public bool CreateUserProfile(UserProfileRequest userProfileRequest)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserProfile(UserProfileRequest userProfileRequest)
        {
            throw new NotImplementedException();
        }
    }
}
