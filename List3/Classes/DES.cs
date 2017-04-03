using System;
using System.IO;

namespace List3.Classes
{
    public class DES
    {
        private readonly KeyGenerator _keyGenerator;

        private readonly string _plainFileName;
        private int[] _ip, _ipReverse, _e, _p;
        // table of input bytes
        private byte[] _plainFileBytes, _encodedFileBytes;

        private int[,,] _s;

        public DES(string plainFileName, string key)
        {
            _plainFileName = plainFileName;
            SetPlainText(plainFileName, 'e');

            PrepareDesTables();

            _keyGenerator = new KeyGenerator(key);
        }

        private void PrepareDesTables()
        {
            int i, j, index, ii;
            string[] line;

            _ip = new int[64];
            _ipReverse = new int[64];
            _e = new int[48];
            _p = new int[32];
            _s = new int[8, 4, 16];

            //read IP from file
            var fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\IP.txt");
            for (i = 0, index = 0; i < 8; i++)
            {
                line = fileLines[i].Split();
                for (j = 0; j < 8; j++)
                    _ip[index++] = int.Parse(line[j]) - 1;
            }

            //Read IP^-1 from file
            fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\IPReverse.txt");
            for (i = 0, index = 0; i < 8; i++)
            {
                line = fileLines[i].Split();
                for (j = 0; j < 8; j++)
                    _ipReverse[index++] = int.Parse(line[j]) - 1;
            }

            //Read E from file
            fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\E.txt");
            for (i = 0, index = 0; i < 8; i++)
            {
                line = fileLines[i].Split();
                for (j = 0; j < 6; j++)
                    _e[index++] = int.Parse(line[j]) - 1;
            }

            //Read P from file
            fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\P.txt");
            for (i = 0, index = 0; i < 8; i++)
            {
                line = fileLines[i].Split();
                for (j = 0; j < 4; j++)
                    _p[index++] = int.Parse(line[j]) - 1;
            }

            //Read S1..8 from file
            fileLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\tables\S.txt");
            for (ii = 0; ii < 8; ii++) // for every S: 1..8
            for (i = 0; i < 4; i++)
            {
                line = fileLines[i + ii * 5].Split();
                for (j = 0; j < 16; j++)
                    _s[ii, i, j] = int.Parse(line[j]);
            }
        }

        private void SetPlainText(string plainFileName, char mode)
        {
            var random = new Random();
            _plainFileBytes = File.ReadAllBytes(plainFileName);

            if (mode == 'e')
                // PADDING: when we decode we always have multiple of 64 bits. Only when we encode we have to modify input Bytes
            {
                var amount = _plainFileBytes.Length;

                // if not multiple of 64, example: ....11001100 1101____ -> we have to: add cells to achieve multiple of 64 bits file,
                //                                                                      generate random bits in these cells,
                //                                                                      in the last cell we write how many bits we added
                int newAmount;
                byte[] newPlainFileBytes;
                if (amount % 8 != 0)
                {
                    newAmount = amount + (8 - amount % 8);
                    newPlainFileBytes = new byte[newAmount];

                    for (var i = 0; i < amount; i++) //rewriting bits
                        newPlainFileBytes[i] = _plainFileBytes[i];

                    for (var i = amount; i < newAmount - 1; i++) // generate random bits in added cells
                        newPlainFileBytes[i] = Convert.ToByte(random.Next(0, 1));
                    // in the last added cell we write how many bits we added - how many bits we have to remove when we will be decoding file
                    newPlainFileBytes[newAmount - 1] = Convert.ToByte(newAmount - amount);

                    _plainFileBytes = newPlainFileBytes;
                }
                // if multiple of 64, example: ....11001100 11010011 -> we have to: add  64 cells(8 Byte),
                //                                                      generate random bits in these cells and in the last cell write how many bits we added
                else
                {
                    newAmount = amount + 8;
                    newPlainFileBytes = new byte[newAmount];

                    for (var i = 0; i < amount; i++)
                        newPlainFileBytes[i] = _plainFileBytes[i];
                    for (var i = amount; i < newAmount - 1; i++)
                        newPlainFileBytes[i] = Convert.ToByte(random.Next(0, 1));

                    newPlainFileBytes[newAmount - 1] = Convert.ToByte(newAmount - amount);

                    _plainFileBytes = newPlainFileBytes;
                }
            }
        }

        public void Encode()
        {
            SetPlainText(_plainFileName, 'e');

            var l = new int[32];
            var r = new int[32];
            var indexOfResult = 0;

            _encodedFileBytes = new byte[_plainFileBytes.Length];
            var numberOf64Inputs = _plainFileBytes.Length / 8;

            for (var i = 0; i < numberOf64Inputs; i++)
            {
                var plain64 = Next64Inputs(i);

                plain64 = Ip(plain64); // initial permutation

                for (var j = 0; j < 32; j++)
                {
                    l[j] = plain64[j];
                    r[j] = plain64[j + 32];
                }

                for (var j = 0; j < 16; j++)
                {
                    var f = GenerateF(_keyGenerator.KeyList[j], r);
                    var rcopy = MakeCopy(r); // bufor

                    r = MakeXor(l, f);
                    l = MakeCopy(rcopy);
                }


                for (var j = 0; j < 32; j++)
                {
                    plain64[j] = r[j];
                    plain64[j + 32] = l[j];
                }

                plain64 = IpReverse(plain64);

                AddToEncoded(plain64, ref indexOfResult);
            }
            var testpath = _plainFileName.Substring(_plainFileName.LastIndexOf("\\") + 1,
                _plainFileName.Length - _plainFileName.LastIndexOf("\\") - 5);
            var path = Path.Combine(Directory.GetCurrentDirectory(), testpath + "Encrypted.bin");
            var br =
                new BinaryWriter(new FileStream(path,
                    FileMode.Create));
            br.Write(_encodedFileBytes);
            br.Close();
        }

        internal void Decode()
        {
            SetPlainText(_plainFileName, 'd');


            var l = new int[32];
            var r = new int[32];
            var indexOfResult = 0;

            _encodedFileBytes = new byte[_plainFileBytes.Length];
            var numberOf64Inputs = _plainFileBytes.Length / 8;

            for (var i = 0; i < numberOf64Inputs; i++)
            {
                var plain64 = Next64Inputs(i);

                plain64 = Ip(plain64);

                for (var j = 0; j < 32; j++)
                {
                    l[j] = plain64[j];
                    r[j] = plain64[j + 32];
                }

                for (var j = 0; j < 16; j++)
                    // here is difference between encode and decode. We take keys in reverse order from k15 to K0.
                {
                    var f = GenerateF(_keyGenerator.KeyList[15 - j], r);
                    var rcopy = MakeCopy(r); // bufor

                    r = MakeXor(l, f);
                    l = MakeCopy(rcopy);
                }


                for (var j = 0; j < 32; j++)
                {
                    plain64[j] = r[j];
                    plain64[j + 32] = l[j];
                }

                plain64 = IpReverse(plain64);

                AddToEncoded(plain64, ref indexOfResult);
            }

            // we have to remove bites which where added for PADDING when we encode file
            var howManyDelete = Convert.ToInt32(_encodedFileBytes[_encodedFileBytes.Length - 1]);
            var newEncodedFileBytes = new byte[_encodedFileBytes.Length - howManyDelete];

            for (var i = 0; i < newEncodedFileBytes.Length; i++)
                newEncodedFileBytes[i] = _encodedFileBytes[i];
            _encodedFileBytes = newEncodedFileBytes;

            var testpath = _plainFileName.Substring(_plainFileName.LastIndexOf("\\") + 1,
                _plainFileName.Length - _plainFileName.LastIndexOf("\\") - 5);
            var path = Path.Combine(Directory.GetCurrentDirectory(), testpath + "Decrypted.bin");
            var br =
                new BinaryWriter(new FileStream(path,
                    FileMode.Create));
            br.Write(_encodedFileBytes);
            br.Close();
        }

        private void AddToEncoded(int[] plain64, ref int indexOfResult)
        {
            for (var i = 0; i < 8; i++)
            {
                var s = "";
                for (var j = 0; j < 8; j++)
                    s += plain64[j + 8 * i];
                _encodedFileBytes[indexOfResult++] = Convert.ToByte(s, 2);
            }
        }

        private int[] IpReverse(int[] plain64)
        {
            var newPlain64 = new int[64];
            int i;

            for (i = 0; i < 64; i++)
                newPlain64[i] = plain64[_ipReverse[i]];

            return newPlain64;
        }

        private int[] MakeCopy(int[] r)
        {
            var copy = new int[r.Length];
            int i;

            for (i = 0; i < r.Length; i++)
                copy[i] = r[i];

            return copy;
        }

        private int[] GenerateF(int[] key, int[] r32)
        {
            var result32 = new int[32];
            int i;
            int resultIndex;

            var r48 = E(r32);
            var xor48 = MakeXor(r48, key);
            for (i = 0, resultIndex = 0; i < 8; i++) //for every S
            {
                var rowIndex = xor48[0 + i * 6] + xor48[5 + i * 6].ToString();
                var columnIndex = xor48[1 + i * 6] + xor48[2 + i * 6].ToString() + xor48[3 + i * 6] + xor48[4 + i * 6];
                var newNumber = _s[i, Convert.ToInt32(rowIndex, 2), Convert.ToInt32(columnIndex, 2)];
                var newS = Convert.ToString(newNumber, 2).PadLeft(4, '0');

                for (var j = 0; j < 4; j++)
                    result32[resultIndex++] = Convert.ToInt32(newS[j]) - 48;
            }

            result32 = P(result32);

            return result32;
        }

        private int[] P(int[] result32)
        {
            var r32 = new int[32];

            for (var i = 0; i < 32; i++)
                r32[i] = result32[_p[i]];

            return r32;
        }

        private int[] MakeXor(int[] a, int[] b)
        {
            var size = a.Length;
            var result = new int[size];

            for (var i = 0; i < size; i++)
                result[i] = a[i] ^ b[i];

            return result;
        }

        private int[] E(int[] r32)
        {
            var r48 = new int[48];

            for (var i = 0; i < 48; i++)
                r48[i] = r32[_e[i]];

            return r48;
        }

        private int[] Ip(int[] plain64)
        {
            var newPlain64 = new int[64];
            int i;

            for (i = 0; i < 64; i++)
                newPlain64[i] = plain64[_ip[i]];

            return newPlain64;
        }

        private int[] Next64Inputs(int iteration)
        {
            var plain64 = new int[64];
            int i, j, index;

            for (i = 0, index = 0; i < 8; i++) // for 8 bytes, 8x8=64
            {
                var byteTmp = Convert.ToString(_plainFileBytes[i + iteration * 8], 2).PadLeft(8, '0');
                // we have string of 8 digits representing one byte. Example 00001100
                for (j = 0; j < 8; j++) // for 8 bites of 1 bite
                    plain64[index++] = int.Parse(byteTmp[j].ToString());
            }

            return plain64;
        }
    }
}