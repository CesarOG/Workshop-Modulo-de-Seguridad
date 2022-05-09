using DemoSecurity.Application.TransferObject.Request.Profile;
using DemoSecurity.Application.TransferObject.Response.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Interface
{
    public interface IProfileService
    {
        IEnumerable<ListProfileResponse> ListProfile();
        GetProfileResponse GetProfile(int idProfile);
        bool CreateProfile(ProfileRequest profileRequest);
        bool UpdateProfile(ProfileRequest profileRequest);
        bool DeleteProfile(int idProfile, int currentUser);
    }
}
