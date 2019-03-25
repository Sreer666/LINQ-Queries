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

                var empindex = emplist.Select((EmployeeModel, index) => new { emp1 = EmployeeModel, ind = index });
                foreach(var item in empindex)
                {
                    Console.WriteLine(item);
                }
        

            }
            //Projection Operators in Linq 

            projection projection = new projection();
            projection.ProjectionOperartorsGettingID(employee);
            projection.ProjectionOperartorsGettingEmployeeInfo(employee);



        }


        //Projection Operators in Linq seprate method 
        public class projection
        {
            public void ProjectionOperartorsGettingID(EmployeeModel employee)
            {
                var DEPT = employee.Departments.Select(dep => dep.ID);

                foreach (var id in DEPT)
                {
                    Console.WriteLine(id);
                }
            }
            public void ProjectionOperartorsGettingEmployeeInfo(EmployeeModel employee)
            {
                var EmployeeInfo = employee.Employees.Select(emp => new { FlName = emp.FirstName + " " + emp.LastName, gender = emp.Gender,
                    AverageMonthlySalary = emp.Salary/12, Bonus = emp.Salary*0.3 });

                foreach (var item in EmployeeInfo)
                {
                    Console.WriteLine(item.FlName +"     "+ item.gender + "     " +item.AverageMonthlySalary + "     " +item.Bonus);
                }
            }

//SelectMany

            //public void SlectClauseCheck(EmployeeModel employee)
            //{
            //    var results = employee.Employees.SelectMany(dep => dep.DepartmentId); 
            //}
        }
    }
}
