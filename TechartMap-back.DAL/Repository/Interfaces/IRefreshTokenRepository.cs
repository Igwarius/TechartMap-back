using System.Threading.Tasks;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetRefreshToken(string username);
        Task DeleteRefreshToken(string username);
        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}