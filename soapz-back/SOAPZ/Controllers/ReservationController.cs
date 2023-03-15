using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ.Operations.Books;
using SOAPZ.Operations.BookByCode;
using SOAPZ.Operations.Reservation;
using SOAPZ.Operations.StatusUpdate;
using SOAPZ.Services;

namespace SOAPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService reservationService;
        public ReservationController(ReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [Authorize]
        [HttpPost("Reservate")]
        public async Task<ActionResult> Books(ReservationRequest request)
        {
            return new JsonResult(await reservationService.ReservateOperation(request));
        }
        [Authorize]
        [HttpPost("StatusUpdate")]
        public async Task<ActionResult> StatusUpdate(StatusUpdateRequest request)
        {
            return new JsonResult(await reservationService.StatusUpdateOperation(request));
        }

        [Authorize]
        [HttpPost("BookByCode")]
        public async Task<ActionResult> BookByCode(BookByCodeRequest request)
        {
            return new JsonResult(await reservationService.BookByCodeOperation(request));
        }

    }
}
