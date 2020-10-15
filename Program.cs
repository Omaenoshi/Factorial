using System;
using System.Drawing;

namespace NewNamespace
{
    class Program
    {
        static bool IsCorrectForm(string str, out int result)
        {
            if (str.Contains('!'))
            {
                str = str.Replace("!", null);
            }
            return Int32.TryParse(str, out result);
        }

        static int ReadVariable()
        {
            int result;
            string variable = Console.ReadLine();
            if (IsCorrectForm(variable, out result) && result >= 0)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Некорректные данные. Попробуйте ещё раз.");
                return ReadVariable();
            }
        }
        static long GetFactorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * GetFactorial(x - 1);
            }
        }
        static int GetLenght(int variable, long result)
        {
            var lenghtOfVariable = variable.ToString().Length;
            var lenghtOfResult = result.ToString().Length;
            var lenght = lenghtOfResult + lenghtOfVariable + 6; // 4 пробела (два по бокам и два по обе стороны знака '=') и 2 символа '!','='
            return lenght;
        }
        static void WriteBox(int variable, char beginSym, char centerSym, char endSym)
        {
            Console.Write(beginSym);
            for (int i = 0; i < variable; i++)
            {
                Console.Write(centerSym);
            }
            Console.WriteLine(endSym);
        }
        static void WriteBox(int variable, char beginSym, char endSym, long result)
        {
            Console.Write(beginSym);
            Console.Write($" {variable}! = {result} ");
            Console.WriteLine(endSym);
        }
        static void BlinkBox(int lenght, int variable, long result)
        {
            SetCursor(3, lenght);
            WriteBox(lenght, '╓', '─', '╖');
            SetCursor(2, lenght);
            WriteBox(variable, '║', '║', result);
            SetCursor(1, lenght);
            WriteBox(lenght, '╙', '─', '╜');
        }
        static void SetCursor(int step, int lenght)
        {
            int centerlenght = lenght + 2;
            int x = Console.WindowWidth;
            int y = Console.WindowHeight;
            Console.SetCursorPosition((x / 2 - centerlenght / 2), (y / 2 - 3/2 - step)); // 3 на 2 потому что у таблички 3 строчки
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите факториал.");
            int variable = ReadVariable();
            var result = GetFactorial(variable);
            var lenght = GetLenght(variable, result);
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                BlinkBox(lenght, variable, result);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                BlinkBox(lenght, variable, result);
                Console.BackgroundColor = ConsoleColor.Black;
                System.Threading.Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}