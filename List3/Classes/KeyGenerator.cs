using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace List3.Classes
{
    public class KeyGenerator
    {
        private int[] _pc1;
        private int[] _pc2;

        public KeyGenerator(string keyFileName)
        {
            PrepareTables();
            SetKey(keyFileName);
        }

        public List<int[]> KeyList { get; set; }

        private void GenerateKeys(int[] key64)
        {
            KeyList = new List<int[]>();

            var c = new int[28];
            var d = new int[28];

            var key56 = Pc1(key64);

            for (var i = 0; i < 28; i++)
            {
                c[i] = key56[i];
                d[i] = key56[i + 28];
            }

            for (var i = 0; i < 16; i++)
            {
                Shift(ref c, ref d, i == 0 || i == 1 || i == 8 || i == 15 ? 1 : 2);

                key56 = Merge(ref c, ref d);

                var key48 = Pc2(key56);

                KeyList.Add(key48);
            }
        }

        private int[] Pc1(int[] key64)
        {
            var newKey56 = new int[56];

            for (var i = 0; i < 56; i++)
                newKey56[i] = key64[_pc1[i]];

            return newKey56;
        }

        private int[] Pc2(int[] key56) // transform PC2
        {
            var newKey48 = new int[48];

            for (var i = 0; i < 48; i++)
                newKey48[i] = key56[_pc2[i]];

            return newKey48;
        }

        private int[] Merge(ref int[] c, ref int[] d) // merge C and D
        {
            var key56 = new int[56];
            for (var i = 0; i < 28; i++)
            {
                key56[i] = c[i];
                key56[i + 28] = d[i];
            }
            return key56;
        }

        private static void Shift(ref int[] c, ref int[] d, int number)
        {
            int ctmp = c[0], dtmp = d[0], i;

            for (i = 0; i < 27; i++)
            {
                c[i] = c[i + 1];
                d[i] = d[i + 1];
            }

            c[27] = ctmp;
            d[27] = dtmp;

            if (number == 2)
            {
                ctmp = c[0];
                dtmp = d[0];

                for (i = 0; i < 27; i++)
                {
                    c[i] = c[i + 1];
                    d[i] = d[i + 1];
                }

                c[27] = ctmp;
                d[27] = dtmp;
            }
        }

        private void PrepareTables() // load PC1, PC2 from file
        {
            int i, j, index;
            string[] line;

            _pc1 = new int[56];
            _pc2 = new int[48];

            var fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\PC1.txt");
            for (i = 0, index = 0; i < 9; i++)
            {
                if (i == 4) continue;
                line = fileLines[i].Split();
                for (j = 0; j < 7; j++)
                    _pc1[index++] = int.Parse(line[j]) - 1;
            }

            fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\PC2.txt");
            for (i = 0, index = 0; i < 8; i++)
            {
                line = fileLines[i].Split();
                for (j = 0; j < 6; j++)
                    _pc2[index++] = int.Parse(line[j]) - 1;
            }
        }

        private static int[] ReadKey(string key) // return 64bits key
        {
            var line = HexToBinary(key);
            var key64 = new int[line.Length];
            for (var i = 0; i < 64; i++)
                key64[i] = int.Parse(line[i].ToString());

            return key64;
        }

        private static string HexToBinary(string key)
        {
            var binarystring = string.Join(string.Empty,
                key.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
            return binarystring;
        }

        private void SetKey(string keyFileName)
        {
            GenerateKeys(ReadKey(keyFileName));
        }
    }
}