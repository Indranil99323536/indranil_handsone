﻿using System;
using hello_world;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");*/


            Calculator calc = new Calculator();
            calc.x = 10;
            calc.y = 20;
            int result = calc.Add();
            Console.WriteLine(result);


        }
    }
}
