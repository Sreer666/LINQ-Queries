using System;
using System.Linq;

namespace LINQ.AggregateFunctions
{
    class AggregateFunctions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Programer Your working on Aggregate Functions!");
            //how to write qurery by using Affregate operators  value in an array
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//Min Values
//===TODO===You(upate) should able to do list of even numbers instead of min or max

            var MinNumber = numbers.Min();
            Console.WriteLine("Min Number" + "\n" + MinNumber);

            var MinEvenNumber = numbers.Where(x => x % 2 == 0).Min();
            Console.WriteLine("Min Even Numbers" + "\n" + MinEvenNumber);

            var MinODDNumber = numbers.Where(x => x % 2 != 0).Min();
            Console.WriteLine("Min odd Numbers" + "\n" + MinODDNumber);

//Max Values
            var Maxvalue = numbers.Max();
            Console.WriteLine("Maxvalue Number" + "\n" + Maxvalue);

            var MaxEvenvalue = numbers.Where(x => x % 2 == 0).Max();
            Console.WriteLine("MaxEvenvalue Number" + "\n" + MaxEvenvalue);

            var MaxODDNumber = numbers.Where(x => x % 2 != 0).Max();
            Console.WriteLine("Max odd Numbers" + "\n" + MaxODDNumber);

//Sum

            var Maxsum = numbers.Sum();
            Console.WriteLine("Maxsum Number" + "\n" + Maxsum);

            var MaxEvensum = numbers.Where(x => x % 2 == 0).Sum();
            Console.WriteLine("MaxEvensum Number" + "\n" + MaxEvensum);

//Average

            var MaxAverage = numbers.Average();
            Console.WriteLine("Maxsum Number" + "\n" + MaxAverage);

            var MaxEvenAverage = numbers.Where(x => x % 2 == 0).Average();
            Console.WriteLine("MaxEvensum Number" + "\n" + MaxEvenAverage);


//Count

            var Maxcount = numbers.Count();
            Console.WriteLine("Maxcount Number" + "\n" + Maxcount);

            var MaxEvencount = numbers.Where(x => x % 2 == 0).Count();
            Console.WriteLine("MaxEvencount Number" + "\n" + MaxEvencount);


            //Examples 2
            string[] Countries = { "India", "Aus", "UKINSD" };
            var mincount = Countries.Min(x => x.Length);

            var MaxCount = Countries.Max(x => x.Length);

            var sumCount = Countries.Sum(x => x.Length);


//Aggregate function in LINQ
//How it going to work were c will be india for the first time then d will be ANTR and then looping d untill it satifys
            string[] countrieslist = { "India", "Antr", "agg", "AYS" };
            var Aggregatef = countrieslist.Aggregate((c, d) => c + "," + d);
            Console.WriteLine("This is 1st Aggreate Function" + "\n" + Aggregatef);

//Aggregate Seed function in LINQ
            int[] NumList = { 1, 2, 3, 4, 5, 6 };
            var AggregatefSeed = NumList.Aggregate(10, (a, b) => a + b);
            Console.WriteLine("This is 1st Aggreate Seed Function" + "\n" + AggregatefSeed);

        }
    }
}
