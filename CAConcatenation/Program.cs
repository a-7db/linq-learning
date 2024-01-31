using FakeData02;

namespace CAConcatenation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            //RunExample01(employees);
            RunExample02(employees);

            Console.ReadKey();
        }

        private static void RunExample02(IEnumerable<Employee> employees)
        {
            var list = employees.ToList();
            var firstEmployees = list[..2];
            var lastEmployess = list[^2..];

            // Concat with element
            var concat = firstEmployees.Select(e => e.FullName).Concat(lastEmployess.Select(e => e.FullName));

            concat.Print("Two IEnumerable Concatenation");
        }

        private static void RunExample01(IEnumerable<Employee> employees)
        {
            var list = employees.ToList();
            var firstEmployees = list[..2];
            var lastEmployess = list[^2..];

            // Using Concat() method to concat 2 of collections
            var concat = firstEmployees.Concat(lastEmployess);

            concat.Print("Two IEnumerable Concatenation");
        }
    }
}
