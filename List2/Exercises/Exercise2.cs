using System;
using List2.Exercises.ClassZad2;

namespace List2.Exercises
{
    public static class Exercise2
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 2 - Synchronous Stream Cipher - Szyfrowanie");
            Console.WriteLine();

            string dictWord;
            string seed;

            string input, output;

            Console.Write("Podaj wielomian np. 1001: ");
            dictWord = Console.ReadLine();

            Console.Write("Podaj seed np. 1010: ");
            seed = Console.ReadLine();

            Console.Write("Podaj input file: ");
            input = Console.ReadLine();

            Console.Write("Podaj output file: ");
            output = Console.ReadLine();


            LFSR o = new LFSR(dictWord, seed);
            //input = "C:/biomet/output.bin";
            //input = "C:/biomet/Lenna1.png";
            //output = "C:/biomet/fromBin.png";

            LFSR_2_File zad2 = new LFSR_2_File(o, input, output);
            zad2.DoWork();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 2 - Synchronous Stream Cipher - Deszyfrowanie");
            Console.WriteLine();


        }
    }
}