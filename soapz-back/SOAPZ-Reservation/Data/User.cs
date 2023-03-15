using Microsoft.AspNetCore.Identity;

namespace SOAPZ_Reservation.Data
{
    public class User : IdentityUser
    {
        public int Code { get; set; }
    }
}
