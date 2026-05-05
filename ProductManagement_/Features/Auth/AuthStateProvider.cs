using Microsoft.AspNetCore.Components.Authorization;
using ProductManagement_.Features.Data.Enums;
using System.Security.Claims;

namespace ProductManagement_.Features.Auth
{
    public class AuthStateProvider : AuthenticationStateProvider
    {

        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            Task.FromResult(new AuthenticationState(_currentUser));

        public void SetUser(string username, Roles role)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role.ToString())
            }, "ProductManagementAuth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void ClearUser()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public bool IsAuthenticated =>
            _currentUser.Identity?.IsAuthenticated ?? false;

        public string? CurrentUsername =>
            _currentUser.Identity?.Name;

        public bool IsAdmin =>
            _currentUser.IsInRole(Roles.Admin.ToString());
    }
}
