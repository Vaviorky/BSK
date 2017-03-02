using System;
using System.Collections.Generic;
using static System.Int32;

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
            var isNumeric = TryParse(key, out keynumber);
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
            var cipherText = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var key = Console.ReadLine();
            if (key != null)
            {
                var keyint = Parse(key);
                if (cipherText != null)
                {
                    var cipherLength = cipherText.Length;
                    var railfence = new List<List<int>>();

                    for (int i = 0; i < keyint; i++)
                    {
                        railfence.Add(new List<int>());
                    }

                    int number = 0, increment = 1;

                    for (int i = 0; i < cipherLength; i++)
                    {
                        if (number + increment == keyint)
                        {
                            increment = -1;
                        }
                        else if (number + increment == -1)
                        {
                            increment = 1;
                        }
                        railfence[number].Add(i);
                        number += increment;
                    }

                    var counter = 0;

                    var output = new char[cipherLength];

                    for (var i = 0; i < keyint; i++)
                    {
                        for (var j = 0; j < railfence[i].Count; j++)
                        {
                            output[railfence[i][j]] = cipherText[counter];
                            counter++;
                        }
                    }
                    var outp = new string(output);
                    Console.WriteLine("Ciąg odszyfrowany: " + outp);
                }
            }
            Console.ReadKey();
        }
    }
}