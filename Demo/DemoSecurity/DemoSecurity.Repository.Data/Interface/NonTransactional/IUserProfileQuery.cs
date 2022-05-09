using DemoSecurity.Application.TransferObject.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.NonTransactional
{
    public interface IUserProfileQuery
    {
        IEnumerable<GetUserProfileResponse> GetUserProfileByIdUser(int idUser);
    }
}
