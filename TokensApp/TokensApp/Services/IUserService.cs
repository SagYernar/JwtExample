using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokensApp.Models;
using TokensApp.Models.ViewModels;

namespace TokensApp.Services.Impl
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        UserViewModel Authenticate(UserViewModel user);
    }
}
