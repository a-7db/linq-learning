using FakeData03;

namespace CAQuantifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            //RunAnyExample(employees);
            RunAllExample(employees);

            Console.ReadKey();
        }

        private static void RunAllExample(IEnumerable<Employee> employees)
        {
            // check if all emps have salary start with 3,700
            var isGreaterThan3700 = employees.All(x => x.Salary >= 3700);


            // return all emps who have C# skill
            var empsHaveCsharp = from emp in employees
                                 where emp.Skills.All(s => s.Length >= 3)
                                 select emp;

        }

        private static void RunAnyExample(IEnumerable<Employee> employees)
        {
            // check if any employee has no email
            var AnyNoEmails = employees.All(x => string.IsNullOrWhiteSpace(x.Email));

            Console.WriteLine(AnyNoEmails);
        }
    }
}
