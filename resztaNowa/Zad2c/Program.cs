using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zad2c
{
    class Program
    {
        public static int div;

        public static int[] getKey(string word)
        {
            int[] tablica = new int[word.Length];

            List<char> alpbabetList = new List<char>();

            for (int i = 65; i < 91; i++)
            {
                alpbabetList.Add((char)i);
            }

            int keyTableCounter = 1;
            foreach (char c in alpbabetList)
            {
                for (int p = 0; p < word.Length; p++)
                {
                    if (word[p] == c)
                    {
                        tablica[p] = keyTableCounter;
                        keyTableCounter++;
                    }
                }
            }

            return tablica;
        }

        public static void initTableHelper(int[,] matrixHelper)
        {
            for (int row = 0; row < matrixHelper.GetLength(0); row++)
            {
                for (int col = 0; col < matrixHelper.GetLength(1); col++)
                {
                    matrixHelper[row, col] = 0;
                }
            }
        }

        public static void printTableHelper(int[,] matrixHelper)
        {
            for (int row = 0; row < matrixHelper.GetLength(0); row++)
            {
                for (int col = 0; col < matrixHelper.GetLength(1); col++)
                {
                    Console.Write(matrixHelper[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        public static void populateTableHelper(int[,] matrixHelper, int length, int[] key)
        {
            int counter = 0;
            for (int row = 0; row < matrixHelper.GetLength(0); row++)
            {
                for (int col = 0; col < matrixHelper.GetLength(1); col++)
                {
                    if (counter < length)
                    {
                        matrixHelper[row, col] = 1;
                        if (row%key.Length == (key[col] - 1))
                        {
                            counter++;
                            break;
                        }
                        counter++;
                    }
                }
            }
        }

        public static void populateTableValues(int[,] matrixHelper, char[,] matrixValues, string word)
        {
            int counter = 0;
            for (int row = 0; row < matrixHelper.GetLength(0); row++)
            {
                for (int col = 0; col < matrixHelper.GetLength(1); col++)
                {
                    if (matrixHelper[row, col] == 1)
                    {
                        matrixValues[row, col] = word[counter++];
                    }
                }
            }
        }

        public static void initTableValues(char[,] matrixValues)
        {
            for (int row = 0; row < matrixValues.GetLength(0); row++)
            {
                for (int col = 0; col < matrixValues.GetLength(1); col++)
                {
                    matrixValues[row, col] = '-';
                }
            }
        }

        public static void printTableValues(char[,] matrixValues)
        {
            for (int row = 0; row < matrixValues.GetLength(0); row++)
            {
                for (int col = 0; col < matrixValues.GetLength(1); col++)
                {
                    Console.Write(matrixValues[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        public static string getEncrypted(int[,] matrixHelper, char[,] matrixValues, int[] key)
        {
            string data = "";
            foreach (int k in key)
            {
                for (int c = 0; c < matrixHelper.GetLength(0); c++)
                {
                    if (matrixHelper[c, k - 1] == 1) data += matrixValues[c, k - 1];
                }
                //Console.Write(" ");
                //data += " ";
            }
            return data;
        }

        public static string getDecrypted(int[,] matrixHelper, char[,] matrixValues)
        {
            string data = "";

            for (int row = 0; row < matrixHelper.GetLength(0); row++)
            {
                for (int col = 0; col < matrixHelper.GetLength(1); col++)
                {
                    if (matrixHelper[row, col] == 1)
                    {
                        data += matrixValues[row, col];
                    }
                }
            }

            return data;
        }

        public static void populateTableValuesFromEncrypted(int[,] matrixHelper, char[,] matrixValues, string word, int[] key)
        {
            int counter = 0;
            foreach (int k in key)
            {
                for (int row = 0; row < matrixHelper.GetLength(0); row++)
                {
                    if (matrixHelper[row,k-1] == 1)
                    {
                        matrixValues[row, k - 1] = word[counter++];
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string keyToProceed = "CONVENIENCE";
            keyToProceed = "ALA";
            //keyToProceed = keyToProceed.ToUpper();
            //Console.WriteLine(keyToProceed);
            int[] key = getKey(keyToProceed);

            //foreach (var VARIABLE in key)
            //{
            //    Console.WriteLine(VARIABLE);
            //}

            int[] keyInverse = new int[key.Length];

            int forLoopCounter = 1;
            foreach (int k in key)
            {
                keyInverse[k - 1] = forLoopCounter;
                forLoopCounter++;
            }

            string word = "alamakotaidwapsy";

            div = word.Length / key.Length;

            int[,] matrixHelper = new int[div*key.Length,key.Length];
            char[,] matrixValues = new char[div*key.Length,key.Length];

            initTableHelper(matrixHelper);
            printTableHelper(matrixHelper);

            //Console.WriteLine();

            Console.Clear();

            populateTableHelper(matrixHelper,word.Length, key);
            printTableHelper(matrixHelper);

            //Console.WriteLine();

            initTableValues(matrixValues);
            //printTableValues(matrixValues);

            //Console.WriteLine();
            populateTableValues(matrixHelper,matrixValues,word);
            printTableValues(matrixValues);

            //Console.WriteLine();

            string wordEncrypted = getEncrypted(matrixHelper, matrixValues, keyInverse);
            Console.WriteLine(wordEncrypted);

            Console.WriteLine();

            //decrypt
            //zmiana slowa
            wordEncrypted = "alaotdapmiyakaws";
            keyToProceed = "ALA";

            key = getKey(keyToProceed);

            foreach (var VARIABLE in key)
            {
                Console.WriteLine(VARIABLE);
            }

            keyInverse = new int[key.Length];

            forLoopCounter = 1;
            foreach (int k in key)
            {
                keyInverse[k - 1] = forLoopCounter;
                forLoopCounter++;
            }

            div = word.Length / key.Length;
            Console.WriteLine(div);

            matrixHelper = new int[div * key.Length, key.Length];
            matrixValues = new char[div * key.Length, key.Length];




            initTableHelper(matrixHelper);
            populateTableHelper(matrixHelper, wordEncrypted.Length, key);


            initTableValues(matrixValues);
            populateTableValuesFromEncrypted(matrixHelper, matrixValues, wordEncrypted, keyInverse);

            Console.WriteLine();

            printTableValues(matrixValues);

            string wordDecrypted = getDecrypted(matrixHelper, matrixValues);
            Console.WriteLine(wordDecrypted);
        }
    }
}
