using System;

namespace List1.Excercises
{
    internal class Exercise4
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 4 - Szyfrowanie Cezara");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj k0: ");
            var k0 = int.Parse(Console.ReadLine());
            Console.Write("Podaj k1: ");
            var k1 = int.Parse(Console.ReadLine());

            text = text.ToUpper();

            var output = "";
            int znak;
            var n = 26;

            for (int i = 0; i < text.Length; i++)
            {
                znak = text[i] - 65;
                znak = ((znak * k1 + k0) % n) + 65;
                output += (char)znak;
            }

            Console.WriteLine("Ciąg zaszyfrowany: " + output);
            Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 4 - Szyfrowanie Cezara");
            Console.WriteLine();

            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var text = Console.ReadLine();
            Console.Write("Podaj k0: ");
            var k0 = int.Parse(Console.ReadLine());
            Console.Write("Podaj k1: ");
            var k1 = int.Parse(Console.ReadLine());

            text = text.ToUpper();

            var output = "";
            const int n = 26;
            const int fi = 12;
            var fik = Power(k1, fi - 1);
            long znak;

            for (int i = 0; i < text.Length; i++)
            {
                znak = text[i] - 65;
                //znak = ((znak + n - k0) * fik) % n;
                znak = ((znak + (n - k0))%n * ModuloPower(k1, fi - 1, n))%n;
                znak += 65;
                output += (char)znak;
            }

            Console.WriteLine("Ciąg odszyfrowany: " + output);
            Console.ReadKey();
        }

        private static long Power(int n, int k)
        {
            if (k == 0)
                return 1;
            if (k % 2 == 0)
                return Power(n, k / 2) * Power(n, k / 2);
            return n * Power(n, k / 2) * Power(n, k / 2);
        }

        private static int ModuloPower(int x, int power, int modulo)
        {
            int suma = 1;
            int temp = 0;
            var table = Convert.ToString(power, 2);
            int multiplier = 1;
            bool tempIsSet = false;

            for (int i = table.Length - 1; i >= 0; i--)
            {
                if (tempIsSet)
                {
                    temp = (temp * temp) % modulo;
                }
                else
                {
                    temp = (int)Math.Pow(x, multiplier);
                    tempIsSet = true;
                }
                multiplier *= 2;
                if (table[i] == '1') suma = suma * temp;
            }

            return suma % modulo;
        }
    }
}