using System;

namespace Chess.Classes
{
    internal class Pawn : IPiece
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }
        public bool HasMoved = false;

        public Pawn(Position position, Colour colour) 
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

            Position = targetPosition;
            HasMoved = true;
            return true;
        }

        public bool IsValidMove(Position targetPosition)
        {
            int direction = (Colour == Colour.White) ? 1 : -1;
            int deltaRow = targetPosition.Row - Position.Row;
            int deltaCol = targetPosition.Col - Position.Col;
            //Pawns can only move forward
            if (deltaCol == 0)
            {
                //Pawns can move two squares on their first move
                if (!HasMoved && deltaRow == 2 * direction)
                {
                    return true;
                }
                //Pawns can move one square forward
                if (deltaRow == direction)
                {
                    return true;
                }
            }
            //Pawns can only capture diagonally adjacent pieces
            else if (deltaCol == 1 && (deltaRow == direction || deltaRow == -direction))
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
