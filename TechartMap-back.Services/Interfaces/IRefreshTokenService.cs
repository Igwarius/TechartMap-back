using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetRefreshToken(string username);
        Task DeleteRefreshToken(string username);
        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}