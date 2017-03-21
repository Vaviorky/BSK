using System;
using List2.Exercises.ClassZad2;

namespace List2.Exercises
{
    public static class Exercise3
    {
        public static void Encrypt()
        {

            string dictWord;
            string seed;

            string input, output;
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - Ciphertext Autokey - Szyfrowanie");
            Console.WriteLine();

            Console.Write("Podaj wielomian np. 1001: ");
            dictWord = Console.ReadLine();

            Console.Write("Podaj seed np. 1010: ");
            seed = Console.ReadLine();

            Console.Write("Podaj input file: ");
            input = Console.ReadLine();

            Console.Write("Podaj output file: ");
            output = Console.ReadLine();

            LFSR3 lfsr = new LFSR3(dictWord, seed);
            LFSR_3_File lfsr3File = new LFSR_3_File(lfsr,"TestFiles/"+input, "TestFiles/" + output);

            lfsr3File.Encode();

            Console.ReadKey();

        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - Ciphertext Autokey - Deszyfrowanie");
            Console.WriteLine();


        }
    }
}