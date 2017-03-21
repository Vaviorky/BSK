using System;
using List2.Exercises.ClassZad2;

namespace List2.Exercises
{
    public static class Exercise3
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - Ciphertext Autokey - Szyfrowanie");
            Console.WriteLine();

            string dict = "100101";
            string seed = "110010";
            LFSR3 lfsr = new LFSR3(dict,seed);

            LFSR_3_File lfsr3File = new LFSR_3_File(lfsr,"TestFiles/prep0.bin","TestFiles/prepOUT.bin");

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