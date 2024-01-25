using FakeData;

namespace CADelegate;

internal class Program
{
    static void Main(string[] args)
    {
        var emps = Repository.LoadEmployees();

        var startWith = GetEmployeesWith(emps, e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
        Helper.Print(startWith, "Employees Names starts with MA");

        var hr = emps.Fillter(e => e.Department.ToLowerInvariant() == "hr");
        hr.Print("HR Employees");
    }

    static IEnumerable<Employee> GetEmployeesWith(IEnumerable<Employee> sourse, Func<Employee, bool> predicate)
    {
        foreach (Employee emp in sourse)
        {
            if (predicate(emp))
            {
                yield return emp;
            }
        }
    }
}
