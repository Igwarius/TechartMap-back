using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Classes;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class UserService :IUserService
    {
        private readonly IRefreshTokenRepository _refreshTokensRepository;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IRefreshTokenRepository refreshTokensRepository)
        {
            _userRepository = userRepository;
            _refreshTokensRepository = refreshTokensRepository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
        public async Task<User> GetCurrentUser(string username)
        {
            var foundUser = await _userRepository.GetCurrentUser(username);
            if (foundUser == null)
            {
                return null;
            }

            return foundUser;
        }
        public async Task AddUser(User user)
        {
            await _userRepository.AddUser(new User
            {
                Login = user.Login,
                Password = HashFunc.GetHashFromPassword(
                    user.Password),
                Role = Roles.User.ToString()
            });
        }
        public async Task<Tokens> CheckUser(User user)
        {
            var checkUser = await _userRepository.CheckUser(new User
                { Login = user.Login, Password = HashFunc.GetHashFromPassword(user.Password), Role = user.Role });
            if (checkUser == null)
            {
                return null;
            }

            var foundUser = new User
            {
                Login = checkUser.Login,
                Password = checkUser.Password,
                Role = checkUser.Role
            };

            var identity = ClaimsService.GetIdentity(foundUser);
            if (identity == null) { return null; }

            var jwtToken = TokenService.CreateToken(identity);
            if (jwtToken != null)
            {
                var newRefreshToken = TokenService.GenerateRefreshToken();
                await _refreshTokensRepository.SaveRefreshToken(checkUser.Login, newRefreshToken);

                Tokens tokens = new Tokens
                {
                    Token = jwtToken,
                    RefreshToken = newRefreshToken
                };

                return tokens;
            }

            return null;
        }
    }

}
