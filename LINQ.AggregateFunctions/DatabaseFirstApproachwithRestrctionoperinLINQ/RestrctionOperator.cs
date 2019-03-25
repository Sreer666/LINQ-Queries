﻿using System;
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

            //SelectMany
            projection.SlectClauseCheck(employee);

            //SAMPLE Select Many EXAMPLE
            string[] stringarray =
                {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "1234567890"

            };

            IEnumerable<Char> SelectClause= stringarray.SelectMany(s => s);
           
            foreach(var item in SelectClause)
            {
                Console.WriteLine(item);
            }

            //OrderBy
            projection.orderByClause();
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

            public void SlectClauseCheck(EmployeeModel employee)
            {
                var results = employee.Employees.Select(dep => dep.DepartmentId);
                // •SelectMany is for flattening multiple sets into a new set.
                //•Select is for one - to - one mapping each element in a source set to a new set.

            }

            public void orderByClause()
            {
                //Lamda Expresion
                List<Student> students = Student.GetAllStudentInfo;
                IOrderedEnumerable<Student> studentsList =students.OrderBy(x => x.Name);

                foreach(var item in studentsList)
                {
                    Console.WriteLine(item.Name);
                }

                //Query Expression
                Console.WriteLine("Query Expression");
                var queryx = from student in students
                             orderby  student.Name
                             select student;

                foreach(var item in queryx)
                {
                    Console.WriteLine(item.Name);
                }

                //Lamda Expresion Descending Order
                Console.WriteLine("Lamda Expresion Descending Order");
                IOrderedEnumerable<Student> stdlist = students.OrderByDescending(x => x.Name);
                foreach (var item in stdlist)
                {
                    Console.WriteLine(item.Name);
                }

                //Query Expresion Descending Order
                Console.WriteLine("Query Expresion Descending Order");
                IOrderedEnumerable<Student> stdlistQuery = from stu in students
                                                           orderby stu.Name descending
                                                           select stu;
                foreach (var item in stdlistQuery)
                {
                    Console.WriteLine(item.Name);
                }
            }

        }
    }
}
