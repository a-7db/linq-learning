using FakeData03;

namespace CAElementOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            //RunFirst(employees);
            //RunLast(employees);
            RunSingle(employees);

            Console.ReadKey();
        }

        private static void RunSingle(IEnumerable<Employee> employees)
        {
            // Single Method to return one record
            // But MUST be a uniqe record
            var GetRecordNO44 = employees.SingleOrDefault(e => e.Index == 44);

            // Q: What the Difereint Beteen SingleOrDefault() & Single()
            //      it's similar to First & Last
            //      When the condition is false will retutn
            //      the default value

            if (GetRecordNO44 is null)
                Console.WriteLine("My Message");
        }

        private static void RunLast(IEnumerable<Employee> employees)
        {
            var GetLastRecord = employees.LastOrDefault();

            if (GetLastRecord is null)
                Console.WriteLine("Not Found!");
            else
                Console.WriteLine(GetLastRecord);
        }

        private static void RunFirst(IEnumerable<Employee> employees)
        {
            var firstRecord = employees.First(); // To Get The First Record
            //Console.WriteLine(firstRecord);

            var first2014ID = employees.First(x => x.EmployeeNo.StartsWith("2014"));
            //Console.WriteLine(first2014ID);

            // but If the condition is not true will return Exception
            // So, Should Use FirstOrDefault(); to return default value
            var empWithIndex0 = employees.FirstOrDefault(x => x.Index == 0); // => null

            // To Handel the error:
            if(empWithIndex0 is null)
            {
                Console.WriteLine("There Is no Employee Accept this Index");
            }
        }
    }
}
