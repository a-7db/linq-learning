using FakeData03;

namespace CADataPartitioning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            //RunExample01(employees);
            //RunExample02(employees);
            RunExample03(employees);


            Console.ReadKey();
        }

        private static void RunExample03(IEnumerable<Employee> employees)
        {
            var chunks = employees.Chunk(10).ToList();

            for (int i = 0; i < chunks.Count(); i++)
            {
                chunks[i].Print($"Part {i + 1}");
            }
        }

        private static void RunExample02(IEnumerable<Employee> employees)
        {
            // Take First 10
            var takeFirst = employees.Take(10);

            // Take Last 20
            var TakeLast = employees.TakeLast(20);

            // Take While 
            var TakeWhile = employees.TakeWhile(x => x.Index < 30);

            // Take Between 30 And 40
            var TakeFrom30To40 = employees.Take(40).Skip(29);

            TakeFrom30To40.Print("Take Between 30 And 40 Employees");
        }

        private static void RunExample01(IEnumerable<Employee> employees)
        {
            // Skip First 10
            var skipFirst = employees.Skip(40);

            // Skip Last 20
            var skipLast = employees.SkipLast(20);

            // Skip While 
            var skipWhile = employees.SkipWhile(x => x.Index < 30);

            skipFirst.Print("Skip First 40 Employees");
        }
    }
}
