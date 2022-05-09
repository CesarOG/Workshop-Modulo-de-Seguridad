using DemoSecurity.Application.Service.Interface;
using DemoSecurity.Application.TransferObject.Request.User;
using DemoSecurity.Application.TransferObject.Response.User;
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
    public class UserService : IUserService
    {
        public IUserQuery _userQuery { get; private set; }
        public IUserTransaction _userTransaction { get; private set; }
        public UserService()
        {
            this._userQuery = new UserQuery();
            this._userTransaction = new UserTransaction();
        }
        public bool CreateUser(UserRequest userRequest)
        {
            return _userTransaction.CreateUser(userRequest);
        }

        public bool DeleteUser(int idUser, int currentUser)
        {
            return _userTransaction.DeleteUser(idUser, currentUser);
        }

        public GetUserResponse GetUser(int idUser)
        {
            return _userQuery.GetUser(idUser);
        }

        public IEnumerable<ListUserResponse> ListUser()
        {
            return _userQuery.ListUser();
        }

        public bool UpdateUser(UserRequest userRequest)
        {
            return _userTransaction.UpdateUser(userRequest);
        }

        public bool Login(LoginRequest loginRequest)
        {
            var listUser = _userQuery.ListUser();
            var user = listUser.Where(x => x.Usuario.Equals(loginRequest.UserName) && x.Contrasena.Equals(loginRequest.Password)).FirstOrDefault();

            return user != null;
        }
    }
}
