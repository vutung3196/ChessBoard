namespace ChessBoard // Note: actual namespace depends on the project name.
{
    public static class ChessBoard {
        public static bool KnightChessBoardBackTrackingAlgorithm()
        {
            int[,] solution = new int[Constant.CHESS_BOARD_SIZE, Constant.CHESS_BOARD_SIZE];

            for (int x = 0; x < Constant.CHESS_BOARD_SIZE; x++)
            {
                for (int y = 0; y < Constant.CHESS_BOARD_SIZE; y++)
                {
                    solution[x, y] = -1;
                }
            }

            int[] xCoordinateMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yCoordinateMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            solution[0, 0] = 0;

            if (!RecursiveKnightChessBoard(0, 0, 1, solution, xCoordinateMoves, yCoordinateMoves))
            {
                return false;
            } else
            {
                Console.WriteLine("The solution is: ");
                for (int x = 0; x < Constant.CHESS_BOARD_SIZE; x++)
                {
                    for (int y = 0; y < Constant.CHESS_BOARD_SIZE; y++) 
                        Console.Write(solution[x, y] + " ");
                    Console.WriteLine();
                }
                return true;
            }
        }

        private static bool RecursiveKnightChessBoard(int x, int y, int movingValue, int[, ] solution, int[] xCoordinateMoves, int[] yCoordinateMoves)
        {
            int k, nextXValue, nextYValue;

            // Reaching the end
            if (movingValue == Constant.CHESS_BOARD_SIZE * Constant.CHESS_BOARD_SIZE)
            {
                return true;
            }
            for (k = 0; k < Constant.CHESS_BOARD_SIZE; k++)
            {
                nextXValue = x + xCoordinateMoves[k];
                nextYValue = y + yCoordinateMoves[k];
                if (IsValid(nextXValue, nextYValue, solution))
                {
                    solution[nextXValue, nextYValue] = movingValue;
                    if (RecursiveKnightChessBoard(nextXValue, nextYValue, movingValue + 1, solution, xCoordinateMoves, yCoordinateMoves))
                    {
                        return true;
                    } else
                    {
                        solution[nextXValue, nextYValue] = -1;
                    }
                }
            }
            return false; 
        }
        
        private static bool IsValid(int x, int y, int[, ] solution)
        {
            if (x >= 0 && x < Constant.CHESS_BOARD_SIZE && y >= 0 && y < Constant.CHESS_BOARD_SIZE && solution[x, y] == -1)
            {
                return true;
            }
            return false;
        }
    }
}