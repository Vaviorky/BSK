using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BSK_List_1
{
    class Program
    {
        public static void printTableInput(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void initTableInput(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = '-';
                }
            }
        }

        public static void printTable(int [,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void printEncrypted(int[,] matrix, char[,] data)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col]==1) Console.Write(data[row,col]);
                }
            }
        }

        public static string getEncrypted(int[,] matrix, char[,] data)
        {
            string end = "";
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1) end+=data[row, col];
                }
            }

            return end;
        }

        public static void initTable(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        public static string Encrpt(string input, int n)
        {
            int chars = input.Length;
            int[,] matrix = new int[n, chars];
            char[,] matrixInput = new char[n, chars];

            initTableInput(matrixInput);
            initTable(matrix);

            int kierunek = 0;
            int rowTemp = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (rowTemp == matrix.GetLength(0))
                {
                    kierunek = 1; //set to up
                    rowTemp -= 2;
                }

                if (rowTemp == -1)
                {
                    kierunek = 0; //set to up
                    rowTemp += 2;
                }

                if (kierunek == 0) // down
                {
                    matrix[rowTemp, col] = 1;
                    //Console.WriteLine(col);
                    matrixInput[rowTemp, col] = input[col];
                    rowTemp++;
                    continue;
                }

                if (kierunek == 1) // up
                {
                    matrix[rowTemp, col] = 1;
                    //Console.WriteLine(col);
                    matrixInput[rowTemp, col] = input[col];
                    rowTemp--;
                    continue;
                }
            }
            //string encrypted = getEncrypted(matrix, matrixInput);

            return getEncrypted(matrix, matrixInput);
        }

        public static string Decrypt(string input, int n)
        {
            int chars = input.Length;
            int[,] matrix = new int[n, chars];
            char[,] matrixInput = new char[n, chars];

            initTableInput(matrixInput);
            initTable(matrix);

            int kierunek = 0;
            int rowTemp = 0;

            //initTableInput(matrixInput);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (rowTemp == matrix.GetLength(0))
                {
                    kierunek = 1; //set to up
                    rowTemp -= 2;
                }

                if (rowTemp == -1)
                {
                    kierunek = 0; //set to up
                    rowTemp += 2;
                }

                if (kierunek == 0) // down
                {
                    matrix[rowTemp, col] = 1;
                    //Console.Write(matrixInput[rowTemp, col]);
                    //data += matrixInput[rowTemp, col];
                    //matrixInput[rowTemp, col] = input[col];
                    rowTemp++;
                    continue;
                }

                if (kierunek == 1) // up
                {
                    matrix[rowTemp, col] = 1;
                    //Console.Write(matrixInput[rowTemp, col]);
                    //data += matrixInput[rowTemp, col];
                    //matrixInput[rowTemp, col] = input[col];
                    rowTemp--;
                    continue;
                }
            }

            int z = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        matrixInput[row, col] = input[z++];
                    }
                }
            }

            //printTable(matrix);
            //printTableInput(matrixInput);
            
            //printTableInput(matrixInput);

            kierunek = 0;
            rowTemp = 0;



            string data = "";

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (rowTemp == matrix.GetLength(0))
                {
                    kierunek = 1; //set to up
                    rowTemp -= 2;
                }

                if (rowTemp == -1)
                {
                    kierunek = 0; //set to up
                    rowTemp += 2;
                }

                if (kierunek == 0) // down
                {
                    matrix[rowTemp, col] = 1;
                    //Console.Write(matrixInput[rowTemp, col]);
                    data += matrixInput[rowTemp, col];
                    //matrixInput[rowTemp, col] = input[col];
                    rowTemp++;
                    continue;
                }

                if (kierunek == 1) // up
                {
                    matrix[rowTemp, col] = 1;
                    //Console.Write(matrixInput[rowTemp, col]);
                    data += matrixInput[rowTemp, col];
                    //matrixInput[rowTemp, col] = input[col];
                    rowTemp--;
                    continue;
                }
            }
            return data;
        }

        static void Main(string[] args)
        {
            string input = "POLITECHNIKA BIAŁOSTOCKA WYDZIAŁ INFORMATYKI Bezpieczenstwo sieci komputerowych";

            Console.WriteLine(Encrpt("CRYPTOGRAPHY",3));

            Console.WriteLine(Decrypt("CTARPORPYYGH",3));
        }
    }
}
