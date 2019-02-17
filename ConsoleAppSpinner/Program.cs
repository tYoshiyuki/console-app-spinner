using System;
using System.Threading;

namespace ConsoleAppSpinner
{
    class Program
    {
        static void Main(string[] args)
        {
            SpinAnimation.Start(100);
            Console.WriteLine("Hello World");
            Thread.Sleep(5000);
            SpinAnimation.Stop();

            SpinAnimation.Start(100);
            Console.WriteLine("Hello World");
            Thread.Sleep(5000);
            SpinAnimation.Stop();

            SpinAnimation.Start(100);
            Console.WriteLine("Hello World");
            Thread.Sleep(5000);
            SpinAnimation.Stop();
        }
    }
}
