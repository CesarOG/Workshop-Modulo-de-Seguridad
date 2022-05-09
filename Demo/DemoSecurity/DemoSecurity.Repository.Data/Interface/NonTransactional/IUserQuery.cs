using DemoSecurity.Application.TransferObject.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.NonTransactional
{
    public interface IUserQuery
    {
        IEnumerable<ListUserResponse> ListUser();
        GetUserResponse GetUser(int idUser);
    }
}
