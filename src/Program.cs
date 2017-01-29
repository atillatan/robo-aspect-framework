using AspectExample.Services;
using System;

namespace AspectExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Example Method Call ////

            PersonService personService = new PersonService();

            var result = personService.Invoke<string>(() => personService.Method1(3));

            Console.ReadKey();
        }
    }
}