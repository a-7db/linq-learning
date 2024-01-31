using FakeData;

namespace CAAggregateOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunAggregate01();
            //RunAggregate02();
            //RunAggregate03();
            //RunCount();
            RunStandardAggregate();

            Console.ReadKey();
        }

        private static void RunStandardAggregate()
        {
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            // They'r also can applied the Func<T> Delegate
            var maximum = numbers.Max();
            var minimum = numbers.Min();
            var sum = numbers.Sum();
            var average = numbers.Average();

            Console.WriteLine(average);
        }

        private static void RunCount()
        {
            var employees = Repository.LoadEmployees();

            var countOfMale = employees.Count(x => x.Gender == "male");

            Console.WriteLine(countOfMale);
        }

        private static void RunAggregate03()
        {
            var employees = Repository.LoadEmployees();

            var longestNameLength = employees.Aggregate((longest, next)
                => longest.FirstName.Length > next.FirstName.Length ? longest : next);

            Console.WriteLine(longestNameLength);
        }

        private static void RunAggregate02()
        {
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            //               .Aggregate(seed, Func<T>)
            var sum = numbers.Aggregate(0, (prev, curr) => prev + curr);
            var max = numbers.Aggregate((prev, curr) => prev < curr? curr : prev);

            //  |--> seed is the initial value to start with <--|
            //       ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            Console.WriteLine(max);
        }

        private static void RunAggregate01()
        {
            var friends = new[] { "Mohammed", "Ali", "Mousa", "Ahmed" };

            var aggre = friends.Aggregate((prev, curr) => $"{prev}, {curr}");

            Console.WriteLine(aggre);
        }
    }
}
