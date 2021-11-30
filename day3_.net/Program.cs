using System;

namespace User_defined_Data
{
    class program 
    {
        static void Main (string[] args)
        {
            int i;
                Class1 student = new Class1();
                Console.WriteLine("please enter information about the student");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the first Name");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("enter the last Name");
                student.LastName = Console.ReadLine();


                Console.WriteLine("enter the roll number");
                student.Roll = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks");
                student.Marks = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Thank you for providing the details");

            }
            //Printing
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"FirstName:{student.FirstName}");
                Console.WriteLine($"LastName:{student.LastName}");
                Console.WriteLine($"Roll:{student.Roll}");
                Console.WriteLine($"Marks:{student.Marks}");
            }



        }
    }
}