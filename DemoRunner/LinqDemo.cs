using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class LinqDemo : Demo
    {
        List<Student> studentList = new List<Student>() {
         new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
         new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
         new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
         new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
         new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };
        private static Random Dice = new Random();

        public override void Run()
        {
            WhereExamples();

            RemoveByEqualsExample();

            OrderByAndSum();

            ForEachSimplification();

            SelectExample();

        }

        private void RemoveByEqualsExample()
        {
            if (studentList.Remove(new Student() { StudentID = 1 }))
            {
                studentList.Where(s => s.Age >= 20).ToList().ForEach(s => { GiveMeNames(s); });
            }

            if (studentList.Select(s => s.StudentName).Contains("Bill"))
            {
                Console.WriteLine("Bill is on the list");
            }


            if (studentList.Select(s => s.StudentName).Contains("Roman"))
            {
                Console.WriteLine("Roman is on the list");
            }

            Student someRandomStudent = new Student { StudentID = 1 };
            if (studentList[0] == someRandomStudent)
            {
                Console.WriteLine("To jest ten sam student");
            }
        }

        private void WhereExamples()
        {
            var above20 = studentList.Where(s => s.Age >= 45).ToList();
            above20.ForEach(s => { GiveMeNames(s); });

            studentList.Where(s => s.StudentName.Contains('R')).ToList().ForEach(s => { GiveMeNames(s); });
        }

        private static void OrderByAndSum()
        {

            // 4 x kostką, wybrać 3 największe cyfry i zrobić z nich sume
            List<int> dices = new List<int>()
            {
                Roll(), Roll(), Roll(), Roll()
            };

            var sum = dices.OrderByDescending(x => x).Take(3).Sum();
        }

        private static int Roll() => Dice.Next(1, 7);

        private void ForEachSimplification()
        {
            foreach (Student student in studentList)
            {
                Console.WriteLine(student.StudentName);
                Console.WriteLine("------------------------------ \n");
            }
            studentList.ForEach(GiveMeNames);
            studentList.ForEach(s => GiveMeNames(s));
        }

        private void SelectExample()
        {
            // returns collection of anonymous objects with Name and Age property
            var selectResult = from s in studentList
                               select new { Name = "Mr. " + s.StudentName, Age = s.Age };

            var value = studentList.Select(s => new { Name = "Mr. " + s.StudentName, Age = s.Age }); // projection
            var studentsNames = value.ToList();
        }

        private void GiveMeNames(Student student)
        {
            Console.WriteLine(student.StudentName);
        }

        private string GetNames(Student student)
        {
           return student.StudentName;
        }

        private class Student 
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }

            public override bool Equals(Object obj)
            {
                Student student = obj as Student;
                if (student == null) return false;
                return this.StudentID.Equals(student.StudentID);
            }
        }
    }
}

