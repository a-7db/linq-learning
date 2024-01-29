using FakeData;

namespace CAGenerationOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DefaultIfEmpty();
            //RangeOperation();
            RepeatOperation();

            Console.ReadKey();
        }

        private static void RepeatOperation()
        {
            var employee = Enumerable.Empty<Employee>();
            var empty = employee.DefaultIfEmpty(Employee.Default01);

            var emps = Enumerable.Repeat(empty, 5);

            foreach (var emp in emps)
            {
                foreach(var d in emp)
                {
                    Console.WriteLine(d);
                }
            }
        }

        private static void RangeOperation()
        {
            var range = Enumerable.Range(1, 10);

            foreach (var item in range)
            {
                Console.Write(" " + item);
            }
        }

        private static void DefaultIfEmpty()
        {
            // this way is liked for performance than the normal one
            // when the initialyzation is empty
            var employees = Enumerable.Empty<Employee>();
            // give it the default value
            // as default(int) => 0
            employees = employees.DefaultIfEmpty(Employee.Default01);

            employees.Print("Print The Default Value When the Enumerable is Empty");
        }
    }
}
