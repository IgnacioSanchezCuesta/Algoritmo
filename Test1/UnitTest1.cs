using System;
using System.Diagnostics;

namespace ProyectoSorting
{
    public class SortingArray
    {
        public int[] array;
        public int[] arrayCreciente;
        public int[] arrayDecreciente;
        private static object midpont;

        public SortingArray(int elements, Random random)
        {
            array = new int[elements];
            arrayCreciente = new int[elements];
            arrayDecreciente = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next(100);
            }
            Array.Copy(array, arrayCreciente, elements);
            Array.Sort(arrayCreciente);
            Array.Copy(arrayCreciente, arrayDecreciente, elements);
            Array.Reverse(arrayDecreciente);
        }

        public void Sort(Action<int[]> func)
        {
            Stopwatch time = new Stopwatch();
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);

            Console.WriteLine(func.Method.Name);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Initial: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");

            time.Reset();

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Increasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");

            time.Reset();

            Array.Reverse(temp);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Decreasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");
        }
        public static int[] ShuffleSort(int[] Array)
        {
            Random random = new Random();
            for (int i = Array.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                int temp = Array[i];
                Array[i] = Array[swapIndex];
                Array[swapIndex] = temp;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many elements do you want?");
            int elements = int.Parse(Console.ReadLine());

            Console.WriteLine("What seed do you want to use?");
            int seed = int.Parse(Console.ReadLine());

            Random random = new Random(seed);
            SortingArray array = new SortingArray(elements, random);
            Shuffle();
        }
    }
}

