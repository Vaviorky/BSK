﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cezar
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

        public static char getCharEncodeCaesar(char c, int shift, char[] alfabet)
        {
            return alfabet[(getShift(c,alfabet) + shift) % alfabet.Length];
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

        static void Main(string[] args)
        {
            char[] Alfabet = getAlfabetTable();

            string word = "CRYPTOGRAPHY";
            //word = "CRYPTOISSHORTFORCRYPTOGRAPHY";
            Console.WriteLine(word);

            int[] key = getKeyTable("BREAKBREAKBR", Alfabet);


            string wordEncoded = "";
            string wordDecoded = "";

            int keyCounter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (keyCounter == key.Length) keyCounter = 0;
                //Console.Write(getCharEncodeCaesar(word[i],key[keyCounter++],Alfabet));
                wordEncoded += getCharEncodeCaesar(word[i], key[keyCounter++], Alfabet);
            }

            Console.WriteLine(wordEncoded);

            //decode
            keyCounter = 0;
            for (int i = 0; i < wordEncoded.Length; i++)
            {
                if (keyCounter == key.Length) keyCounter = 0;
                //Console.Write(getCharEncodeCaesar(word[i],key[keyCounter++],Alfabet));
                wordDecoded += getCharDecodeCaesar(wordEncoded[i], key[keyCounter++], Alfabet);
            }

            Console.WriteLine(wordDecoded);
        }
    }
}
