using System;

namespace Algorithms_LinearSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorting s = new Sorting();
            timeTest t = new timeTest();

            t.Test(s.Bucket, "Bucket");

            t.Test(s.ByCounting, "ByCounting");

            t.Test(s.Radix, "Radix");


        }
    }
}
