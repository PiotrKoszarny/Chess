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

        public IEnumerable<FieldPosition> GetAvailableMoves(MoveVM move, int boardSize)
        {
            var available = new List<FieldPosition>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    move.Move.EndX = i;
                    move.Move.EndY = j;
                    if (IsvalidMove(move))
                    {
                        available.Add(new FieldPosition
                        {
                            PositionX = move.Move.EndX,
                            PositionY = move.Move.EndY
                        });
                    }
                }
            }
            return available;
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