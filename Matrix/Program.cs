using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int rows = inputProcedure("[?] Введіть кількість рядків матриці N: ");
            int cols = inputProcedure("[?] Введіть кількість стовпців матриці M: ");
            int[,] matrix = new int[rows, cols];
            genArray2d(matrix, rows, cols, -5, 5);
            Console.WriteLine("[i] Згенерований масив: "); printArray2d(matrix, rows, cols);
        }

        private static void printArray2d(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i,j],2} ");
                }
                Console.Write("\n");
            }
        }

        private static void genArray2d(int[,] arr, int rows, int cols, int randmin, int randmax)
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rand.Next(randmin, randmax);
                }
            }
        }

        private static int inputProcedure(string ctext)
        {
            while (true)
            {
                Console.Write(ctext);
                if (int.TryParse(Console.ReadLine(), out int outval) && outval > 0) return outval;
                else Console.WriteLine("[!] Введіть натуральне число.");
            }
        }
    }
}