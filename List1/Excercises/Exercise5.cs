using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1.Excercises
{
    class Exercise5
    {
        public static char[] getAlfabetTable()
        {
            List<char> alpbabetList = new List<char>();

            for (int i = 65; i < 91; i++)
            {
                alpbabetList.Add((char)i);
            }

            char[] alfabet = alpbabetList.ToArray();

            return alfabet;
        }

        public static int getShift(char c, char[] alfabet)
        {
            for (int i = 0; i < alfabet.Length; i++)
            {
                if (alfabet[i] == c) return i;
            }

            throw new NotImplementedException();
        }

        public static char getCharEncodeCaesar(char c, int shift, char[] alfabet)
        {
            return alfabet[(getShift(c, alfabet) + shift) % alfabet.Length];
        }

        public static char getCharDecodeCaesar(char c, int shift, char[] alfabet)
        {
            int x = (getShift(c, alfabet) - shift) % alfabet.Length;

            if (x < 0) x = x + alfabet.Length;

            return alfabet[x];
        }

        public static string getStringEncodeCaesar(string input, int shift, char[] alfabet)
        {
            input = input.ToUpper();
            string output = "";

            foreach (char c in input)
            {
                output += getCharEncodeCaesar(c, shift, alfabet);
            }

            return output;
        }

        public static string getStringDecodeCaesar(string input, int shift, char[] alfabet)
        {
            input = input.ToUpper();
            string output = "";

            foreach (char c in input)
            {
                output += getCharDecodeCaesar(c, shift, alfabet);
            }

            return output;
        }

        //Vigenere

        public static int getPositionAlphabet(char c, char[] alphabet)
        {
            int counter = 0;
            foreach (char VARIABLE in alphabet)
            {
                if (VARIABLE == c) return counter;
                counter++;
            }
            throw new NotImplementedException();
        }

        public static int[] getKeyTable(string input, char[] alphabet)
        {
            int[] table = new int[input.Length];

            int counter = 0;
            foreach (char VARIABLE in input)
            {
                table[counter++] = getPositionAlphabet(VARIABLE, alphabet);
            }

            return table;
        }

        //Main :)

        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 5 - Vigenere");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();

            char[] Alfabet = getAlfabetTable();

            string word = plaintext.ToUpper();
            string wordEncoded = "";

            int[] key = getKeyTable(keyInput.ToUpper(), Alfabet);

            Console.WriteLine();

            int keyCounter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (keyCounter == key.Length) keyCounter = 0;
                //Console.Write(getCharEncodeCaesar(word[i],key[keyCounter++],Alfabet));
                wordEncoded += getCharEncodeCaesar(word[i], key[keyCounter++], Alfabet);
            }
            Console.WriteLine("Ciąg zaszyfrowany: " + wordEncoded);

            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 5 - Vigenere");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do deszyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();

            char[] Alfabet = getAlfabetTable();

            string word = plaintext.ToUpper();
            string wordDecoded = "";

            int[] key = getKeyTable(keyInput.ToUpper(), Alfabet);

            Console.WriteLine();

            int keyCounter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (keyCounter == key.Length) keyCounter = 0;
                //Console.Write(getCharEncodeCaesar(word[i],key[keyCounter++],Alfabet));
                wordDecoded += getCharDecodeCaesar(word[i], key[keyCounter++], Alfabet);
            }
            Console.WriteLine("Ciąg odszyfrowany: " + wordDecoded);

            Console.ReadKey();
        }

        //private static string GetAlphabet()
        //{
        //    return "ABCDEFGHIJKLMNOPRSTUVWXYZ";
        //}
    }
}
