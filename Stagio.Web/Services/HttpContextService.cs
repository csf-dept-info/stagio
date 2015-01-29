using System.Globalization;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Stagio.Domain.Entities;


namespace Stagio.Web.Services
{
    public class HttpContextService : IHttpContextService
    {
        public int GetUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            return int.Parse(userId);
        }

        public void AuthentificateUser(ApplicationUser applicationUser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, applicationUser.Identifier),
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString(CultureInfo.InvariantCulture))
            },
                DefaultAuthenticationTypes.ApplicationCookie);

            foreach (var role in applicationUser.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }

            AuthenticationSignIn(identity);
        }

        public void AuthenticationSignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }


        private void AuthenticationSignIn(ClaimsIdentity identity)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties(), identity);
        }
    }
}