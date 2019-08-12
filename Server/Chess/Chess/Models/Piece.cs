using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Models
{
    public abstract class Piece
    {
        protected IList<Rule> Rules;

        public abstract string ImgName { get; }

        public abstract void InitializeRules();

        public bool IsValidMovement(Movement move) 
        {
            return Rules.Any(r => r.IsValidMove(move));
        }
    }
}
