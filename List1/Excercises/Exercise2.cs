using System;

namespace List1.Excercises
{
    internal static class Exercise2
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 2a - Przestawienia macierzowe");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var keyinput = Console.ReadLine();
            if (keyinput != null)
            {
                var key = new int[keyinput.Length];
                for (var i = 0; i < keyinput.Length; i++)
                    key[i] = int.Parse(keyinput[i].ToString());


                var output = "";

                for (var i = 0; i < text.Length; i += keyinput.Length)
                for (var j = 0; j < keyinput.Length; j++)
                    if (i + key[j] - 1 < text.Length)
                        output += text[i + key[j] - 1];

                Console.Write("Ciąg zaszyfrowany: " + output);
            }

            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 2a - Przestawienia macierzowe");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do odszyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj klucz (wart. liczbowa): ");
            var keyinput = Console.ReadLine();
            if (keyinput != null)
            {
                var key = new int[keyinput.Length];
                for (var i = 0; i < keyinput.Length; i++)
                    key[i] = int.Parse(keyinput[i].ToString());

                if (text != null)
                {
                    var output = new char[text.Length];
                    var k = 0;

                    for (var i = 0; i < text.Length; i += keyinput.Length)
                    for (var j = 0; j < keyinput.Length; j++)
                        if (i + key[j] - 1 < text.Length)
                            output[i + key[j] - 1] = text[k++];


                    Console.Write("Ciąg odszyfrowany: " + new string(output));
                }
            }

            Console.ReadKey();
        }
    }
}