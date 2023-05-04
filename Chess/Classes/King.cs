using System;

namespace Chess.Classes
{
    internal class King : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }

        public King(Position position, Colour colour)
        {
            Position = position;
            Colour = colour;
        }

        public bool Capture(IPiece targetPiece)
        {
            // Kings cannot capture other pieces, so return false
            return false;
        }

        public bool Move(Position targetPosition, IPiece[,] pieces)
        {
            int rowDiff = Math.Abs(targetPosition.Row - Position.Row);
            int colDiff = Math.Abs(targetPosition.Col - Position.Col);
            if (rowDiff <= 1 && colDiff <= 1)
            {
                // The target square is adjacent to the current square
                Position = targetPosition;
                return true;
            }
            else
            {
                // The target square is not adjacent to the current square
                return false;
            }
        }
    }
}
