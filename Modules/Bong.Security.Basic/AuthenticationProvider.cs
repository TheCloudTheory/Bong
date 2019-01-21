﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bong.Security.Basic
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public Task<ChallengeResult> Challenge(HttpRequest request)
        {
            if (request.Headers.ContainsKey("Bong,Security.Token"))
            {
                return Task.FromResult(new ChallengeResult()
                {
                    IsAuthenticated = true
                });
            }

            return Task.FromResult(new ChallengeResult());
        }
    }
}