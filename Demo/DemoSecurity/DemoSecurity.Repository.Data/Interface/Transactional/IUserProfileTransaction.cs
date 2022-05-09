using DemoSecurity.Application.TransferObject.Request.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.Transactional
{
    public interface IUserProfileTransaction
    {
        bool CreateUserProfile(UserProfileRequest userProfileRequest);
        bool UpdateUserProfile(UserProfileRequest userProfileRequest);
    }
}
