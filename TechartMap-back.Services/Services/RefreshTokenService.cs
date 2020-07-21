using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> GetRefreshToken(string login)
        {
            var res = await _refreshTokenRepository.GetRefreshToken(login);
            if (res == null) return null;

            var refreshToken = new RefreshToken
            {
                Login = res.Login,
                Token = res.Token
            };

            return refreshToken;
        }

        public async Task DeleteRefreshToken(string login)
        {
            await _refreshTokenRepository.DeleteRefreshToken(login);
        }

        public async Task SaveRefreshToken(string login, string newRefreshToken)
        {
            await _refreshTokenRepository.SaveRefreshToken(login, newRefreshToken);
        }
    }
}