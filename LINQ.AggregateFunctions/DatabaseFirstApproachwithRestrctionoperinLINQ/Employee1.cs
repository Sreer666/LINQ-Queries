using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstApproachwithRestrctionoperinLINQ
{
    public class Employee1
    {
        public int ID { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }

        public static List<Employee1> GetEmployees()
        {
            return new List<Employee1>()
            {
                new Employee1{ID=1,Department="IT",Gender="Male",Name="Brama",Salary=45000},
                new Employee1{ID=2,Department="HR",Gender="FeMale",Name="KKpubgfirl",Salary=40500},
                new Employee1{ID=3,Department="IT",Gender="Male",Name="Krishna",Salary=450100},
                new Employee1{ID=4,Department="HR",Gender="FeMale",Name="KK1",Salary=41500},
                new Employee1{ID=5,Department="IT",Gender="Male",Name="KK2",Salary=45010},
                new Employee1{ID=6,Department="HR",Gender="FeMale",Name="KK3",Salary=4500},
                new Employee1{ID=7,Department="IT",Gender="Male",Name="KK4",Salary=45010},
                new Employee1{ID=8,Department="HR",Gender="FeMale",Name="KK5",Salary=451005},
                new Employee1{ID=9,Department="IT",Gender="Male",Name="KK6",Salary=45040},
                new Employee1{ID=10,Department="HR",Gender="FeMale",Name="KK7",Salary=45400},
                new Employee1{ID=11,Department="IT",Gender="Male",Name="KK8",Salary=45400},
                new Employee1{ID=12,Department="HR",Gender="FeMale",Name="KK9",Salary=44500},
                new Employee1{ID=13,Department="IT",Gender="Male",Name="KK10",Salary=45040}
            };
        }



    }
}
