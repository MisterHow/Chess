using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    internal class Knight : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }

        public Knight(Position position, Colour colour)
        {
            Position = position;
            Colour = colour;
        }
        
        public bool Capture(IPiece targetPiece)
        {
            if(!IsValidCapture(targetPiece))
                return false;

            Position = targetPiece.Position;
            return true;
        }

        public bool Move(Position targetPosition, IPiece[,] pieces)
        {
            if (!IsValidMove(targetPosition))
                return false;
                        
            Position = targetPosition;
            return true;
        }

        public bool IsValidMove(Position targetPosition)
        {
            int rowDistance = Math.Abs(targetPosition.Row - Position.Row);
            int colDistance = Math.Abs(targetPosition.Col - Position.Col);

            if((rowDistance == 1 && colDistance == 2) || (rowDistance == 2 && colDistance == 1))
            {
                return true;
            }
            return false;
        }

        public bool IsValidCapture(IPiece targetPiece)
        {
            return IsValidMove(targetPiece.Position) && targetPiece.Colour != Colour;
        }
    }
}
