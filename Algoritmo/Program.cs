using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSortEarlyExit(int[] array)
        {
            bool ordered = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                ordered = true;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        ordered = false;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                if (ordered)
                    return;
            }
        }
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        public void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = QuickSortPivot(array, left, right);
                QuickSort(array, left, pivot);
                QuickSort(array, pivot + 1, right);
            }
        }
        public int QuickSortPivot(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left >= right)
                {
                    return right;
                }
                else
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    right--; left++;
                }
            }
        }
       
        public void StupidSort(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[swapIndex];
                array[swapIndex] = temp;
            }
         
        }

        public void RadixSort(int[] array)
        {
            int n = array.Length;
            int max = array[0];

            //find largest element in the Array
            for (int i = 1; i < n; i++)
            {
                if (max < array[i])
                    max = array[i];
            }

            //Counting sort is performed based on place. 
            //like ones place, tens place and so on.
            for (int place = 1; max / place > 0; place *= 10)
                countingsort(array, place);
        }
        static void countingsort(int[] array, int place)
        {
            int n = array.Length;
            int[] output = new int[n];

            //range of the number is 0-9 for each place considered.
            int[] freq = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //count number of occurrences in freq array
            for (int i = 0; i < n; i++)
                freq[(array[i] / place) % 10]++;

            //Change count[i] so that count[i] now contains actual 
            //position of this digit in output[] 
            for (int i = 1; i < 10; i++)
                freq[i] += freq[i - 1];

            //Build the output array 
            for (int i = n - 1; i >= 0; i--)
            {
                output[freq[(array[i] / place) % 10] - 1] = array[i];
                freq[(array[i] / place) % 10]--;
            }

            //Copy the output array to the input Array, Now the Array will 
            //contain sorted array based on digit at specified place
            for (int i = 0; i < n; i++)
                array[i] = output[i];
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
                array.Sort(array.BubbleSort);
                array.Sort(array.BubbleSortEarlyExit);
                array.Sort(array.QuickSort);
                array.Sort(array.StupidSort);
                array.Sort(array.RadixSort);
                




            }
        }

    }


