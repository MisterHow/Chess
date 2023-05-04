using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    internal class Bishop : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }

        public Bishop(Position position, Colour colour)
        {
            Position = position;
            Colour = colour;
        }

        public bool Capture(IPiece targetPiece)
        {
            if (!IsValidCapture(targetPiece))
            {
                return false;
            }

            Position = targetPiece.Position;
            return true;
        }

        public bool Move(Position targetPosition, IPiece[,] pieces)
        {
            if (!IsValidMove(targetPosition))
                return false;
            
            int rowDirection = Math.Sign(targetPosition.Row - Position.Row);
            int colDirection = Math.Sign(targetPosition.Col - Position.Col);

            int currentRow = Position.Row + rowDirection;
            int currentCol = Position.Col + colDirection;

            while (currentRow != targetPosition.Row && currentCol != targetPosition.Col)
            {
                if (pieces[currentRow, currentCol] != null)
                {
                    return false;
                }

                currentRow += rowDirection;
                currentCol += colDirection;
            }

            Position = targetPosition;
            return true;
        }

        public bool IsValidMove(Position targetPosition)
        {
            int rowDistance = Math.Abs(targetPosition.Row - Position.Row);
            int colDistance = Math.Abs(targetPosition.Col - Position.Col);

            return rowDistance == colDistance;
        }

        public bool IsValidCapture(IPiece targetPiece)
        {
            return IsValidMove(targetPiece.Position) && targetPiece.Colour != Colour;
        }
    }
}
