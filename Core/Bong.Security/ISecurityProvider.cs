using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bong.Security
{
    public interface ISecurityProvider
    {
        Task Challenge(HttpRequest request);
    }
}