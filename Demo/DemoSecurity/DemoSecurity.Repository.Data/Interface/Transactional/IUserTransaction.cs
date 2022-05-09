using DemoSecurity.Application.TransferObject.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurity.Repository.Data.Interface.Transactional
{
    public interface IUserTransaction
    {
        bool CreateUser(UserRequest userRequest);
        bool UpdateUser(UserRequest userRequest);
        bool DeleteUser(int idUser, int currentUser);
    }
}
