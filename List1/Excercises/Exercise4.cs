using System;

namespace List1.Excercises
{
    internal class Exercise4
    {
        public static void Encrypt()
        {
            var alphabet = GetAlphabet();
            Console.Write("Podaj ciąg znaków do szyfrowania: ");
            var plaintext = Console.ReadLine();
            Console.Write("Podaj a: ");
            var astring = Console.ReadLine();
            Console.Write("Podaj k0: ");
            var k0String = Console.ReadLine();
            Console.Write("Podaj k1: ");
            var k1String = Console.ReadLine();
            int a, k0, k1;
            int.TryParse(astring, out a);
            int.TryParse(k0String, out k0);
            int.TryParse(k1String, out k1);

            var c = (a * k0 + k1) % 21;

            for (var i = 0; i < plaintext.Length; i++)
            {
            }
        }

        public static void Decrypt()
        {
            long c, k0 = 3, k1 = 7;
            long a = 1;
            c = (a * k0 + k1) % GetAlphabet().Length;
            var n = GetAlphabet().Length;
            var fi = 11;
            a =  ((c + (n - k0)) * Power((int)k1, fi)) % n;
            Console.WriteLine();
            Console.WriteLine(a);
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

        private static string GetAlphabet()
        {
            return "ABCDEFGHIJKLMNOPRSTUVWXYZ";
        }
    }
}