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

        [HttpGet]
        [Route("{counter}/{startX}/{startY}/{boardSize}")]
        public ActionResult<IEnumerable<FieldPosition>> GetAvailableMoves(int counter, int startX, int startY, int boardSize)
        {
            var move = new MoveVM
            {
                Counter = (Counter)counter,
                Move = new Movement
                {
                    StartX = startX,
                    StartY = startY
                }
            };
            return Ok(_counterService.GetAvailableMoves(move, boardSize));
        }

        [HttpPost]
        public ActionResult<bool> IsPossibleMove(MoveVM move)
        {
            return Ok(_counterService.IsvalidMove(move));
        }
    }
}
