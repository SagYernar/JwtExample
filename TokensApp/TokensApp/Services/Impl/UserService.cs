using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokensApp.Data;
using TokensApp.Models;
using TokensApp.Models.ViewModels;

namespace TokensApp.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly AppOptions appOptions;
        private readonly BaseContext context;

        public UserService(IOptions<AppOptions> appOptions, BaseContext context)
        {
            this.appOptions = appOptions.Value;
            this.context = context;
        }

        public UserViewModel Authenticate(UserViewModel user)
        {
            var resUser = context.Users
                .Where(u => u.Login == user.Login
                && u.Password == user.Password);
            if (user == null)
                return null;

            UserViewModel responseUser = new UserViewModel();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            responseUser.Token = tokenHandler.WriteToken(token);

            return responseUser;
        }

        public IEnumerable<User> GetUsers()
        {
            var result = context.Users.ToList();
            return result;
        }
    }
}
