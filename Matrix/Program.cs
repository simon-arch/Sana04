using System.Text;
namespace Matrix
{
    class Program
    {
        private static int numOfPositive(int[,] arr, int rows, int cols)
        {
            int counter = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (arr[i, j] > 0) counter++;
            return counter;
        }
        private static int maxRepeatedNum(int[,] arr, int rows, int cols)
        {
            int counter = 0;
            int[] buffer = new int[rows*cols];  
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buffer[counter] = arr[i, j];
                    counter++;
                }
            }
            shellSort(buffer, rows*cols);
            for (int i = 0; i+1 < rows*cols; i++)
            {
                Console.Write($"");
                if (buffer[rows * cols - 1 - i] == buffer[rows * cols - 2 - i]) return buffer[rows * cols - 1 - i];
            }
            return -999;
        }
        private static int noZeroRows(int[,] arr, int rows, int cols)
        {
            int counter = rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        counter--;
                        break;
                    }
                }
            }
            return counter;
        }
        private static int zeroCols(int[,] arr, int rows, int cols)
        {
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[j, i] == 0)
                    {
                        counter++;
                        break;
                    }
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int rows = inputProcedure("[?] Введіть кількість рядків матриці N: ");
            int cols = inputProcedure("[?] Введіть кількість стовпців матриці M: ");
            int[,] matrix = new int[rows, cols];
            genArray2d(matrix, rows, cols, -5, 5);
            Console.WriteLine("[i] Згенерований масив: "); printArray2d(matrix, rows, cols);
            Console.WriteLine($"[i] Кількість додатніх елементів матриці: {numOfPositive(matrix, rows, cols)}");
            int maxRepNum = maxRepeatedNum(matrix, rows, cols);
            Console.Write("[i] Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: ");
            Console.Write((maxRepNum == -999) ? "[відсутнє]" : maxRepNum);
            Console.WriteLine($"\n[i] Кількість рядків матриці, які не містять жодного нульового елемента: {noZeroRows(matrix, rows, cols)}");
            Console.WriteLine($"[i] Кількість стовпців матриці, які містять хоча б один нульовий елемент: {zeroCols(matrix, rows, cols)}");
        }
        private static void printArray2d(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{matrix[i,j],2} ");
                Console.Write("\n");
            }
        }
        private static void genArray2d(int[,] arr, int rows, int cols, int randmin, int randmax)
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    arr[i, j] = rand.Next(randmin, randmax+1);
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
        private static void shellSort(int[] arr, int len)
        {
            int c, step = len / 2;
            while (step > 0)
            {
                for (int i = 0; i < (len - step); i++)
                {
                    int j = i;
                    while (j >= 0 && arr[j] > arr[j + step])
                    {
                        c = arr[j];
                        arr[j] = arr[j + step];
                        arr[j + step] = c;
                        j--;
                    }
                }
                step /= 2;
            }
        }
    }
}