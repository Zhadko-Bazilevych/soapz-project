using Microsoft.AspNetCore.Identity;

namespace SOAPZ.Data
{
    public class User : IdentityUser
    {
        public int Code { get; set; }
    }
}
