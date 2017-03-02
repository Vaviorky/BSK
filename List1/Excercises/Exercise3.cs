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
            Console.WriteLine("Zadanie 5 - Vigenere");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            var keyInput = Console.ReadLine();
        }

        public static void Decrypt()
        {

        }
    }
}
