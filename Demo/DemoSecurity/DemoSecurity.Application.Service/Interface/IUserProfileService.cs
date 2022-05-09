using DemoSecurity.Application.TransferObject.Request.UserProfile;
using DemoSecurity.Application.TransferObject.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Interface
{
    public interface IUserProfileService
    {
        IEnumerable<GetUserProfileResponse> GetUserProfileByIdUser(int idUser);
        bool CreateUserProfile(UserProfileRequest userProfileRequest);
        bool UpdateUserProfile(UserProfileRequest userProfileRequest);
    }
}
