using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstApproachwithRestrctionoperinLINQ
{
    public class Student
    {
        public string Name { get; set; }

        public string  StudentId  { get; set; }

        public string  TotalMarks { get; set; }


        public static List<Student> GetAllStudentInfo=
            new List<Student>()
            {
                new Student()
                {
                    Name= "Ramesh",
                    StudentId= "22649",
                    TotalMarks= "100"
                },
                new Student()
                {
                    Name= "Suresh",
                    StudentId= "226419",
                    TotalMarks= "101"
                },
                new Student()
                {
                    Name= "Akbar",
                    StudentId= "226419a",
                    TotalMarks= "102"
                },
            };
    }
}
