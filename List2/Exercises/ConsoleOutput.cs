﻿using System;

namespace List2.Exercises
{
    class ConsoleOutput
    {
        public static void PutInitText()
        {
            Console.Clear();
            Console.WriteLine("Bezpieczeństwo Sieci Komputerowych");
            Console.WriteLine("");
            Console.WriteLine("Olbryś Krystian");
            Console.WriteLine("Wawiórka Daniel");
            Console.WriteLine("");
            Console.WriteLine("Lista 2");
            Console.WriteLine("");
        }

        public static void PutCryptoDecryptoText()
        {
            Console.WriteLine("");
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Szyfrowanie");
            Console.WriteLine("2. Deszyfrowanie");
            Console.WriteLine("0. Cofnij");
        }

        public static void PutExercisesText()
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zadanie 1");
            Console.WriteLine("2. Zadanie 2");
            Console.WriteLine("3. Zadanie 3");
            Console.WriteLine("0. Wyjście");
        }
    }
}
