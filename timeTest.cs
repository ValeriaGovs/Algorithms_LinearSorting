using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_LinearSorting
{
    public class timeTest
    {
        public void Test(func f, string funcName)
        {
            Console.WriteLine($" ");
            Console.WriteLine($" ");


            Stopwatch clock = new Stopwatch();

            int count = 0;
            int n_max = 100; // 1_000_000;
            for (int n = 100; n <= n_max; n *= 10)
            {

                //creating an array
                Random r = new Random();
                var unsort = new int[n];
                for (int i = 0; i < n; i++)
                {
                    unsort[i] = r.Next(0, 999);
                }

                clock.Start();

                // our action
                f(unsort);


                Console.Write($" до {n}  {funcName}: {count}");
                clock.Stop();




                TimeSpan ts = clock.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"{elapsedTime} ");
            }
        }
        public delegate void func(int[] m);
    }
}
