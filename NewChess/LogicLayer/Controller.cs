using ChessBoardAssets;

namespace LogicLayer
{
    public class Controller
    {

        public void GetPossibleMoves(Piece piece, int X, int Y)
        {
            switch (piece)
            {
                case Pawn:
                    GetMovesPawn(X, Y);
                    break;
                case Knight:
                    GetMovesKnight(X, Y);
                    break;
                case Rook:
                    GetMovesRook(X, Y);
                    break;
                case Bishop:
                    GetMovesBishop(X, Y);
                    break;
                case King:
                    GetMovesKing(X, Y);
                    break;
                case Queen:
                    GetMovesQueen(X, Y);
                    break;
            }

            //returns the highlighted squares

            //the program then looks at these highlighted squares and moves there
        }



        private void GetMovesPawn(int X, int Y)
        {
            if (Coordinates.IsEmpty(X, Y + 1) == true)
            {
                //add (x,y+1) to output
                if (Y == 6)
                {
                    if (Coordinates.IsEmpty(X, Y + 2) == true)
                    {
                        //add (x,y+1) to output

                    }
                }
            }
            else if (Coordinates.IsEmpty(X + 1, Y + 1) == false)
            {
                //add x+1 y+1 to output
            }
            else if (Coordinates.IsEmpty(X - 1, Y + 1) == false)
            {
                //add x-1, y+1
            }

        }

        private void GetMovesRook(int X, int Y)
        {
            bool ExitLoop = false;
            //checking moves from the left
            for (int i = X - 1; ExitLoop == false; i--)
            {
                if (Coordinates.IsEmpty(i, Y) == true)
                {
                    //add the coordinate
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from the right

            ExitLoop = false;

            for (int i = X + 1; ExitLoop == false; i++)
            {
                if (Coordinates.IsEmpty(i, Y) == true)
                {
                    //add the coordinate
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from above
            ExitLoop = false;

            for (int i = Y + 1; ExitLoop == false; i++)
            {
                if (Coordinates.IsEmpty(X, i) == true)
                {
                    //add the coordinate
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //checking moves from below

            for (int i = Y - 1; ExitLoop == false; i--)
            {
                if (Coordinates.IsEmpty(X, i) == true)
                {
                    //add the coordinate
                }
                else
                {
                    ExitLoop = true;
                }
            }

            //return all the moves

        }
        private void GetMovesKing(int X, int Y)
        {
            //move right up and down -  from the white side perspective
            //so for example from the black perspective, up would be down, down would be up etc

            //right = x+1
            //left = x-1
            //up y-1
            //down y+1

            //up and down
            if (Coordinates.IsEmpty(X, Y - 1) == true) { int up; }
            if (Coordinates.IsEmpty(X, Y + 1) == true) { int down; }

            //left and right
            if (Coordinates.IsEmpty(X + 1, Y) == true) { int right; }
            if (Coordinates.IsEmpty(X - 1, Y) == true) { int left; }

            //left up
            if (Coordinates.IsEmpty(X - 1, Y - 1) == true) { int left_up; }

            //left down
            if (Coordinates.IsEmpty(X - 1, Y + 1) == true) { int left_down; }

            //right up
            if (Coordinates.IsEmpty(X + 1, Y - 1) == true) { int right_up; }

            //right down
            if (Coordinates.IsEmpty(X + 1, Y + 1) == true) { int right_down; }
        }

        private void GetMovesBishop(int X, int Y)
        {
            bool ExitLoop = false;

            //right down

            for (int x = X + 1, y = Y + 1; ExitLoop == false; x++, y++)
            {
                if (Coordinates.IsEmpty(x, y) == true) { int right_down; }
                else
                {
                    ExitLoop = true;
                }
            }

            //right up
            ExitLoop = false;

            for (int x = X + 1, y = Y - 1; ExitLoop == false; x++, y--)
            {
                if (Coordinates.IsEmpty(x, y) == true) { int left_down; }
                else
                {
                    ExitLoop = true;
                }
            }


            //left up
            ExitLoop = false;

            for (int x = X - 1, y = Y - 1; ExitLoop == false; x--, y--)
            {
                if (Coordinates.IsEmpty(x, y) == true) { int left_down; }
                else
                {
                    ExitLoop = true;
                }
            }

            //left down
            ExitLoop = false;

            for (int x = X - 1, y = Y + 1; ExitLoop == false; x--, y++)
            {
                if (Coordinates.IsEmpty(x, y) == true) { int left_down; }
                else
                {
                    ExitLoop = true;
                }
            }
        }

        private void GetMovesKnight(int X, int Y)
        {
            //http://www.chesscorner.com/tutorial/basic/knight/knight.htm

            //up left

            if (Coordinates.IsEmpty(X - 1, Y - 2) == true) { int up_left; }

            //y decreases by 2
            //x decreases by 1

            //up right

            if (Coordinates.IsEmpty(X + 1, Y - 2) == true) { int up_right; }

            //y decreases by 2
            //x increases by 1


            //down left

            if (Coordinates.IsEmpty(X - 1, Y + 2) == true) { int down_left; }


            //y increases by 2
            //x decreases by 1

            //down right

            if (Coordinates.IsEmpty(X + 1, Y + 2) == true) { int down_left; }


            //y increases by 2
            //x incrases by 1


            //left up

            if (Coordinates.IsEmpty(X - 2, Y - 1) == true) { int left_up; }

            //x decreases by 2
            //y decreases by 1

            //left down

            if (Coordinates.IsEmpty(X - 2, Y + 1) == true) { int left_down; }


            //x decreases by 2
            //y increases by 1

            //right up
            if (Coordinates.IsEmpty(X + 2, Y - 1) == true) { int right_up; }
            //x increases by 2
            //y decreases by 1

            //right down
            if (Coordinates.IsEmpty(X + 2, Y + 1) == true) { int right_up; }
            //x increases by 2
            //y increases by 1


        }


        private void GetMovesQueen(int X, int Y)
        {
            GetMovesBishop(X, Y);

            GetMovesRook(X, Y);
        }


    }
}
