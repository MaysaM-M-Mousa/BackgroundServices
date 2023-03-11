using BackgroundWorkers.Models;
using BackgroundWorkers.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundWorkers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        public IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public ActionResult<List<Shift>> GetAllShifts()
        {
            return _shiftService.GetAllShifts();
        }

        [HttpGet("id")]
        public ActionResult<Shift> GetShiftById(Guid id)
        {
            return _shiftService.GetShiftById(id);
        }

        [HttpPost]
        public ActionResult<Shift> CreateShift([FromBody] Shift shift)
        {
            _shiftService.CreateShift(shift);
            return Ok(shift);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteShift(Guid id)
        {
            _shiftService.DeleteShift(id);
            return Ok();
        }
    }
}
