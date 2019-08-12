using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Models.Counters
{
    public class Queen : Piece
    {
        private readonly string _imgName = "queen.png";

        public Queen()
        {
            Rules = new List<Rule>();
            InitializeRules();
        }

        public override string ImgName { get { return _imgName; } }

        public override void InitializeRules()
        {
            Rules.Add(new Rule(
                        m => m.StartX - m.EndX == m.StartY - m.EndY
                      ));

            Rules.Add(new Rule(
                      m => m.StartX - m.EndX == -(m.StartY - m.EndY)
                      ));

            Rules.Add(new Rule(
                       m => m.EndX == m.StartX
                       ));

            Rules.Add(new Rule(
                        m => m.EndY == m.StartY
                        ));
        }
    }
}
