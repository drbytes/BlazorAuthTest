using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorAuth.Services.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public static bool Authenticated { get; set ;}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claimsIdentity = Authenticated ? new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "test_user")
            }, "server_auth")
            :
            new ClaimsIdentity();
            return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
        }
        
        public async Task NotifyStateChange()
        {
            Console.WriteLine($"Calling NotifyStateChange... with Auth={Authenticated}");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

    }
}