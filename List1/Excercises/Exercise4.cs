using System;
using System.Collections.Generic;

namespace List1.Excercises
{
    internal class Exercise4
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 4 - Szyfrowanie Cezara");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj k0: ");
            var k0 = int.Parse(Console.ReadLine());
            Console.Write("Podaj k1: ");
            var k1 = int.Parse(Console.ReadLine());

            text = text.ToUpper();

            char[] Alfabet = getAlfabetTable();

            var output = "";

            foreach (char cc in text)
            {
                output += getCharEncodeCaesar(cc, Alfabet, getShift(cc, Alfabet), k0, k1);
            }
            Console.WriteLine();

            Console.WriteLine("Ciąg zaszyfrowany: " + output);
            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 4 - Szyfrowanie Cezara");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do deszyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj k0: ");
            var k0 = int.Parse(Console.ReadLine());
            Console.Write("Podaj k1: ");
            var k1 = int.Parse(Console.ReadLine());

            text = text.ToUpper();
            char[] Alfabet = getAlfabetTable();

            var output = "";
            const int n = 26;
            const int fi = 12;

            foreach (char cc in text)
            {
                output += getCharDecodeCaesar(cc, Alfabet, k0, k1, fi);
            }
            Console.WriteLine();

            Console.WriteLine("Ciąg odszyfrowany: " + output);
            Console.ReadKey();
        }

        private static long Power(int n, int k)
        {
            if (k == 0)
                return 1;
            if (k % 2 == 0)
                return Power(n, k / 2) * Power(n, k / 2);
            return n * Power(n, k / 2) * Power(n, k / 2);
        }

        private static int ModuloPower(int x, int power, int modulo)
        {
            int suma = 1;
            int temp = 0;
            var table = Convert.ToString(power, 2);
            int multiplier = 1;
            bool tempIsSet = false;

            for (int i = table.Length - 1; i >= 0; i--)
            {
                if (tempIsSet)
                {
                    temp = (temp * temp) % modulo;
                }
                else
                {
                    temp = (int)Math.Pow(x, multiplier);
                    tempIsSet = true;
                }
                multiplier *= 2;
                if (table[i] == '1') suma = suma * temp;
            }

            return suma % modulo;
        }

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

        public static char getCharEncodeCaesar(char c, char[] alfabet, int a, int k0, int k1)
        {
            int charShift = ((a * k1) + k0) % alfabet.Length;
            return alfabet[charShift];
        }

        public static char getCharDecodeCaesar(char c, char[] alfabet, int k0, int k1, int fi)
        {
            int n = alfabet.Length;

            int parA = (getShift(c, alfabet) + (n - k0)) % n;
            if (parA < 0) parA += n;

            int tmp = (parA * ModuloPower(k1, fi - 1, n)) % n;

            return alfabet[tmp];
        }

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

        public static long getPower(int n, int k)
        {
            if (k == 0)
            {
                return 1;
            }
            if (k % 2 == 0)
            {
                return getPower(n, k / 2) * getPower(n, k / 2);
            }
            return n * getPower(n, k / 2) * getPower(n, k / 2);
        }
    }
}