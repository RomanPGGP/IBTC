using System;

namespace PracticeTest
{
    class Program
    {

        static void Main(string[] args)
        {   
            //------------ FINAL EXAM -------------------------------------

            // Print name and date
            Console.WriteLine("------------Print name and date------------");
            GetMyInfo();

            //Length of string
            Console.WriteLine("\n------------Length of string------------");
            string ph;
            ph = Console.ReadLine();
            Console.WriteLine(StrLen(ph));

            // ODD / EVEN
            Console.WriteLine("\n------------ODD / EVEN------------");

            int x;
            try
            {
                x = int.Parse(Console.ReadLine());
                getOddEven(x);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Count to 10
            Console.WriteLine("\n------------Count to 10------------");
            count2Ten();

            //Multiplies or adds up
            Console.WriteLine("\n------------Multiplies or adds up------------");
            Console.WriteLine("Write 2 numbers:");
            int y;
            try
            {
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());
                Console.WriteLine("Multiplication press(1) Sum press (2)");
                int z = int.Parse(Console.ReadLine());
                if (z > 2)
                {
                    Console.WriteLine("Option not valid. Setting it to closest valid option. Sum.");
                    z = 2;
                }
                else if(z < 1)
                {
                    Console.WriteLine("Option not valid. Setting it to closest valid option. Mult.");
                    z = 1;
                }
                bool option = z == 1;
                twoNumbersOperation(x, y, option);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Day of the week
            Console.WriteLine("\n------------Day of the week------------");
            try
            {

                DateTime.TryParse(Console.ReadLine(), out DateTime dt);
                Console.WriteLine(getDay(dt));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            // Negative or positive
            Console.WriteLine("\n------------Negative or positive------------");
            Console.WriteLine("Write a number:");
            try
            {
                x = int.Parse(Console.ReadLine());
                negOrPos(x);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Array to upper
            Console.WriteLine("\n------------Array to upper------------");
            try
            {
                string[] strArr = Console.ReadLine().Split(' ');
                str2Upper(strArr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Merge arrays
            Console.WriteLine("\n------------Merge arrays------------");
            int[] arr1;
            int[] arr2;

            try
            {

                Console.WriteLine("First array in 1 line:");
                string[] tk = Console.ReadLine().Split(' ');
                arr1 = Array.ConvertAll(tk, int.Parse);

                Console.WriteLine("Second array in 1 line:");
                tk = Console.ReadLine().Split(' ');
                arr2 = Array.ConvertAll(tk, int.Parse);

                mergeOrderArrays(arr1, arr2);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            // Factorial
            Console.WriteLine("\n------------Factorial------------");
            Console.WriteLine("Write the number to get the factorial: ");
            try
            {

                x = int.Parse(Console.ReadLine());
                Console.WriteLine(GetFact(x));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        // Ex. 1
        static public void GetMyInfo()
        {
            Console.WriteLine("Roman Perez Garcia " + DateTime.Now);
        }

        // Ex. 2
        static public int StrLen(string str)
        {
            return str.Length;
        }

        // Ex. 3
        static public void getOddEven(int n)
        {
            if (n % 2 == 0) Console.WriteLine("EVEN");
            else if (n % 2 != 0) Console.WriteLine("ODD");
        }

        // Ex. 4
        static public void count2Ten()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }

        // Ex. 5
        static public void twoNumbersOperation(int n1, int n2, bool m)
        {
            if (m) Console.WriteLine(n1 * n2);
            else Console.WriteLine(n1 + n2);
        }

        // Ex. 6
        static public DayOfWeek getDay(DateTime dt)
        {
            return dt.DayOfWeek;
        }

        // Ex. 7
        static public void negOrPos(int n)
        {
            if (n < 0) Console.WriteLine("NEGATIVE");
            else Console.WriteLine("POSITIVE");
        }

        // Ex. 8
        static public void str2Upper(string[] strArr)
        {
            string nstr = "";

            foreach (string wd in strArr)
            {
                nstr += wd + " ";
            }

            Console.WriteLine(nstr.ToUpper());
        }

        // Ex. 9
        static public void mergeOrderArrays(int[] a1, int[] a2)
        {
            int[] na = new int[ a1.Length + a2.Length ];
            a1.CopyTo(na, 0);
            a2.CopyTo(na, a1.Length);

            Array.Sort(na);

            foreach(int n in na)
            {
                Console.Write(n + " ");
            }
        }

        // Ex. 10
        static public int GetFact(int n)
        {
            if (n == 1) return 1;

            return n * GetFact(n - 1);
        }

        //--------------------------------Not Final Examn-------------------------------------------
        static public void GetFactorial(int n)
        {
            int factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }

        static public void TimeConverter(int n)
        {
            int h=0;
            while (n > 60)
            {
                h++;
                n -= 60;
            }

            Console.WriteLine($"{h}:{n}");
        }

        static public string NumComp(int n1, int n2)
        {
            string res;

            if(n1>n2)
            {
                res = "false";
            }
            else if(n1<n2)
            {
                res = "true";
            }
            else
            {
                res = "-1";
            }

            return res;
        }

        static public void LetterCapitalize(string phrase)
        {
            string[] wrd;
            string fwrd;
            wrd = phrase.Split(' ');

            foreach (string wd in wrd)
            {
                fwrd = char.ToUpper(wd[0]) + wd.Substring(1);
                Console.Write(fwrd + ' ');
            }
        }
    }
}
