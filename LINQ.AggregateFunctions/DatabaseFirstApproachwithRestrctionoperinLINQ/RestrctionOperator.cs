using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstApproachwithRestrctionoperinLINQ
{
    public class RestrctionOperator
    {
        static void Main(string[] args)
        {
            EmployeeModel employee = new EmployeeModel();
            var departments = employee.Departments.Where(dep => dep.Name == "IT" || dep.Name=="HR");

            foreach (Department dept in departments)
            {
                Console.WriteLine(dept.Name+"     "+dept.Location);


                //var departmentsindex = departments.Select((dep, indexer) => new { dept1 = dep, ind = indexer });
                //foreach (var item in departmentsindex)
                //{
                //    Console.WriteLine(item.ind);
                //}


                var emplist = dept.Employees.Where(x => x.Gender == "Male"|| x.Gender == "Female");
                foreach (Employee emp in emplist)
                {
                    Console.WriteLine(emp.FirstName + "  " + emp.LastName + "   " + emp.Gender);
                }
                //If you want to retrive Index postion 

                var empindex = emplist.Select((EmployeeModel, indexer) => new { emp1 = EmployeeModel, ind = indexer });
                foreach(var item in empindex)
                {
                    Console.WriteLine(item);
                }
        

            }
        
          }

    }
}
