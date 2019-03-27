using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstApproachwithRestrctionoperinLINQ
{
   public class PageingwithSkipandTakecs
    {
        public void pagingmethod()
        {
            // You are trying to do paging by using skip and take operators
            //declare the pagesize
            //declare the pagenumber
            //check the condtion between the pages meaning How many pages you are trying to do.
            //and print the statment

            List<Student> students = Student.GetAllStudentInfo;
            int pagenumber = 0;

            Console.WriteLine("Hi Please Select the PageNumbers between 1---- 4");

           if( int.TryParse(Console.ReadLine(), out pagenumber))
            {
                if(pagenumber>=1 && pagenumber<=4)
                {
                    int pagesize = 3;
                    IEnumerable<Student> results = students.Skip((pagenumber - 1) * pagesize).Take(pagesize);
                    foreach(Student s in results)
                    {
                        Console.WriteLine(s.Name + "\t" + s.StudentId + "\t" + s.TotalMarks);
                    }
                }
                else
                {
                    Console.WriteLine("Please Select the PageNumbers rage between 1---- 4");
                }
            }
            else
            {
                Console.WriteLine("Please Select the PageNumbers rage between 1---- 4");
            }
        }
    }
}
