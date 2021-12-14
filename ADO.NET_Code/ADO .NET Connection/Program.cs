using ADO.NetConnection.BO;
using ADO.NetConnection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NetConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = new StudentDAL();

            //dal.DeleteStudent(785);
            var studentList = new List<Student>();
            studentList = dal.GetStudents();
            dal.CreateStudentWithSP(new Student
            {
                FN = "Indranil",
                LN = "Das",
                RollNo = 1,
                Marks = 104.12
            });

            var s = dal.GetStudentByRollNumber(1234);
            var x = dal.UpdateStudent(new Student
            {
                FN = "Indranil",
                LN = "Das",
                RollNo = 1,
                Marks = 104.12
            });
             x = dal.CreateStudent(new Student
            {
                FN = "Raj",
                LN = "Roy",
                RollNo = 2,
                Marks = 104.12
            });
            int size = 0;
            for (; ; )
            {
                Console.WriteLine("1. Enter inputs");
                Console.WriteLine("2. Print Data");
                Console.WriteLine("3. Find a Student by Name.");
                Console.WriteLine("4. Find a Student by Roll.");
                Console.WriteLine("5. Change the Last-Name of all Students");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Number of students");
                    
                    var i = Convert.ToInt32(Console.ReadLine());
                    size = i;                    
                    
                    if (i != 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            var st = new Student();
                            Console.WriteLine($"Enter following details for Student {j+1}");
                            Console.WriteLine("Enter first name");
                            st.FN = Console.ReadLine();

                            Console.WriteLine("Enter last name");
                            st.LN = Console.ReadLine();

                            Console.WriteLine("Enter rollno");
                            st.RollNo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Marks");
                            st.Marks = double.Parse(Console.ReadLine());

                            studentList.Add(st);
                        }

                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                else if (input == "2")
                {

                    for (int i = 0; i < size; i++)
                    {
                        Student st = studentList[i];
                        Console.WriteLine($"Thank you for providing the details. Following are your details for student {i+1}-");
                        Console.WriteLine($"FirstName-{st.FN}");
                        Console.WriteLine($"LastName-{st.LN}");
                        Console.WriteLine($"Rollnum-{st.RollNo}");

                        Console.WriteLine($"Marks-{st.Marks}");
                    }
                   
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter the First Name of the sutend you want to find.");
                    var firstname = Console.ReadLine();
                    var person = studentList.Where(x => x.FN == firstname).FirstOrDefault();
                    Console.WriteLine("Latst name : "); Console.WriteLine(person.LN);
                    Console.WriteLine("Roll Number: "); Console.WriteLine(person.RollNo);
                }

                else if (input == "4")
                {
                    Console.WriteLine("Enter the Roll Number of the Student you want to find");
                    var rollNo = Convert.ToInt32(Console.ReadLine());
                    var student1 = studentList.Where(x => x.RollNo == rollNo).FirstOrDefault(); //Find a particular student
                    var name = student1.FN + student1.LN;
                    Console.WriteLine(name);

                }
                else if (input == "5")
                {
                    Console.WriteLine("Changed the Last Name");
                    foreach (var item in studentList) // foreach (Student item in studentlist)
                    {
                        // execute code
                        item.LN = "TCS"; // lastname of every student will be changed. 
                        var name1 = item.FN + " " + item.LN;
                        Console.WriteLine(name1);
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
            }
        }

        static void Main1()
        {
            var length = 10;
            var i = 0;
            for (i = 0; i < length; i++)
            {
                //code execution block
            }

            length = 5;
           
            while(i<=length)
            {
                //code execution block
                i++;
            }

            do
            {
                i++;
                //code execution block
                //i++;
            }
            while (i <= 5);

            var studentList = new List<Student>();

            foreach (Student item in studentList)
            {
                //code execution block
                Console.WriteLine(item.FN);
                item.LN = "ABC";
            }

            //Find specific student
            var rollNo =Convert.ToInt32(Console.ReadLine());
            var fn = Console.ReadLine();
            var student=studentList.Where(x => x.RollNo==rollNo).FirstOrDefault();

            var students = studentList.Where(x => x.FN == fn).ToList();
        }
    }
}

