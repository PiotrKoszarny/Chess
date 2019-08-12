using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.BLL;
using Chess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly ICounterService _counterService;

        public ChessController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CounterVM>> GetCounters()
        {
            return Ok(_counterService.GetCounters());
        }

        [HttpPost]
        public ActionResult<bool> IsPossibleMove(MoveVM move)
        {
            return Ok(_counterService.IsvalidMove(move));
        }
    }
}
