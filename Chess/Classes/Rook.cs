using System;

namespace Chess.Classes
{
    internal class Rook : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }

        public Rook(Position position, Colour colour)
        {
            Position = position;
            Colour = colour;
        }

        public bool Capture(IPiece targetPiece)
        {
            if (!IsValidCapture(targetPiece))
                return false;

            // Rooks capture by moving to the same rank or file as the other piece
            int deltaRow = targetPiece.Position.Row - Position.Row;
            int deltaCol = targetPiece.Position.Col - Position.Col;
            if (deltaRow != 0 && deltaCol != 0)
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
            // Move the rook to the destination position
            Position = targetPosition;
            return true;
        }

        public bool IsValidMove(Position targetPosition)
        {
            return (Position.Row == targetPosition.Row ^ Position.Col == targetPosition.Col);
        }

        public bool IsValidCapture(IPiece targetPiece)
        {
            return IsValidMove(targetPiece.Position) && targetPiece.Colour != Colour;
        }
    }
}
