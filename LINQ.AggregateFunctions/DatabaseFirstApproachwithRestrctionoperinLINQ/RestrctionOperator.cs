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

//TakeSKip
            projection.TakeSkip();

            Pagenation page = new Pagenation();
            page.PagenationMethod();
        }// End of Main Method


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
//orderBy
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
//Take Skip
            public void TakeSkip()
            {
                Console.WriteLine("This is Take Operator");
                string[] takeskip = new string[] { "USA",  "India", "Austr", "Newzland","UK", "K"};

                IEnumerable<string> vs= takeskip.Take(3);
                foreach(var item in vs)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("This is Skip Operator");

                IEnumerable<string> vSKip = takeskip.Skip(2);
                foreach(string item in vSKip)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("This is Skipwhile Operator");
                // Here the skipwhile will skip the items and once the length or condtion matches then it will retrun list from there
                IEnumerable<string> vSKipwhile = takeskip.SkipWhile(x=>x.Length>2);
                foreach (string item in vSKipwhile)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("This is takeskip Operator");
                // Here the take while returns only the items until the legth or condtion matches.
                IEnumerable<string> vtakewhile = takeskip.TakeWhile(x => x.Length > 1);
                foreach (string item in vtakewhile)
                {
                    Console.WriteLine(item);
                }
 ;

            }
        }
//Pagenation      
        public class Pagenation
        {
            public void PagenationMethod()
            {
                Console.WriteLine("This is Pagenation Start");
                //do
                //{
                    List<Student> students = Student.GetAllStudentInfo;
                    int PageNumber = 0;
                    Console.WriteLine("Please select the pages between 1to 4");
                    if (int.TryParse(Console.ReadLine(), out PageNumber))
                    {
                        if (PageNumber >= 1 && PageNumber <= 4)
                        {
                            int pagesize = 3;
                            IEnumerable<Student> results = students.Skip((PageNumber - 1) * pagesize).Take(pagesize);
                            Console.WriteLine("Displaying Page" + PageNumber);
                            foreach (Student s in results)
                            {
                                Console.WriteLine(s.Name + " " + s.StudentId + " " + s.TotalMarks);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select the pages between 1to 4");
                    }
               //var studentslist= students.Select(x => new { FirstName = x.Name, studentsdetails = x.StudentId, totalMarks = x.TotalMarks });

                // foreach(var item in studentslist)
                // {
                //     Console.WriteLine(item.FirstName + "   " + item.studentsdetails + "   " + item.totalMarks);
                // }
                Console.WriteLine("This is Pagenation End");
               // } while (1 == 1);
            }

        }
    }
}
