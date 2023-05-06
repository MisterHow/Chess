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
            Initialise();
        }

        private void Initialise()
        {
            // Initialize black pieces on the bottom row/s
            for (int col = 0; col < 8; col++)
            {
                switch (col)
                {
                    case 0:
                    case 7:
                        pieces[0, col] = new Rook(new Position(0, col), Colour.Black);
                        break;
                    case 1:
                    case 6:
                        pieces[0, col] = new Knight(new Position(0, col), Colour.Black);
                        break;
                    case 2:
                    case 5:
                        pieces[0, col] = new Bishop(new Position(0, col), Colour.Black);
                        break;
                    case 3:
                        pieces[0, col] = new Queen(new Position(0, col), Colour.Black);
                        break;
                    case 4:
                        pieces[0, col] = new King(new Position(0, col), Colour.Black);
                        break;
                }
                pieces[1, col] = new Pawn(new Position(1, col), Colour.Black);
            }

            // Initialize empty squares in the middle of the board
            for (int row = 2; row < 6; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    pieces[row, col] = null;
                }
            }

            // Initialize white pieces on the top row/s
            for (int col = 0; col < 8; col++)
            {
                switch (col)
                {
                    case 0:
                    case 7:
                        pieces[7, col] = new Rook(new Position(7, col), Colour.White);
                        break;
                    case 1:
                    case 6:
                        pieces[7, col] = new Knight(new Position(7, col), Colour.White);
                        break;
                    case 2:
                    case 5:
                        pieces[7, col] = new Bishop(new Position(7, col), Colour.White);
                        break;
                    case 3:
                        pieces[7, col] = new Queen(new Position(7, col), Colour.White);
                        break;
                    case 4:
                        pieces[7, col] = new King(new Position(7, col), Colour.White);
                        break;
                }
                pieces[6, col] = new Pawn(new Position(6, col), Colour.White);
            }

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
