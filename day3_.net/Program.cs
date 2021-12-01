using System;

namespace User_defined_Data
{
    class program
    {
        static void Main(string[] args)
        {
            int i;
            //<data_type>[] <array_name> = new <data_type>[<array_size>];
            //Class1[] std_array = new Class1[3];// array of object
            //int[] abc =new int[5];

            Console.WriteLine("enter the value of W");
            int w = Convert.ToInt32(Console.ReadLine()); 
            Class1[] std_array = new Class1[w];
            Class1 student = new Class1();

            Console.WriteLine("please enter information about the student");
            for (i = 0; i < w; i++)
            {
                Console.WriteLine("student "+(i+1));
                Console.WriteLine("Enter the first Name",(i+1));
                student.FirstName = Console.ReadLine();



                Console.WriteLine("enter the last Name");
                student.LastName = Console.ReadLine();




                Console.WriteLine("enter the roll number");
                student.Roll = Convert.ToInt32(Console.ReadLine());



                Console.WriteLine("Enter Marks");
                student.Marks = Convert.ToDouble(Console.ReadLine());



                Console.WriteLine("Thank you for providing the details");
                std_array[i]=student;
                Console.Clear();
            }


            //Printing

            for (i = 0; i < w; i++)
            {
                Console.WriteLine($"Student: (i + 1)");
                Console.WriteLine($"FirstName:{std_array[i].FirstName}");
                Console.WriteLine($"LastName:{std_array[i].LastName}");
                Console.WriteLine($"Roll:{std_array[i].Roll}");
                Console.WriteLine($"Marks:{std_array[i].Marks}");
            }
        }
    }
}
