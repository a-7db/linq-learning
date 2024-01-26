
using FakeData02;

namespace CAProjectionOperatration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            // RunExample01(employees);
            // RunExample02();
            // RunExample03(employees);
            // RunExample04();
            RunExample05(employees);

            Console.ReadKey();
        }

        private static void RunExample05(IEnumerable<Employee> employees)
        {
            // Create teams via Zip()
            Employee[] emps = employees.ToArray();

            var firstEmps = emps[..3];
            var lastEmps = emps[^3..];

            var teams = firstEmps.Zip(lastEmps, (team1, team2) => $"{team1.FullName} -VS- {team2.FullName}");

            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
        }

        private static void RunExample04()
        {
            string[] colorName = { "Red", "Green", "Blue" };
            string[] colorHex = { "FF0000", "00FF00", "0000FF" };

            var colors = colorName.Zip(colorHex, (cName, cHex) => $"{cName} => {cHex}");

            foreach ( var color in colors )
            {
                Console.WriteLine( color );
            }
        }

        private static void RunExample03(IEnumerable<Employee> employees)
        {
            // Method Syntax
            var allSkills = employees.SelectMany(e => e.Skills).Distinct();

            // Query Syntax
            var skills = (from emp in employees
                         from skill in emp.Skills
                         select skill).Distinct();
                         

            foreach (var skill in skills) { Console.WriteLine(skill); }
        }

        private static void RunExample02()
        {
            string[] sentences =
            {
                "i love asp.net core",
                "i like sql server programming",
                "in general i love programming"
            };

            var result = sentences.SelectMany(x => x.Split(' '));
            
            foreach (var c in result) { Console.WriteLine(c); }
        }

        private static void RunExample01(IEnumerable<Employee> employees)
        {
            var data = employees.Where(x => x.Skills.Count() < 3).Select(e =>
            { // take some cols & add them in new object
                return new 
                {
                    Name = e.FirstName + " " + e.LastName,
                    SkillCount = e.Skills.Count()
                };
            });

            foreach (var e in data)
            {
                Console.WriteLine($"{e.Name} [{e.SkillCount}]");
            }
        }
    }
}
