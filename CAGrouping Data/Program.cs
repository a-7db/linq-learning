using FakeData;

namespace CAGrouping_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            //RunGroupBy(employees);
            RunToLookup(employees);

            Console.ReadKey();
        }

        private static void RunToLookup(IEnumerable<Employee> employees)
        {
            // ToLookup Method it executes the result in memory
            // In One Time For Multiple Process
            var ToLookup = employees.ToLookup(e => e.Department);


            foreach (var group in ToLookup)
            {
                group.Print($"All Employees In '{group.Key}' Department");
            }
        }

        private static void RunGroupBy(IEnumerable<Employee> employees)
        {
            // GroupBy in Method Syntax
            var group01 = employees.GroupBy(e => e.Department);


            // GroupBy in Query Syntax
            var group02 = from emp in employees group emp by emp.Department;

            foreach (var group in group02)
            {
                group.Print($"All Employees In '{group.Key}' Department");
            }
        }
    }
}
