using System;
using System.Collections.Generic;

namespace List1.Excercises
{
    internal class Exercise2
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 1 - Rail fence");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var keyinput = Console.ReadLine();
            var key = new List<int>();
            if (keyinput != null)
                foreach (var ki in keyinput)
                {
                    int number;
                    var isNumber = int.TryParse(ki.ToString(), out number);
                    if (isNumber)
                        key.Add(number);
                }

            Console.Write("Ciąg zaszyfrowany: ");
            for (var i = 0; i < key.Count; i++)
            {
                foreach (var k in key)
                {

                    if (i + 1 == key.Count)
                    {
                        if (text != null && text.Length % key.Count >= k)
                        {
                            var x = (text.Length % key.Count);
                            Console.Write(text[(k - 1) + key.Count * i]);

                        }
                    }
                    else
                    {
                        if (text != null) Console.Write(text[(k - 1) + key.Count * i]);
                    }
                }

            }
            Console.ReadKey();
        }

        public static void Decrypt()
        {
        }
    }
}