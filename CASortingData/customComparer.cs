using FakeData03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASortingData
{
    public class CustomComparer : Comparer<Employee>
    {
        public override int Compare(Employee? emp1, Employee? emp2)
        {
            // 2017-FI-1343
            var year1 = Convert.ToInt32(emp1?.EmployeeNo.Split('-')[0]);
            var year2 = Convert.ToInt32(emp2?.EmployeeNo.Split('-')[0]);

            var seq1 = Convert.ToInt32(emp1?.EmployeeNo.Split('-')[2]);
            var seq2 = Convert.ToInt32(emp2?.EmployeeNo.Split('-')[2]);

            if(year1 ==  year2)
            {
                return seq1.CompareTo(seq2);
            }
            else
            {
                return year1.CompareTo(year2);
            }
        }
    }
}
