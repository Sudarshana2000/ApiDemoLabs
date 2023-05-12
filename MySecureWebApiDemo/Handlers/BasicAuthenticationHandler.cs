using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace MySecureWebApiDemo.Handlers
{
    public class BasicAuthenticationHandler
        : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock ) 
        : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string? username;

            try
            {
                var authHeader 
                    = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials
                    = Encoding.UTF8
                              .GetString(Convert.FromBase64String(authHeader.Parameter ?? string.Empty))
                              .Split(':');
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();
                // now check the username & password against some datastore.
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Auth failed: {ex.Message}");
            }

            if (username is null)
            {
                return AuthenticateResult.Fail($"Auth failed: Invalid username");
            }

            // Add the Claims to the user (preferably from the database!
            var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
