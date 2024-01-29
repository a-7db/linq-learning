namespace FakeData
{
    public class Employee
    {
        public Employee() { }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public bool HasHealthInsurance { get; set; }

        public bool HasPensionPlan { get; set; }

        public decimal Salary { get; set; }

        // inside the class add static method for default value
        public static Employee Default()
        {
            return new Employee
            {
                Id = 0000,
                FirstName = "Your First Name",
                LastName = "Your Last Name",
                HireDate = new DateTime(),
                Department = "Your Department",
                Gender = "Male",
                HasHealthInsurance = false,
                HasPensionPlan = false,
                Salary = 0,
            };
        }

        // or property
        public readonly static Employee Default01 = new Employee
        {
            Id = 0000,
            FirstName = "Your First Name",
            LastName = "Your Last Name",
            HireDate = new DateTime(),
            Department = "Your Department",
            Gender = "Male",
            HasHealthInsurance = false,
            HasPensionPlan = false,
            Salary = 0
        };

        public override string ToString()
        {
            return
                    string.Format($"" +
                    $"{Id}\t" +
                    $" {String.Concat(LastName, ", ", FirstName).PadRight(15, ' ')}\t" +
                    $"{HireDate.Date.ToShortDateString()}\t" +
                    $"{Gender.PadRight(10, ' ')}\t" +
                    $"{Department.PadRight(10, ' ')}\t" +
                    $"{HasHealthInsurance}\t" +
                    $"{HasPensionPlan}\t" +
                    $"${Salary.ToString("0.00")}");
        }
    }

}
