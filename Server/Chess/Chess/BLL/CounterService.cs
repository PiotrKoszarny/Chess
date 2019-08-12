using Chess.Models;
using Chess.Models.Counters;
using System;
using System.Collections.Generic;

namespace Chess.BLL
{
    public class CounterService : ICounterService
    {
        public bool IsvalidMove(MoveVM move)
        {
            Piece piece = GetCounter(move.Counter);
            return piece.IsValidMovement(move.Move);
        }

        public IEnumerable<CounterVM> GetCounters()
        {
            var counters = new List<CounterVM>();

            foreach (Counter item in Enum.GetValues(typeof(Counter)))
            {
                var counter = GetCounter(item);
                counters.Add(new CounterVM
                {
                    Counter = item,
                    ImgName = counter.ImgName
                });
            }
            return counters;
        }

        private Piece GetCounter(Counter counter)
        {
            switch (counter)
            {
                case Counter.Knight:
                    {
                        return new Knight();
                    }
                case Counter.Queen:
                    {
                        return new Queen();
                    }
                default:
                    return null;
            }
        }
    }
}