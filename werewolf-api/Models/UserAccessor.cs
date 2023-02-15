using System.Linq;
using System.Security.Claims;

namespace werewolf_api.Models
{
    public interface IUserAccessor
    {
        public ClaimsPrincipal GetClaimsPrincipal();
        public string GetUser();
        public string GetSession();
    }

    public class UserAccessor : IUserAccessor
    {
        private IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal GetClaimsPrincipal()
        {
            return _httpContextAccessor.HttpContext!.User;
        }

        public string GetUser()
        {
            return GetClaimsPrincipal().FindFirstValue("user");
        }

        public string GetSession()
        {
            return GetClaimsPrincipal().FindFirstValue("session");
        }

    }
}
