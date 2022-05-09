using DemoSecurity.Application.TransferObject.Request.User;
using DemoSecurity.Application.TransferObject.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Application.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<ListUserResponse> ListUser();
        GetUserResponse GetUser(int idUser);
        bool CreateUser(UserRequest userRequest);
        bool UpdateUser(UserRequest userRequest);
        bool DeleteUser(int idUser, int currentUser);
        bool Login(LoginRequest loginRequest);
    }
}
