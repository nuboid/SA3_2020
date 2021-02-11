using System.Threading.Tasks;
using ARCH.Shared.APIContracts.DTOs;
using Refit;

namespace ARCH.Shared.APIContracts
{
    public interface ITestApi
    {
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
}