using Microsoft.AspNetCore.Http;
using System;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading.Tasks;
using LibrarySystem.Helpers;

namespace LibrarySystem.Middleware
{
    /// <summary>
    /// Custom authentication middleware that intercepts every HTTP request,
    /// checks for the presence of a secure authentication cookie, decrypts it,
    /// and populates the HttpContext.User with a ClaimsPrincipal.
    /// </summary>
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AuthCookieName = "LibraryAuthCookie";

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Retrieve the custom authentication cookie from the request
            var cookie = context.Request.Cookies[AuthCookieName];

            if (!string.IsNullOrEmpty(cookie))
            {
                try
                {
                    // 2. Decrypt the cookie value using the AES-256 helper
                    var decrypted = EncryptionHelper.Decrypt(cookie);

                    // Check for decryption errors
                    if (!decrypted.StartsWith("Decryption failed"))
                    {
                        // 3. Parse the cookie payload. Format: Username|Role|ExpiryTicks
                        var parts = decrypted.Split('|');
                        if (parts.Length == 3)
                        {
                            var username = parts[0];
                            var role = parts[1];
                            
                            if (long.TryParse(parts[2], out var expiryTicks))
                            {
                                var expiry = new DateTime(expiryTicks, DateTimeKind.Utc);

                                // 4. Check if the token has expired
                                if (expiry > DateTime.UtcNow)
                                {
                                    // 5. Build the user identity and claims principal
                                    var identity = new GenericIdentity(username, "CustomAuth");
                                    identity.AddClaim(new Claim(ClaimTypes.Name, username));
                                    identity.AddClaim(new Claim(ClaimTypes.Role, role));

                                    // Build GenericPrincipal with user identity and roles array
                                    var principal = new GenericPrincipal(identity, new[] { role });

                                    // Assign user to current HttpContext
                                    context.User = principal;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // In a production application, log authorization errors here.
                    // For security, do not leak internal exception details to the client.
                }
            }

            // Continue the request pipeline
            await _next(context);
        }
    }
}
