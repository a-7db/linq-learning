using FakeData;

namespace CACoreOfLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employyes = Repository.LoadEmployees();

            // LINQsyntax(employyes);
            // ImmediateExecution();
            LINQexamples(employyes);
            
            Console.ReadKey();
        }

        private static void LINQexamples(IEnumerable<Employee> employyes)
        {
            var empMale = employyes.Where(e => e.Gender == "male");

            var empHR = employyes.Where(x => x.Salary >= 300_300);

            var both = empMale.Where(x => x.Salary >= 300_300);
            both.Print("Male & HR employees");
        }

        private static void ImmediateExecution()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var evenNumbers = numbers.Where(n => n % 2 == 0);

            numbers.Add(10);
            numbers.Add(12);
            numbers.Remove(4);

            // It will print { 2, 6, 8, 10, 12 }
            // because it won't iterate before do all changes on numbers,
            // so will include the updated list
            // this called [[ Immediate Execution ]]
            foreach (var number in evenNumbers)
            {
                Console.Write($" {number}");
            }
        }

        private static void LINQsyntax(IEnumerable<Employee> employyes)
        {
            // METHOD SYNTAX
            var maleAndItEmps = employyes.Where(emp => emp.Department.ToLowerInvariant() == "it"
            && emp.Gender.ToLowerInvariant() == "male");

            maleAndItEmps.Print("IT & Male Employees");

            // QUERY SYNTAX
            var querySyntax = from emp in employyes
                              where emp.Department.ToLower() == "it"
                              && emp.Gender.ToLower() == "female"
                              select emp;
            querySyntax.Print("With Query Syntax");
        }
    }
}
