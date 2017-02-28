using System;
using System.Collections.Generic;

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
                var railfence = new List<string>();
                for (var i = 0; i < keynumber; i++)
                    railfence.Add("");
                var number = 0;
                var increment = 1;
                if (plaintext != null)
                    foreach (var c in plaintext)
                    {
                        if (number + increment == keynumber)
                            increment = -1;
                        else if (number + increment == -1)
                            increment = 1;
                        railfence[number] += c;
                        number += increment;
                    }
                var buffer = "";
                foreach (var s in railfence)
                {
                    buffer += s;
                }
                Console.WriteLine("Ciąg zaszyfrowany: "+buffer);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("To nie jest wartosć liczbowa");
                Console.ReadKey();
            }
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 1 - Rail fence");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do deszyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var key = Console.ReadLine();


        }
    }
}