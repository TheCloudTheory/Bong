using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bong.Security
{
    public interface IAuthenticationProvider
    {
        Task<ChallengeResult> Challenge(HttpRequest request);
    }
}