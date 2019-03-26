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
                    Name= "Ramesh1",
                    StudentId= "22649",
                    TotalMarks= "100"
                },
                new Student()
                {
                    Name= "Suresh1",
                    StudentId= "226419",
                    TotalMarks= "101"
                },
                new Student()
                {
                    Name= "Akbar1",
                    StudentId= "226419a",
                    TotalMarks= "102"
                },
                new Student()
                {
                    Name= "Ramesh2",
                    StudentId= "22649",
                    TotalMarks= "100"
                },
                new Student()
                {
                    Name= "Suresh2",
                    StudentId= "226419",
                    TotalMarks= "101"
                },
                new Student()
                {
                    Name= "Akbar2",
                    StudentId= "226419a",
                    TotalMarks= "102"
                },
                new Student()
                {
                    Name= "Ramesh3",
                    StudentId= "22649",
                    TotalMarks= "100"
                },
                new Student()
                {
                    Name= "Suresh3",
                    StudentId= "226419",
                    TotalMarks= "101"
                },
                new Student()
                {
                    Name= "Akbar3",
                    StudentId= "226419a",
                    TotalMarks= "102"
                },
            };
    }
}
