﻿namespace FakeData03
{
    public class Employee02
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string Gender { get; set; }

        public int DepartmentId { get; set; }

        public bool HasHealthInsurance { get; set; }

        public bool HasPensionPlan { get; set; }

        public decimal Salary { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
