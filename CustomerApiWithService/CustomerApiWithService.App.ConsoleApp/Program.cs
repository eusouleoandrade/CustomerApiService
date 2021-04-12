using CustomerApiWithService.Domain.Entities;
using System;

namespace CustomerApiWithService.App.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var customer = new Customer("", "Andrade", "euosuleoandrade@gmail.com", "");

            Console.WriteLine(customer);

            Console.ReadKey();
        }
    }
}
