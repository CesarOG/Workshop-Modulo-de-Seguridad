using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.Profile;
using DemoSecurity.Application.TransferObject.Response.Profile;
using DemoSecurity.Repository.Data.Implementation.NonTransactional;
using DemoSecurity.Repository.Data.Implementation.Transactional;
using DemoSecurity.Repository.Data.Interface.NonTransactional;
using DemoSecurity.Repository.Data.Interface.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Implementation
{
    public class ProfileService : IProfileService
    {
        public IProfileQuery _profileQuery { get; private set; }
        public IProfileTransaction _profileTransaction { get; private set; }
        public ProfileService()
        {
            this._profileQuery = new ProfileQuery();
            this._profileTransaction = new ProfileTransaction();
        }
        public bool CreateProfile(ProfileRequest profileRequest)
        {
            return _profileTransaction.CreateProfile(profileRequest);
        }

        public bool DeleteProfile(int idProfile, int currentUser)
        {
            return _profileTransaction.DeleteProfile(idProfile, currentUser);
        }

        public GetProfileResponse GetProfile(int idProfile)
        {
            return _profileQuery.GetProfile(idProfile);
        }

        public IEnumerable<ListProfileResponse> ListProfile()
        {
            return _profileQuery.ListProfile();
        }

        public bool UpdateProfile(ProfileRequest profileRequest)
        {
            return _profileTransaction.UpdateProfile(profileRequest);
        }
    }
}
