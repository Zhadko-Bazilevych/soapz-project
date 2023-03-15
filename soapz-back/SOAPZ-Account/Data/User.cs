using Microsoft.AspNetCore.Identity;

namespace SOAPZ_Account.Data
{
    public class User : IdentityUser
    {
        public int Code { get; set; }
    }
}
