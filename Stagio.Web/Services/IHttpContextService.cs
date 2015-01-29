using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IHttpContextService
    {
        int GetUserId();
        void AuthenticationSignOut();
        void AuthentificateUser(ApplicationUser applicationUser);
    }
}