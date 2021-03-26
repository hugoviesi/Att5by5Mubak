using Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserLogin : IUserLogin
    {
        private UserContext _ctxUser = new UserContext();
        public User CheckUser(User checkingUser)
        {
            var selectedUser = _ctxUser.Users.FirstOrDefault(user => user.Login.Equals(checkingUser.Login) && user.Password.Equals(checkingUser.Password));

            return selectedUser;
        }
    }
}
