using List2.Exercises.ClassZad2;
using System;

namespace List2.Exercises
{
    public static class Exercise1
    {
        public static void Encrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 1 - LFSR - Szyfrowanie");
            Console.WriteLine();

            string dictWord;
            string seed;
            int n;

            Console.Write("Podaj wielomian: ");
            dictWord = Console.ReadLine();
           
            Console.Write("Podaj seed: ");
            seed = Console.ReadLine();

            Console.Write("Podaj ilosc n bitow do przesuniecia: ");
            n = Int32.Parse(Console.ReadLine());

            LFSR lfsr = new LFSR(dictWord,seed);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(lfsr.getLFSR_Value());
            }

            Console.ReadKey();



            //var file = BinaryFile.Read("test.bin");

            //Console.Write("Podaj ciag w formie bitowej: ");
            //var seed = Console.ReadLine();

            //Console.Write("Podaj stopień wielomianu (w formie bitowej, np x^6 + x^4 + 1 = 1010001): ");
            //var wielomian = Console.ReadLine();

            //var lfsr = new LFSR(seed, wielomian, 8);

            //Console.WriteLine("Generate");
            //for (var i = 0; i < 10; i++)
            //{
            //    var r = lfsr.Generate(5);
            //    Console.WriteLine(lfsr + " " + r);
            //}

            //Console.ReadKey();
        }

        public static void Decrypt()
        {
            Console.Clear();
            ConsoleOutput.PutInitText();
            Console.WriteLine("Zadanie 1 - LFSR - Deszyfrowanie");
            Console.WriteLine();
        }

        //private class LFSR
        //{
        //    private readonly bool[] _lfsr;
        //    private int _tap;
        //    private readonly bool[] _wielomian;

        //    public LFSR(string seed, string wielomian, int tap)
        //    {
        //        _lfsr = new bool[wielomian.Length-1];
        //        _tap = seed.Length - 1 - tap;
        //        _wielomian = new bool[wielomian.Length];

        //        //inicjalizacja ciagu - wstawianie 0 i 1 (true i false) tam gdzie jest w stringu 0 i 1
        //        for (var i = 0; i < seed.Length; i++)
        //            _lfsr[i] = seed[i] != 48;

        //        //inicjalizacja seeda - wstawianie 0 i 1 (true i false) tam gdzie jest w stringu 0 i 1
        //        for (var i = 0; i < wielomian.Length; i++)
        //            _wielomian[i] = wielomian[i] != 48;
        //    }

        //    public int Step()
        //    {
                
        //        bool newBit = false;
        //        //na ostatnim bicie wielomianu będzie zawsze 1 która informuje że jest przesunięcie
        //        //nie wiem czy prowadzący będzie chciał kombinować z ustawieniem tego bitu na 0 
        //        for (int i = 1; i >0; i++)
        //        { 
        //            if (_wielomian[i])
        //            {
        //                newBit ^= _wielomian[i];
        //            }
        //        }

        //        Console.WriteLine("newbit: " + newBit);

        //        //przesunięcie
        //        for (var i = 0; i < _lfsr.Length - 1; i++)
        //            _lfsr[i] = _lfsr[i + 1];

        //        //wstawienie wygenerowanego przez xora bitu do ciagu
        //        _lfsr[_lfsr.Length - 1] = newBit;

        //        return newBit == false ? 0 : 1;
        //    }

        //    public int Generate(int k)
        //    {
        //        int temp = 0;

        //        for (var i = 0; i < k; i++)
        //        {
        //            temp *= 2;
        //            temp += Step();
        //        }

        //        return temp;
        //    }

        //    public override string ToString()
        //    {
        //        var representation = "";

        //        foreach (var t in _lfsr)
        //            representation += t == false ? 0 : 1;
        //        return representation;
        //    }
        //}
    }
}