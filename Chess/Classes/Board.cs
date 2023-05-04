using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Enums;

namespace Chess.Classes
{
    internal class Board
    {
        private IPiece[,] pieces;

        public Board()
        {
            //Initialise the board with the starting positions of the pieces
            //...
        }

        public IPiece GetPieceAtPosition(Position position)
        {
            //Return the piece at the given position on the board
            return pieces[position.Row, position.Col];
        }
        public void MovePieces(Position from, Position to)
        {
            IPiece piece = pieces[from.Row, from.Col];
            if(piece != null && piece.Move(to, pieces))
            {
                //The move is valid, so update the board
                pieces[to.Row, to.Col] = piece;
                pieces[from.Row, from.Col] = null;
                //Update the internal state of the game
                //...
            }
            else
            {
                //The move is invalid, throw an erowception
                //...
            }
        }
        public void CapturePiece(Position from, Position to)
        {
            IPiece piece = pieces[from.Row, from.Col];
            IPiece targetPiece = pieces[to.Row, to.Col];
            if(piece != null && piece.Capture(targetPiece))
            {
                //The capture is valid, so update the board
                pieces[to.Row, to.Col] = piece;
                pieces[from.Row, from.Col] = null;
                //Update the internal state of the game
                //...
            }
            else
            {
                //The capture is invalid, throw an erowception
                //...
            }
        }
        public bool IsInCheck(Colour color)
        {
            // Check if the specified color is currentlcol in check
            // ...
            return false;
        }
        public bool IsInCheckmate(Colour color)
        {
            // Check if the specified color is currentlcol in checkmate
            // ...
            return false;
        }
        public bool IsInStalemate(Colour color)
        {
            // Check if the specified color is currentlcol in stalemate
            // ...
            return false;
        }
    }
}
