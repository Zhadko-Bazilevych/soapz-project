using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ.Operations.BookByCode;
using SOAPZ_Reservation.Operations.BookByCode;
using SOAPZ_Reservation.Operations.Reservation;
using SOAPZ_Reservation.Operations.StatusUpdate;

namespace SOAPZ_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ReservationController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [AllowAnonymous]
        [HttpPost("Reservate")]
        public async Task<ActionResult> Reservate(ReservationRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<ReservationOperation>();
            var result = await operation.Execute(request);
            if (result.Code != 200)
            {
                return StatusCode(result.Code, result.Message);
            }
            return new JsonResult(result);
        }

        //[Authorize("Librarian")]
        [AllowAnonymous]
        [HttpPost("StatusUpdate")]
        public async Task<ActionResult> StatusUpdate(StatusUpdateRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<StatusUpdateOperation>();
            var result = await operation.Execute(request);
            
            return new JsonResult(result);
        }

        //[Authorize("Librarian")]
        [AllowAnonymous]
        [HttpPost("BookByCode")]
        public async Task<ActionResult> BookByCode(BookByCodeRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<BookByCodeOperation>();
            var result = await operation.Execute(request);

            return new JsonResult(result);
        }
    }
}
