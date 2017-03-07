using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1.Excercises
{
    class Exercise6
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
                    Console.Write(matrixHelper[row, col] + " ");
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
                        if (row % key.Length == (key[col] - 1))
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
                    Console.Write(matrixValues[row, col] + " ");
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
                    if (matrixHelper[row, k - 1] == 1)
                    {
                        matrixValues[row, k - 1] = word[counter++];
                    }
                }
            }
        }

        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - 2c");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();

            string keyToProceed = keyInput;
            int[] key = getKey(keyToProceed);

            int[] keyInverse = new int[key.Length];

            int forLoopCounter = 1;
            foreach (int k in key)
            {
                keyInverse[k - 1] = forLoopCounter;
                forLoopCounter++;
            }

            string word = plaintext;

            div = word.Length / key.Length;

            int[,] matrixHelper = new int[div * key.Length, key.Length];
            char[,] matrixValues = new char[div * key.Length, key.Length];

            initTableHelper(matrixHelper);
            populateTableHelper(matrixHelper, word.Length, key);
            initTableValues(matrixValues);
            populateTableValues(matrixHelper, matrixValues, word);

            Console.WriteLine();

            string wordEncrypted = getEncrypted(matrixHelper, matrixValues, keyInverse);
            Console.WriteLine(wordEncrypted);
            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - 2c");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do deszyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();

            string wordEncrypted = plaintext;
            string keyToProceed = keyInput;

            int[] key = getKey(keyToProceed);

            int[] keyInverse = new int[key.Length];

            int forLoopCounter = 1;
            foreach (int k in key)
            {
                keyInverse[k - 1] = forLoopCounter;
                forLoopCounter++;
            }

            div = plaintext.Length / key.Length;

            int[,] matrixHelper = new int[div * key.Length, key.Length];
            char[,] matrixValues = new char[div * key.Length, key.Length];
            initTableHelper(matrixHelper);
            populateTableHelper(matrixHelper, wordEncrypted.Length, key);
            initTableValues(matrixValues);
            populateTableValuesFromEncrypted(matrixHelper, matrixValues, wordEncrypted, keyInverse);

            string wordDecrypted = getDecrypted(matrixHelper, matrixValues);
            Console.WriteLine(wordDecrypted);
            Console.ReadKey();
        }
    }
}
