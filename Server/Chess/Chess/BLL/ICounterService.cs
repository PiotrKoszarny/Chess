using Chess.Models;
using System.Collections.Generic;

namespace Chess.BLL
{
    public interface ICounterService
    {
        bool IsvalidMove(MoveVM move);
        IEnumerable<CounterVM> GetCounters();
    }
}