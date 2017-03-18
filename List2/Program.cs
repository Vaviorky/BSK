using System;
using List2.Exercises;

namespace List2
{
    internal class Program
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
                        Console.WriteLine("Zadanie 1 - LFSR");
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
                        Console.WriteLine("Zadanie 2 - Synchronous Stream Cipher");
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
                        Console.WriteLine("Zadanie 3 - Ciphertext Autokey");
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