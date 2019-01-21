using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bong.Security.Basic
{
    public class SecurityProvider : ISecurityProvider
    {
        public Task Challenge(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}