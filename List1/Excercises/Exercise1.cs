using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1.Excercises
{
    public class Exercise1
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 1 - Rail fence");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var key = Console.ReadLine();
            int keynumber;
            var isNumeric = int.TryParse(key, out keynumber);
            if (isNumeric)
            {

            }
            else
            {
                Console.WriteLine("To nie jest wartosć liczbowa");
                Console.ReadKey();
            }
        }

        public static void Decrypt()
        {
            
        }
    }
}
