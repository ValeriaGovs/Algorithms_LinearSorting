using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_LinearSorting
{
    public class Sorting
    {
        
        public void Bucket(int[] mass)
        {
            int max = 0;
            int count = mass.Length;

            //Create buckets
            List<int>[] buckets = new List<int>[count];

            for (int i=0; i< count; i++) 
            { 
                if (max<mass[i])
                    max = mass[i];

                buckets[i] = new List<int>();
            }


            for (int i = 0; i < count; i++)
            {
                int weight = mass[i] * count / (max + 1);
                addToBacket( buckets[weight], mass[i]);
            }


            //our visual sorting check
            /*
            foreach (var buckes in buckets)     
            {
                foreach (var element in buckes)
                { Console.WriteLine(element); }
            }
            */
            

        }

        private void addToBacket(List<int> list, int v)
        {
            if (list.Count==0)
            {
                list.Add(v);
            }
            else 
            {
                int counter;
                // looking for a place to insert an element
                for (counter = 0; counter < list.Count; counter++)
                {
                    if (list[counter] > v)
                        break;
                }
                list.Insert(counter, v);
            }
        }


        public void ByCounting(int[] sourceArray)
        {

            int count = sourceArray.Length;
            int max = sourceArray.Max();
            int currentElement;


            int[]arrayСounting = new int[max+1];
            int[]arraySorted = new int [count];

            //number of repetitions
            foreach (var i in sourceArray)
            {
                arrayСounting[i] = arrayСounting[i] + 1;
            }
            //accumulated summ
            for (int i = 1; i <= max; i++)
            {
                arrayСounting[i] = arrayСounting[i-1] + arrayСounting[i];
            }

            //sorted list
            for (int i = count - 1; i >=0; i--)
            {
                currentElement = sourceArray[i];
                arrayСounting[currentElement] = arrayСounting[currentElement] - 1;
                arraySorted[arrayСounting[currentElement]] = currentElement;
            }

            /*
            //our visual sorting check
            foreach (var i in arraySorted)     
            {
                Console.WriteLine(i); 
            }
            */



        }


        public void Radix(int[] sourceArray)
        {

            sourceArray = Radix_sort(sourceArray,1);
            sourceArray = Radix_sort(sourceArray, 10);
            sourceArray = Radix_sort(sourceArray, 100);


            //our visual sorting check
            foreach (var i in sourceArray)     
            {
                Console.WriteLine(i); 
            }


        }

        private int[] Radix_sort(int[] sourceArray, int divider)
        {

            int max = sourceArray.Length;
            int[] arrayСounting = new int[10];
            int[] arraySorted = new int[max];

            int x;
            int currentElement;

            // first pass by units
            foreach (var i in sourceArray)
            {
                x = i/ divider % 10;
                arrayСounting[x] = arrayСounting[x] + 1;
            }
            //accumulated summ
            for (int i = 1; i < 10; i++)
            {
                arrayСounting[i] = arrayСounting[i - 1] + arrayСounting[i];
            }
            //sorted list
            for (int i = max - 1; i >= 0; i--)
            {
                currentElement = sourceArray[i] / divider %10;

                arrayСounting[currentElement] = arrayСounting[currentElement] - 1;
                arraySorted[arrayСounting[currentElement]] = sourceArray[i];
            }
            return arraySorted;
        }

    }
}
