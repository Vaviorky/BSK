﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2.Exercises.ClassZad2
{
    class LFSR
    {
        private int[] dictioanryTab;
        private byte[] seedTab;

        public LFSR(string dict, string seed)
        {
            dictioanryTab = getWielomian(dict);
            seedTab = getSeddTab(seed);
        }

        public byte getLFSR_Value()
        {
            byte XOR = getLFSR_Byte(dictioanryTab, seedTab);
            seedTab = getShiftedSeed(seedTab, XOR);
            return XOR;
        }

        private int[] getWielomian(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') count++;
            }

            int[] wielomianInts = new int[count];
            count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') wielomianInts[count++] = i;
            }

            return wielomianInts;
        }

        private byte[] getSeddTab(string s)
        {
            byte[] tab = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1') tab[i] = 1;
                else tab[i] = 0;
            }
            return tab;
        }

        private byte getLFSR_Byte(int[] dict, byte[] seed)
        {
            byte XOR = getXOR(seed[dict[0]], seed[dict[1]]);

            for (int i = 2; i < dict.Length; i++)
            {
                XOR = getXOR(XOR, seed[dict[i]]);
            }

            return XOR;
        }

        public byte getXOR(byte a, byte b)
        {
            return (byte)(a ^ b);

            //if (a == 0 && b == 0) return 0;
            //if (a == 0 && b == 1) return 1;
            //if (a == 1 && b == 0) return 1;
            //if (a == 1 && b == 1) return 0;

            //return 0;
        }

        private byte[] getShiftedSeed(byte[] seed, byte XOR)
        {
            byte[] newSedd = new byte[seed.Length];
            for (int i = 0; i < (seed.Length - 1); i++)
            {
                newSedd[i + 1] = seed[i];
            }
            newSedd[0] = XOR;
            ///Console.WriteLine();
            //for (int i = 0; i < newSedd.Length; i++)
            //{
            //    Console.Write(newSedd[i]);
            //}
            //Console.WriteLine();
            return newSedd;
        }
    }
}
