using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar
{
    class Program
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

        public static char getCharEncodeCaesar(char c, char[] alfabet, int a, int k0, int k1)
        {
            int charShift = ((a * k1) + k0) % alfabet.Length;
            return alfabet[charShift];
        }

        public static char getCharDecodeCaesar(char c, char[] alfabet, int k0, int k1, int fi)
        {
            int n = alfabet.Length;

            int parA = (getShift(c,alfabet) + (n - k0)) % n;
            if (parA < 0) parA += n;

            int tmp = (parA * ModuloPower(k1, fi - 1, n)) % n;

            return alfabet[tmp];
        }

        //public static string getStringEncodeCaesar(string input, int shift, char[] alfabet)
        //{
        //    input = input.ToUpper();
        //    string output = "";

        //    foreach (char c in input)
        //    {
        //        output += getCharEncodeCaesar(c, shift, alfabet);
        //    }

        //    return output;
        //}

        //public static string getStringDecodeCaesar(string input, int shift, char[] alfabet)
        //{
        //    input = input.ToUpper();
        //    string output = "";

        //    foreach (char c in input)
        //    {
        //        output += getCharDecodeCaesar(c, shift, alfabet);
        //    }

        //    return output;
        //}

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

        static void Main(string[] args)
        {
            char[] Alfabet = getAlfabetTable();

            string word = "ABC";

            int a = getShift('A',Alfabet);

            int n = Alfabet.Length;

            int k0 = 103;
            int k1 = 123;
            int fi = 12;

            //int c = ((a * k1) + k0) % Alfabet.Length;
            //Console.WriteLine(c);

            string input = "DUPA";
            string output = "EPYZ";

            foreach (char cc in input)
            {
                Console.Write(getCharEncodeCaesar(cc,Alfabet,getShift(cc,Alfabet),k0,k1));
            }
            Console.WriteLine();

            foreach (char cc in output)
            {
                Console.Write(getCharDecodeCaesar(cc,Alfabet,k0,k1,fi));
            }
            Console.WriteLine();

            char c = getCharEncodeCaesar('A', Alfabet, a, k0, k1);

            char tmp = getCharDecodeCaesar('Z', Alfabet, k0, k1, fi);

            //Console.WriteLine(c);
            //Console.WriteLine(tmp);

            //int parA = (c + (n - k0)) % n;
            //if (parA < 0) parA += n;

            //int tmp = (parA * ModuloPower(k1, fi - 1, n)) % n;
            //Console.WriteLine(tmp);

            //Console.WriteLine(c);
            //Console.WriteLine(tmp);

            //Console.WriteLine(getShift('C',Alfabet));

            //int c = (a * k0 + k1) % Alfabet.Length;
            //Console.WriteLine(c);

            //a = (int)(((c - k1) * getPower(k0, 11))%Alfabet.Length);

            //Console.WriteLine(a);

            //string wordEncoded = "";
            //string wordDecoded = "";

            //wordEncoded = getStringEncodeCaesar(word, 1, Alfabet);
            //Console.WriteLine(word+" enc -> "+wordEncoded);

            //wordEncoded = "RTQEGUQTCOF";

            //wordDecoded = getStringDecodeCaesar(wordEncoded, 2, Alfabet);
            //Console.WriteLine(wordEncoded + " dec -> " + wordDecoded);
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
    }
}
