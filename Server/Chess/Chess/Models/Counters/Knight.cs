using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Models.Counters
{
    public class Knight : Piece
    {
        private readonly string _imgName = "knight.png";

        public Knight()
        {
            Rules = new List<Rule>();
            InitializeRules();
        }

        public override string ImgName { get { return _imgName; } }

        public override void InitializeRules()
        {
            Rules.Add(new Rule(
                        m => m.EndX == m.StartX + 1,
                        m => m.EndY == m.StartY + 2
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX - 1,
                        m => m.EndY == m.StartY + 2
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX - 1,
                        m => m.EndY == m.StartY - 2
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX + 1,
                        m => m.EndY == m.StartY - 2
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX + 2,
                        m => m.EndY == m.StartY + 1
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX + 2,
                        m => m.EndY == m.StartY - 1
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX - 2,
                        m => m.EndY == m.StartY + 1
                        ));

            Rules.Add(new Rule(
                        m => m.EndX == m.StartX - 2,
                        m => m.EndY == m.StartY - 1
                        ));
        }
    }
}
