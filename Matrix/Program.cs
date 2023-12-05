using System.Text;
namespace Matrix
{
    class Program
    {
        private static int numOfPositive(int[,] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > 0) counter++;
            return counter;
        }
        private static int maxRepeatedNum(int[,] arr)
        {
            int counter = 0;
            int[] buffer = new int[arr.GetLength(0) * arr.GetLength(1)];  
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    buffer[counter] = arr[i, j];
                    counter++;
                }
            }
            shellSort(buffer);
            for (int i = 0; i+1 < arr.GetLength(0) * arr.GetLength(1); i++)
            {
                Console.Write($"");
                if (buffer[arr.GetLength(0) * arr.GetLength(1) - 1 - i] == buffer[arr.GetLength(0) * arr.GetLength(1) - 2 - i]) return buffer[arr.GetLength(0) * arr.GetLength(1) - 1 - i];
            }
            return -999;
        }
        private static int noZeroRows(int[,] arr)
        {
            int counter = arr.GetLength(0);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
        private static int zeroCols(int[,] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
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
        private static int longestSeries(int[,] arr)
        {
            int maxcount = 0;
            int currcount = 0;
            int longestrow = -999;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = j + 1; k < arr.GetLength(1); k++)
                    {
                        if (arr[i, k] == arr[i, j]) currcount++;
                    }
                }
                if (currcount > maxcount)
                {
                    longestrow = i;
                    maxcount = currcount;
                }
                currcount = 0;
            }
            return longestrow;
        }
        private static int multRowsNoNeg(int[,] arr)
        {
            int dob = 1, flag = 0, count = 0, n = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < 0) {
                        flag = 1; break;
                    }
                }
                if (flag == 0)
                {
                    if (n == 0)
                    {
                        Console.Write("\n");
                        n++;
                    }
                    count++;
                    for (int k = 0; k < arr.GetLength(1); k++)
                        dob *= arr[i, k];
                    Console.WriteLine($"    - Добуток елементів в рядку матриці {i + 1}: {dob}");
                    dob = 1;
                }
                flag = 0;
            }
            return (count == 0) ? 1 : 0;
        }

        private static int sumColsNoNeg(int[,] arr)
        {
            int sum = 0, flag = 0, count = 0, n = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < 0)
                    {
                        flag = 1; break;
                    }
                }
                if (flag == 0)
                {
                    count++;
                    for (int k = 0; k < arr.GetLength(0); k++)
                        sum += arr[k, i];
                    Console.Write($"\n    - Сума елементів в стовпці матриці {i + 1}: {sum}");
                    sum = 0;
                }
                flag = 0;
            }
            if (count > 0) Console.Write("\n");
            return (count == 0) ? 1 : 0;
        }
        private static int sumColsNeg(int[,] arr)
        {
            int sum = 0, flag = 0, count = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < 0)
                    {
                        flag = 1; break;
                    }
                }
                if (flag == 1)
                {
                    count++;
                    for (int k = 0; k < arr.GetLength(0); k++)
                        sum += arr[k, i];
                    Console.Write($"\n    - Сума елементів в стовпці {i + 1}: {sum}");
                    sum = 0;
                }
                flag = 0;
            }
            return (count == 0) ? 1 : 0;
        }
        private static int maxSumDiagParallMain(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int sum = 0; int max = int.MinValue;
            int flag = 0;

            for (int k = 0; k < cols; k++)
            {
                for (int j = 1, i = 0; j < cols && i < Math.Min(rows, cols); i++, j++)
                {
                    if (j + k >= cols) continue;
                    sum += arr[i, j + k];
                    flag++;
                }
                if (sum > max && flag > 0) max = sum;
                sum = 0; flag = 0;
            }

            for (int k = 0; k < rows; k++)
            {
                for (int j = 1, i = 0; j < rows && i < Math.Min(rows, cols); i++, j++)
                {
                    if (j + k >= rows) continue;
                    sum += arr[j + k, i];
                    flag++;
                }
                if (sum > max && flag > 0) max = sum;
                sum = 0; flag = 0;
            }

            return max;
        }
        private static int minSumAbsDiagParallMain(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int sum = 0; int min = int.MaxValue;
            int flag = 0;

            for (int k = 0; k < cols; k++)
            {
                for (int j = 1, i = 0; j < cols && i < Math.Min(rows, cols); i++, j++)
                {
                    if (j + k >= cols) continue;
                    sum += Math.Abs(arr[i, j + k]);
                    flag++;
                }
                if (sum < min && flag > 0) min = sum;
                sum = 0; flag = 0;
            }

            for (int k = 0; k < rows; k++)
            {
                for (int j = 1, i = 0; j < rows && i < Math.Min(rows, cols); i++, j++)
                {
                    if (j + k >= rows) continue;
                    sum += Math.Abs(arr[j + k, i]);
                    flag++;
                }
                if (sum < min && flag > 0) min = sum;
                sum = 0; flag = 0;
            }

            return min;
        }
        private static void transposeMatrix(int[,] arr, int[,] tarr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    tarr[j, i] = arr[i, j];
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int rows = inputProcedure("[?] Введіть кількість рядків матриці N: ");
            int cols = inputProcedure("[?] Введіть кількість стовпців матриці M: ");
            int[,] matrix = new int[rows, cols];
            int[,] tmatrix = new int[cols, rows];
            int[,] dmatrix = new int[rows, cols];
            genArray2d(matrix, rows, cols, -5, 5); swapDiagonals(matrix, dmatrix);
            Console.WriteLine("[i] Згенерований масив: "); printArray2d(matrix);
            Console.WriteLine($"[i] Кількість додатних елементів: {numOfPositive(matrix)}");
            Console.Write($"[i] Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: ");
            int maxRepeatedNumVAL = maxRepeatedNum(matrix); Console.WriteLine((maxRepeatedNumVAL) == -999 ? "[відсутнє]" : maxRepeatedNumVAL);
            Console.WriteLine($"[i] Кількість рядків, які не містять жодного нульового елемента: {noZeroRows(matrix)}");
            Console.WriteLine($"[i] Кількість стовпців, які містять хоча б один нульовий елемент: {zeroCols(matrix)}");
            Console.Write($"[i] Номер рядка матриці, в якому знаходиться найдовша серія однакових елементів: ");
            int longestSeriesVAL = longestSeries(matrix); Console.WriteLine((longestSeriesVAL) == -999 ? "[відсутній]" : longestSeriesVAL + 1);
            Console.Write($"[i] Добуток елементів в тих рядках, які не містять від’ємних елементів: ");
            Console.Write((multRowsNoNeg(matrix) == 1) ? "[відсутній]\n" : "");
            Console.Write($"[i] Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: ");
            int maxSumDiagParallMainVAL = maxSumDiagParallMain(matrix); Console.WriteLine((maxSumDiagParallMainVAL) == int.MinValue ? "[відсутній]" : maxSumDiagParallMainVAL);
            Console.Write($"[i] Сума елементів в тих стовпцях, які не містять від’ємних елементів: ");
            Console.Write((sumColsNoNeg(matrix) == 1) ? "[відсутня]\n" : "");
            Console.Write($"[i] Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: ");
            int minSumAbsDiagParallMainVAL = minSumAbsDiagParallMain(dmatrix); Console.WriteLine((minSumAbsDiagParallMainVAL) == int.MaxValue ? "[відсутній]" : minSumAbsDiagParallMainVAL);
            Console.Write($"[i] Суму елементів в тих стовпцях, які містять хоча б один від’ємний елемент: ");
            Console.Write((sumColsNeg(matrix) == 1) ? "[відсутня]" : "");
            Console.WriteLine($"\n[i] Транспонована матриця: "); transposeMatrix(matrix, tmatrix);
            printArray2d(tmatrix);
        }
        private static void printArray2d(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
        private static void swapDiagonals(int[,] arr, int[,] darr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    darr[i, j] = arr[i, j];
                }
            }
            for (int i = 0; i < darr.GetLength(0); i++)
            {
                int x = 0;
                int y = darr.GetLength(1) - 1;
                while (x < y)
                {
                    int temp = darr[i, x];
                    darr[i, x] = darr[i, y];
                    darr[i, y] = temp;
                    x++;
                    y--;
                }
            }
        }
        private static void shellSort(int[] arr)
        {
            int c, len = arr.GetLength(0), step = len / 2;
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