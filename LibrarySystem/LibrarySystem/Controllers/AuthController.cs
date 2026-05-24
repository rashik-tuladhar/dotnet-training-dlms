using LibrarySystem.Helpers;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibrarySystem.Controllers
{
    /// <summary>
    /// Handles authentication requests including login, logout, and access-denied views.
    /// Uses hardcoded credentials for demonstration and secure encrypted cookies.
    /// </summary>
    public class AuthController : Controller
    {
        private const string AuthCookieName = "LibraryAuthCookie";

        // Hardcoded users list
        private static readonly (string Username, string Password, string Role)[] HardcodedUsers = new[]
        {
            ("admin", "adminpassword", "SuperAdmin"),
            ("staff", "staffpassword", "Staff")
        };

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            // If user is already authenticated, redirect them to the home page or return URL
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToLocal(returnUrl);
            }

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 1. Authenticate user against hardcoded database
            string? userRole = null;
            foreach (var user in HardcodedUsers)
            {
                if (string.Equals(user.Username, model.Username, StringComparison.OrdinalIgnoreCase) && 
                    user.Password == model.Password)
                {
                    userRole = user.Role;
                    break;
                }
            }

            if (userRole != null)
            {
                // 2. Determine expiration time (e.g. 60 minutes from now)
                var expiryTime = DateTime.UtcNow.AddMinutes(60);
                
                // 3. Construct cookie payload: Username|Role|ExpiryTicks
                var payload = $"{model.Username}|{userRole}|{expiryTime.Ticks}";
                
                // 4. Encrypt cookie payload using AES-256
                var encryptedPayload = EncryptionHelper.Encrypt(payload);

                // 5. Build secure cookie options
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,                  // Protects against XSS cookie theft
                    Secure = Request.IsHttps,         // Send cookie only over HTTPS in production
                    SameSite = SameSiteMode.Strict,   // Mitigates CSRF attacks
                    Expires = expiryTime              // Persistent cookie expiration
                };

                // 6. Append the cookie to the HTTP response
                Response.Cookies.Append(AuthCookieName, encryptedPayload, cookieOptions);

                // 7. Redirect to requested page
                return RedirectToLocal(model.ReturnUrl);
            }

            // Authentication failed
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Clear the authentication cookie
            Response.Cookies.Delete(AuthCookieName);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
