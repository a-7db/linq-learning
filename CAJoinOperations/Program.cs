using FakeData03;

namespace CAJoinOperations
{
    internal class Program
    {
        private static IEnumerable<Employee02> employees = Repository02.LoadEmployees();
        private static IEnumerable<Department> departments = Repository02.LoadDepartment();
        static void Main(string[] args)
        {
            //RunJoin();
            RunGroupJoin();

            Console.ReadKey();
        }

        private static void RunGroupJoin()
        {
            // same pure join
            var joinGroupMethod = departments.GroupJoin(
                employees,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept, emps) =>
                {
                    return new EmployeeGroups
                    {
                        FullName = emps.Select(e => e.FullName).ToList(),
                        Department = dept.Name
                    };
                });

            var joinGroupQuery = from dept in departments
                                 join emp in employees
                                 on dept.Id equals emp.DepartmentId
                                 into groups  // this will divide them into groups
                                 select new EmployeeGroups
                                 {
                                     FullName = groups.Select(e => e.FullName).ToList(),
                                 };

            foreach (var group in joinGroupQuery)
            {
                Console.WriteLine();
                Console.WriteLine($"++++ ========== ++++");
                Console.WriteLine();

                foreach (var emp in group.FullName)
                {
                    Console.WriteLine($"  {emp}");
                }
            }

            //foreach (var group in joinGroupMethod)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine($"++++ {group.Department} ++++");
            //    Console.WriteLine();

            //    foreach (var emp in group.FullName)
            //    {
            //        Console.WriteLine($"  {emp}");
            //    }
            //}
        }

        private static void RunJoin()
        {
            var JoinMethod = employees.Join( // outter
                departments,                 // inner
                emp => emp.DepartmentId,     // outer key
                dept => dept.Id,             // inner key
                (emp, dept) =>               // result form
                {
                    return new
                    {
                        FullName = emp.FullName,
                        Department = dept.Name
                    };
                });

            var JoinQuery = from emp in employees
                            join dept in departments
                            on emp.DepartmentId equals dept.Id
                            select new
                            {
                                FullName = emp.FullName,
                                Department = dept.Name
                            };

            foreach (var emp in JoinQuery)
            {
                Console.WriteLine($"{emp.FullName} --> {emp.Department}");
            }
        }
    }

    public class EmployeeGroups
    {
        public string Department { get; set; }
        public List<string> FullName { get; set; }
    }
}
