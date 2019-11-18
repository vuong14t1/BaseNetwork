using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
            Console.WriteLine("Hello world " + Encoding.ASCII.GetString(bytes));
            Console.ReadLine();
        }
    }
}
