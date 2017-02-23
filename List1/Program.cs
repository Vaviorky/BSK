using System;
using List1.Excercises;

namespace List1
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                ConsoleOutput.PutInitText();
                ConsoleOutput.PutExercisesText();
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        ConsoleOutput.PutInitText();
                        Console.WriteLine("Zadanie 1 - Rail fence");
                        ConsoleOutput.PutCryptoDecryptoText();
                        var choice1 = Console.ReadKey();
                        switch (choice1.KeyChar)
                        {
                            case '1':
                                Exercise1.Encrypt();
                                break;
                            case '2':
                                Exercise1.Decrypt();
                                break;
                            default:
                                break;
                        }
                        break;
                    case '2':
                        ConsoleOutput.PutInitText();
                        Console.WriteLine("Zadanie 2 - Przestawienia macierzowe a");
                        ConsoleOutput.PutCryptoDecryptoText();
                        var choice2 = Console.ReadKey();
                        switch (choice2.KeyChar)
                        {
                            case '1':
                                Exercise2.Encrypt();
                                break;
                            case '2':
                                Exercise2.Decrypt();
                                break;
                            default:
                                break;
                        }
                        break;
                    case '3':
                        ConsoleOutput.PutInitText();
                        Console.WriteLine("Zadanie 3 - Przestawienia macierzowe b");
                        ConsoleOutput.PutCryptoDecryptoText();
                        var choice3 = Console.ReadKey();
                        switch (choice3.KeyChar)
                        {
                            case '1':
                                Exercise3.Encrypt();
                                break;
                            case '2':
                                Exercise3.Decrypt();
                                break;
                            default:
                                break;
                        }
                        break;
                    case '4':
                        ConsoleOutput.PutInitText();
                        Console.WriteLine("Zadanie 4 - Szyfrowanie cezara");
                        ConsoleOutput.PutCryptoDecryptoText();
                        var choice4 = Console.ReadKey();
                        switch (choice4.KeyChar)
                        {
                            case '1':
                                Exercise4.Encrypt();
                                break;
                            case '2':
                                Exercise4.Decrypt();
                                break;
                            default:
                                break;
                        }
                        break;
                    case '5':
                        ConsoleOutput.PutInitText();
                        Console.WriteLine("Zadanie 5 - Szyfrowanie Vigenere’a");
                        ConsoleOutput.PutCryptoDecryptoText();
                        var choice5 = Console.ReadKey();
                        switch (choice5.KeyChar)
                        {
                            case '1':
                                Exercise5.Encrypt();
                                break;
                            case '2':
                                Exercise5.Decrypt();
                                break;
                            default:
                                break;
                        }
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:

                        break;
                }
                Console.Clear();
            }
        }
    }
}