using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    struct Position
    {
        public int Row;
        public int Col;
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
    internal interface IPiece
    {
        Position Position { get; set; }
        Colour Colour { get; set; }
        bool Move(Position targetPosition, IPiece[,] pieces);
        bool Capture(IPiece targetPiece);
    }
}
