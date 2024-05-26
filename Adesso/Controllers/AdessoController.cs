using Adesso.Business;
using Adesso.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AdessoController : ControllerBase {

        private readonly IWorldLeagueOperation worldLeagueOperation;

        public AdessoController(IWorldLeagueOperation _worldLeagueOperation) {
            worldLeagueOperation = _worldLeagueOperation;
        }

        [HttpPost]
        public List<GroupDto> Get([FromQuery] string fullName, [FromQuery] int groupNumber) {
            return worldLeagueOperation.SetGroup(fullName,groupNumber);
        }
    }
}
