using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bong.Security.Basic
{
    public class AuthenticationProvider : IAuthenticationProvider, IAuthenticationLogic
    {
        private readonly IConfigurationRoot _configuration;

        public AuthenticationProvider(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public Task<ChallengeResult> Challenge(HttpRequest request)
        {
            if (request.Cookies.ContainsKey("Bong.Security.Basic.Token") &&
                request.Cookies["Bong.Security.Basic.Token"] == GetToken())
            {
                return Task.FromResult(new ChallengeResult
                {
                    IsAuthenticated = true
                });
            }

            return Task.FromResult(new ChallengeResult
            {
                Action = new RedirectResult("~/login")
            });
        }

        public string GetToken()
        {
            var login = _configuration.GetValue(typeof(string), "Security:Bong.Security.Basic:Login").ToString();
            var password = _configuration.GetValue(typeof(string), "Security:Bong.Security.Basic:Password").ToString();
            var token = _configuration.GetValue(typeof(string), "Security:Bong.Security.Basic:Token").ToString();
            var decodedHash = login + password + token;

            var result = new StringBuilder();
            var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(decodedHash));

            foreach (var @byte in hash)
            {
                result.Append(@byte.ToString("x2"));
            }

            return result.ToString();
        }
    }
}