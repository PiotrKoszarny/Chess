using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Rule
    {
        private readonly Predicate<Movement>[] _movements;

        public Rule(params Predicate<Movement>[] movements)
        {
            _movements = movements;
        }

        public bool IsValidMove(Movement move)
        {
            return !_movements.Any(m => !m(move));
        }
    }
}
