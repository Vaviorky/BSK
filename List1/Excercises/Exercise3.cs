using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1.Excercises
{
    class Exercise3 //2b
    {
        public static void initHelperTable(int[,] matrix, int maxOnes)
        {
            int i = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (i < maxOnes)
                    {
                        matrix[row, col] = 1;
                        i++;
                    }
                    else
                    {
                        matrix[row, col] = 0;
                    }
                }
            }
        }

        public static void initValuesTable(char[,] matrix)
        {
            int i = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = '-';
                }
            }
        }

        public static void populateValuesTable(int[,] helper, char[,] values, string word)
        {
            int i = 0;
            for (int row = 0; row < helper.GetLength(0); row++)
            {
                for (int col = 0; col < helper.GetLength(1); col++)
                {
                    if (helper[row, col] == 1)
                    {
                        values[row, col] = word[i++];
                    }
                }
            }
        }

        public static void printHelperTable(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void printValuesTable(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string getEncrypted(int[,] helper, char[,] values, List<int> key)
        {
            string data = "";
            foreach (int k in key)
            {
                for (int c = 0; c < helper.GetLength(0); c++)
                {
                    if (helper[c, k - 1] == 1) data += values[c, k - 1];
                }
                //data += " ";
            }
            return data;
        }

        public static string getDecrypted(int[,] helper, char[,] values, List<int> key, string wordEncrypted)
        {
            string data = "";
            int counter = 0;

            foreach (int k in key)
            {
                for (int c = 0; c < helper.GetLength(0); c++)
                {
                    if (helper[c, k - 1] == 1) values[c, k - 1] = wordEncrypted[counter++];
                }
                //data += " ";
            }

            //for (int rowTemp = 0; rowTemp < values.GetLength(0); rowTemp++)
            //{
            //    foreach (int k in key)
            //    {
            //        if (helper[rowTemp, k - 1] == 1)
            //        {
            //            values[rowTemp, k - 1] = wordEncrypted[counter++];
            //        }
            //    }
            //}

            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int col = 0; col < values.GetLength(1); col++)
                {
                    if (helper[row, col] == 1)
                    {
                        data += values[row, col];
                    }
                }
            }

            return data;
        }

        public static List<int> getKeyInversed(List<int> key)
        {
            List<int> lista = new List<int>();
            int[] keyInverse = new int[key.Count];

            int forLoopCounter = 1;
            foreach (int k in key)
            {
                keyInverse[k - 1] = forLoopCounter;
                forLoopCounter++;
            }
            key.Clear();
            foreach (int VARIABLE in keyInverse)
            {
                lista.Add(VARIABLE);
            }

            return lista;
        }

        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - 2b");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();



            //trash
            List<int> key = new List<int>();

            string word = plaintext;
            string wordKey = keyInput;
            //wordKey = "AMD";
            //word = "CONVENIENCE";
            string wordEncrypted = "";

            List<char> alpbabetList = new List<char>();

            for (int i = 65; i < 91; i++)
            {
                alpbabetList.Add((char)i);
            }

            int[] keyTable = new int[wordKey.Length];

            int keyTableCounter = 1;
            foreach (char c in alpbabetList)
            {
                for (int p = 0; p < wordKey.Length; p++)
                {
                    if (wordKey[p] == c)
                    {
                        keyTable[p] = keyTableCounter;
                        keyTableCounter++;
                    }
                }
            }

            key.Clear();

            foreach (int x in keyTable)
            {
                key.Add(x);
            }

            key = getKeyInversed(key);
            int row = (int)Math.Ceiling((float)word.Length / key.Count);
            int col = key.Count;
            int counter;

            int[,] matrixHelper = new int[row, col];
            char[,] matrixValues = new char[row, col];


            

            initHelperTable(matrixHelper, word.Length);

            initValuesTable(matrixValues);

           
            populateValuesTable(matrixHelper, matrixValues, word);


            counter = 0;
            wordEncrypted = getEncrypted(matrixHelper, matrixValues, key);

            Console.WriteLine(wordEncrypted);
            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 3 - 2b");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do odszyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();



            // DECRYPT
            List<int> key = new List<int>();
            string wordKey = keyInput;
            string wordEncrypted = plaintext;

            int[] keyTable = new int[wordKey.Length];

            List<char> alpbabetList = new List<char>();

            for (int i = 65; i < 91; i++)
            {
                alpbabetList.Add((char)i);
            }

            int keyTableCounter = 1;
            foreach (char c in alpbabetList)
            {
                for (int p = 0; p < wordKey.Length; p++)
                {
                    if (wordKey[p] == c)
                    {
                        keyTable[p] = keyTableCounter;
                        keyTableCounter++;
                    }
                }
            }

            key.Clear();

            foreach (int x in keyTable)
            {
                key.Add(x);
            }

            key = getKeyInversed(key);

            int row = (int)Math.Ceiling((float)wordEncrypted.Length / key.Count);
            int col = key.Count;
            int[,] matrixHelper = new int[row, col];
            char[,] matrixValues = new char[row, col];

            initHelperTable(matrixHelper, wordEncrypted.Length);

            initValuesTable(matrixValues);

            string wordDecryptedFromEncrypted = getDecrypted(matrixHelper, matrixValues, key, wordEncrypted);
            
            Console.WriteLine();
            Console.WriteLine(wordDecryptedFromEncrypted);

            Console.ReadKey();
        }
    }
}
