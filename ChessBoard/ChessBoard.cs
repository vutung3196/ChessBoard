namespace ChessBoard // Note: actual namespace depends on the project name.
{
    public static class ChessBoard {
        public static bool KnightChessBoardBackTrackingAlgorithm()
        {
            int[,] solution = new int[Constant.SIZE, Constant.SIZE];

            for (int x = 0; x < Constant.SIZE; x++)
            {
                for (int y = 0; y < Constant.SIZE; y++)
                {
                    solution[x, y] = -1;
                }
            }

            int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

            solution[0, 0] = 0;

            if (!RecursiveKnightChessBoard(0, 0, 1, solution, xMove, yMove))
            {
                return false;
            } else
            {
                Console.WriteLine("The solution is: ");
                for (int x = 0; x < Constant.SIZE; x++)
                {
                    for (int y = 0; y < Constant.SIZE; y++)
                        Console.Write(solution[x, y] + " ");
                    Console.WriteLine();
                }
            }

            return true;
        }

        private static bool RecursiveKnightChessBoard(int x, int y, int movei, int[, ] solution, int[] xMove, int[] yMove)
        {
            int k, next_x, next_y;
            if (movei == Constant.SIZE * Constant.SIZE)
            {
                return true;
            }
            for (k = 0; k < Constant.SIZE; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if (IsValid(next_x, next_y, solution))
                {
                    solution[next_x, next_y] = movei;
                    if (RecursiveKnightChessBoard(next_x, next_y, movei + 1, solution, xMove, yMove))
                    {
                        return true;
                    } else
                    {
                        solution[next_x, next_y] = -1;
                    }
                }
            }
            return false; 
        }
        
        private static bool IsValid(int x, int y, int[, ] solution)
        {
            if (x >= 0 && x < Constant.SIZE && y >= 0 && y < Constant.SIZE && solution[x, y] == -1)
            {
                return true;
            }
            return false;
        }
    }
}