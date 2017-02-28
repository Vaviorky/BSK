using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class Program
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
                    Console.Write(matrix[row, col]+" ");
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

        public static string getEncrypted(int[,] helper, char[,] values, List<int> key )
        {
            string data = "";
            for (int rowTemp = 0; rowTemp < values.GetLength(0); rowTemp++)
            {
                foreach (int k in key)
                {
                    if (helper[rowTemp, k - 1] == 1)
                    {
                        //matrixValues[rowTemp, k - 1] = word[counter++];
                        //Console.Write(matrixValues[rowTemp,k-1]);
                        data += values[rowTemp, k - 1];
                    }
                }
            }
            return data;
        }

        public static string getDecrypted(int[,] helper, char[,] values, List<int> key, string wordEncrypted)
        {
            string data = "";
            int counter = 0;
            for (int rowTemp = 0; rowTemp < values.GetLength(0); rowTemp++)
            {
                foreach (int k in key)
                {
                    if (helper[rowTemp, k - 1] == 1)
                    {
                        values[rowTemp, k - 1] = wordEncrypted[counter++];
                    }
                }
            }

            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int col = 0; col < values.GetLength(1); col++)
                {
                    if (helper[row, col]==1)
                    {
                        data += values[row, col];
                    }
                }
            }

            return data;
        }

        static void Main(string[] args)
        {
            List<int> key = new List<int>();
            key.Add(3);
            key.Add(4);
            key.Add(1);
            key.Add(5);
            key.Add(2);

            key.Clear();
            key.Add(3);
            key.Add(1);
            key.Add(4);
            key.Add(2);

            string word = "CRYPTOGRAPHYOSA";
            string wordEncrypted = "";

            int row = (int)Math.Ceiling((float)word.Length / key.Count);
            int col = key.Count;
            int counter;

            int[,] matrixHelper = new int[row, col];
            char[,] matrixValues = new char[row, col];


            Console.WriteLine(word);
            Console.WriteLine();

            initHelperTable(matrixHelper, word.Length);
            printHelperTable(matrixHelper);

            initValuesTable(matrixValues);

            Console.WriteLine();
            populateValuesTable(matrixHelper, matrixValues, word);
            printValuesTable(matrixValues);
            Console.WriteLine();


            counter = 0;
            wordEncrypted = getEncrypted(matrixHelper, matrixValues, key);

            Console.WriteLine(wordEncrypted);
            Console.WriteLine("######################################### \n --- DECRYPTING ...");

            //decrypt - right here

            wordEncrypted = "YCPRGTROHAYPAOS";
            wordEncrypted = "DARMEYNZUCP";

            initHelperTable(matrixHelper, wordEncrypted.Length);
            printHelperTable(matrixHelper);

            initValuesTable(matrixValues);
            printValuesTable(matrixValues);

            string wordDecryptedFromEncrypted = getDecrypted(matrixHelper, matrixValues, key, wordEncrypted);

            //wordDecryptedFromEncrypted = "DUPA";

            printValuesTable(matrixValues);
            Console.WriteLine();
            Console.WriteLine(wordDecryptedFromEncrypted);
        }
    }
}
