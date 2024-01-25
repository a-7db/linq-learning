using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeData
{
    public static class Helper
    {
        public static void Print<T>(this IEnumerable<T> source, string title)
        {
            if (source == null)
                return;
            Console.WriteLine();
            Console.WriteLine("┌───────────────────────────────────────────────────────┐");
            Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
            Console.WriteLine("└───────────────────────────────────────────────────────┘");
            Console.WriteLine();
            foreach (var item in source)
                Console.WriteLine(item);
        }

        public static IEnumerable<Employee> Fillter(this IEnumerable<Employee> source, Func<Employee, bool> func)
        {
            foreach (Employee emp in source)
            {
                if (func(emp))
                {
                    yield return emp;
                }
            }
        }
    }
}
