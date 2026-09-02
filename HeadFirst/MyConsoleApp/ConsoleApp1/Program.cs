using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //int a = 15;                 // 0b00001111
            //int b = 25;                 // 0b00011001
            //int c = a ^ b;              // 0b00010110 => 16 + 4 + 2 = 22
            //Console.WriteLine(c);

            //// Question 1
            //int count = 5;
            //int rewind = 0;
            //while (count > 0)           // 촣2회 반복 -> 1회 (count가 0보다 크면 반복해서 실행)
            //{
            //    count = count * 3;
            //    count = count * -1;
            //    rewind++;
            //}

            //Console.WriteLine("count : " + count + ", " + rewind + "회");
            //rewind = 0;

            //// Question 2
            //int j = 2;
            //for(int i = 1; i < 100; i = i * 2)
            //{
            //    j = j - 1;
            //    while (j < 25)
            //    {
            //        // 아래 명령문은 몇 번이나 실행?
            //        j = j + 5;
            //        rewind++;
            //    }
            //}

            //Console.WriteLine(rewind + "회");
            //rewind = 0;

            //// Question 3
            //int p = 2;

            //for(int q = 2; q < 32; q = q * 2)
            //{
            //    while (p < q)
            //    {
            //        // 아래 명렴문은 몇 번이나 실행?
            //        p = p * 2;
            //        rewind++;
            //    }
            //    q = p - q;
            //}

            //Console.WriteLine(rewind + "회");
            //rewind = 0;

            //// Question 4
            //int a = 0;
            //count = 2;
            //while (a == 0)
            //{
            //    count = count * 3;
            //    count = count - 1;
            //    rewind++;
            //}

            //Console.WriteLine(rewind + "회");
            TryAnIf();
            TrySomeLoops();
            TryAnIfElse();
        }

        private static void TryAnIfElse()
        {
            Console.WriteLine("Question 2");

            int x = 5;
            if (x == 10)
            {
                Console.WriteLine("x must be 10");
            }
            else
            {
                Console.WriteLine("x isn't");
            }
        }

        private static void TrySomeLoops()
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1; // count++;
            }
            for (int i = 0; i < 5; i++)
            {
                count = count - 1; // count--;
            }
            Console.WriteLine($"The answer is {count}");
        }

        private static void TryAnIf()
        {
            Console.WriteLine("Question 1");
            int someValue = 4;
            string name = "Bobbo Jr.";
            if ((someValue == 3) && (name == "Joe"))
            {
                Console.WriteLine($"x is 3 and the name is Joe");
            }
            Console.WriteLine($"this line runs no matter what. \n");            // 해당 문 선택
        }
    }
}
