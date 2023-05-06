using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Queen : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }

        public Queen(Position position, Colour colour)
        {
            Position = position;
            Colour = colour;
        }

        public bool Capture(IPiece targetPiece)
        {
            if (!IsValidCapture(targetPiece))
                return false;

            Position = targetPiece.Position;
            return true;
        }

        public bool Move(Position targetPosition, IPiece[,] pieces)
        {
            if (!IsValidMove(targetPosition))
                return false;

            int deltaRow = targetPosition.Row - Position.Row;
            int deltaCol = targetPosition.Col - Position.Col;

            // Check if there are any pieces between the starting and ending positions
            int stepRow = Math.Sign(deltaRow);
            int stepCol = Math.Sign(deltaCol);
            int row = Position.Row + stepRow;
            int col = Position.Col + stepCol;

            while (row != targetPosition.Row || col != targetPosition.Col)
            {
                if (pieces[row, col] != null)
                {
                    return false;
                }
                row += stepRow;
                col += stepCol;
            }

            // Move the queen to the destination position
            Position = targetPosition;
            return true;
        }

        public bool IsValidMove(Position targetPosition)
        {
            int rowDistance = Math.Abs(targetPosition.Row - Position.Row);
            int colDistance = Math.Abs(targetPosition.Col - Position.Col);

            return rowDistance == colDistance || (Position.Row == targetPosition.Row ^ Position.Col == targetPosition.Col); ;
        }

        public bool IsValidCapture(IPiece targetPiece)
        {
            return IsValidMove(targetPiece.Position) && targetPiece.Colour != Colour;
        }
    }
}
