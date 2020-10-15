using Microsoft.VisualBasic.CompilerServices;
using System;

namespace NewNamespace
{
    class Program
    {
        static bool IsCorrectForm(int variable)
        {
            if (variable >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int ReadVariable()
        {
            int result;
            if (Int32.TryParse(Console.ReadLine(), out result) && (IsCorrectForm(result)))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Некорректные данные. Попробуйте ещё раз.");
                return ReadVariable();
            }
        }
        static int GetFactorial(int x)
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
        static int GetLenght(int variable, int result)
        {
            var lenghtOfVariable = variable.ToString().Length;
            var lenghtOfResult = result.ToString().Length;
            var lenght = lenghtOfResult + lenghtOfVariable + 6; // 4 пробела (два с боку и два около знака '=') и 2 символа '!','='
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
        static void WriteBox(int variable, char beginSym, char centerSym, char endSym, int result)
        {
            Console.Write(beginSym);
            Console.Write($" {variable}! = {result} ");
            Console.WriteLine(endSym);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение факториала.");
            int variable = ReadVariable();
            var result = GetFactorial(variable);
            var lenght = GetLenght(variable, result);
            WriteBox(lenght, '╓', '─', '╖');
            WriteBox(variable, '║', ' ', '║', result);
            WriteBox(lenght, '╙', '─', '╜');
           // Console.WriteLine($"╓─────╖ ");
           // Console.WriteLine($" ║ {result} ║");
           // Console.WriteLine($" ╙ ───── ╜ ");

        }
    }
}