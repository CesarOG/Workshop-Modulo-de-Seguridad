using DemoSecurity.Application.TransferObject.Response.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.NonTransactional
{
    public interface IProfileQuery
    {
        IEnumerable<ListProfileResponse> ListProfile();
        GetProfileResponse GetProfile(int idProfile);
    }
}
