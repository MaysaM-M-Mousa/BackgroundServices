using Microsoft.AspNetCore.Mvc;
using ThirdParty.Models;

namespace ThirdParty.Controllers
{
    [ApiController]
    [Route("[controller]/shifts/import")]
    public class ThirdPartyController : ControllerBase
    {
        [HttpGet(Name = "GetShifts")]
        public IEnumerable<Shift> GetShifts()
        {
            var shifts = new List<Shift>()
            {
                new Shift(){ Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), PayRate = 12.5m },
                new Shift(){ Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), PayRate = 5.5m },
                new Shift(){ Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), PayRate = 9.5m },
                new Shift(){ Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), PayRate = 6.9m }
            };

            return shifts;
        }
    }
}