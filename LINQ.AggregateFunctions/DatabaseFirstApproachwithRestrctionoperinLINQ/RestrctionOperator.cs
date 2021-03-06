﻿using System;
using System.Collections;
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

            //Pagenation page = new Pagenation();
            //page.PagenationMethod();

            // New paging

            PageingwithSkipandTakecs pageingwithSkipand = new PageingwithSkipandTakecs();
            pageingwithSkipand.pagingmethod();


            Dictionary dictionary = new Dictionary();
            dictionary.DictionaryMethod();

            Tolookup tolookup = new Tolookup();
            tolookup.Toolookupmethod();

            CastOverOfType castOverOfType = new CastOverOfType();
            castOverOfType.CastOverOfTypeMethod();
            castOverOfType.OverOfTypeMethod();

            //Groupby
            Grouby grouby = new Grouby();
            grouby.groupbymethod();

            GroupByMutiple groupByMutiple = new GroupByMutiple();
            groupByMutiple.groupbymethod();
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
                Console.WriteLine("This is Pagenation End");
               // } while (1 == 1);
            }

        }


//Dictionary
        public class Dictionary
        {
            public void DictionaryMethod()
            {
                Console.WriteLine("Dictionary Method Starting");
                List<Student> studentsList = Student.GetAllStudentInfo;
                //For Dictonary we need to filter based on key value paring and each key should be uniq
              Dictionary<int, Student> keyValuePairs=  studentsList.ToDictionary(x => x.StudentId);

                foreach(KeyValuePair<int, Student> keyValues in keyValuePairs)
                {
                    Console.WriteLine(keyValues.Value.StudentId + "\t" + keyValues.Value.Name + " \t " + keyValues.Value.Name);
                }
                Console.WriteLine("Dictionary Method End");
            }
        }

//Tolookup

        public class Tolookup
        {
            public void Toolookupmethod()
            {
                Console.WriteLine("Toolookupmethod Starting");
                List<Student> studentsList = Student.GetAllStudentInfo;

                var keyValuePairs = studentsList.ToLookup(x => x.TotalMarks);

                //Console.WriteLine(keyValuePairs);
                foreach (var keys in keyValuePairs)
                {
                    Console.WriteLine(keys.Key);
                    foreach (var keyValues in keyValuePairs[keys.Key])
                    {
                        Console.WriteLine(keyValues.Name + "\t" + keyValues.Name + "\t" + keyValues.TotalMarks);
                    }
                }

                Console.WriteLine("Toolookupmethod End");
            }
        }


//CastOverOfType

        public class CastOverOfType
        {
           public void CastOverOfTypeMethod()
            {
//Cast: It will only cast the values for same elements if you try to add any other differnt datatype then error will be thrown
                List<int> vs = new List<int>();
                int i = 1;
                int j = 1;
                int k = 1;
                vs.Add(i);
                vs.Add(j);
                vs.Add(k);
                IEnumerable<int> listvs = vs.Cast<int>();
                foreach(var item in listvs)
                {
                    Console.WriteLine(item);
                }
            }
 //OfType: It will Cast Specif data type which we want to itterate
            public void OverOfTypeMethod()
            {
//OfType : It will only retrun the specifed type and the rest of the items will be ignored and exclude the results
                ArrayList vs = new ArrayList();
                vs.Add(1);
                vs.Add(2);
                vs.Add(3);
                vs.Add("whats your name");
                IEnumerable<int> listvs = vs.OfType<int>();
                foreach(var item in listvs)
                {
                    Console.WriteLine(item);
                }
                IEnumerable<string> listvsstring = vs.OfType<string>();
                foreach(var item in listvsstring)
                {
                    Console.WriteLine(item);
                }
            }
        }

       // AsEnumerable and AsQueryable in LINQ
       //If you want to do query in client side then you should go for this execution



        //GroupBy
        
        public class Grouby
        {
            public void groupbymethod()
            {
                Console.WriteLine("GroupBy");
                var stud = Student.GetAllStudentInfo.GroupBy(x => x.TotalMarks);
                foreach(var item in stud)
                {
                    Console.WriteLine(item.Key, item.Count());
                }
                //Need to work on groupby clause  for sorting 

                EmployeeModel employee = new EmployeeModel();
                var departments = employee.Departments.Where(dep => dep.Name == "IT" || dep.Name == "HR").OrderBy(x=>x.Name);

                //from emp in employee.Departments
                //group emp by employee.Departments into empgroup orderby empgroup.Key
                //select (x=> new
                //{ 

                //})

                foreach (var item in departments)
                {
                    Console.WriteLine(item.Name + "       " + item.ID);
                }
            }

          

        }

        public class GroupByMutiple
        {
            public void groupbymethod()
            {
                //An anonymous type is usually used when we want to group by mutiple keys.
                var emp = Employee1.GetEmployees().GroupBy(x => new { x.Department, x.Gender })
                 .OrderBy(x => x.Key.Department).ThenBy(x => x.Key.Gender)
                 .Select(x => new
                 {
                     department = x.Key.Department,
                     gender = x.Key.Gender,
                     Empinfo = x.OrderBy(y => y.Name)
                 });
                foreach(var group in emp)
                {
                    Console.WriteLine("Department {0} gender {1} employee count {2}", group.department, group.gender, group.Empinfo.Count());
                    Console.WriteLine("------------------------------------");
                    foreach(var item in group.Empinfo)
                    {
                        Console.WriteLine(item.ID + "\t" + item.Name + "\t" + item.Salary);
                    }
                }

            }
        }
        //Need to write
        // FIrst(there will be 2 overload versions)one to write  for predicate function
        //Ans:When you know that result contain more than 1 element expected and you should only get the first element of sequence.
        //if sequence does not contain any element then it will throw tht error.
        //Even the same follows for Predicate function example .First(x=>x%2==0) this should retrun only the even numbers values if there is no matching then it will throw null execption


        //First or default
        //Ans: FirstOrDefault()  is just like First() except that, if no element match the specified condition than it returns default value of underlying type 
        //of generic collection. It does not throw InvalidOperationException if no element found. 
        //But collection of element or a sequence is null than it throws an exception.


        //last
        //last or default
        //ElemenetAt()
        //Single(there will be 2 overload versions)one to write  for predicate function

    }
}
