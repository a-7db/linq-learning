using FakeData03;

namespace CASortingData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            //RunExample01(employees);
            //RunExample02(employees);
            //RunExample03(employees);
            //RunExample04(employees);
            RunExample05(employees);

            Console.ReadKey();
        }

        private static void RunExample05(IEnumerable<Employee> employees)
        {
            //  Custom Comparation
            var customCompare = employees.OrderBy(e => e, comparer: new CustomComparer());

            customCompare.Print("Custom Compartion");
        }

        private static void RunExample04(IEnumerable<Employee> employees)
        {
            var sortedBySkilsCount = employees.OrderBy(e => e.Skills.Count());

            sortedBySkilsCount.Print("sorted By Skils Count");
        }

        private static void RunExample03(IEnumerable<Employee> employees)
        {
            var SortedUsingQuery = from emp in employees
                                   orderby emp.Name.Length
                                   select emp;

            SortedUsingQuery.Print("Sorted By Length Using Query");
        }

        private static void RunExample02(IEnumerable<Employee> employees)
        {
            var descSorted = employees.OrderByDescending(e => e.Name).ThenBy(e => e.Salary);

            descSorted.Print("DESC Order BY");
        }

        private static void RunExample01(IEnumerable<Employee> employees)
        {
            var sortedByName = employees.OrderBy(e => e.Name);

            sortedByName.Print("Employee Sorted by Name");
        }
    }
}
