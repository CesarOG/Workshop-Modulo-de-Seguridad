using DemoSecurity.Application.TransferObject.Request.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.Transactional
{
    public interface IProfileTransaction
    {
        bool CreateProfile(ProfileRequest profileRequest);
        bool UpdateProfile(ProfileRequest profileRequest);
        bool DeleteProfile(int idProfile, int currentUser);
    }
}
