using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2.Exercises.ClassZad2
{
    class LFSR_3_File
    {
        private LFSR3 lfsr;
        private FileStream fsInput, fsOutput;
        private BinaryReader br;
        private BinaryWriter wr;
        private string input, output;

        public LFSR_3_File(LFSR3 lfsr, string input, string output)
        {
            this.lfsr = lfsr;
            this.input = input;
            this.output = output;
        }

        public void Encode()
        {
            fsInput = new FileStream(input, FileMode.Open);
            fsOutput = new FileStream(output, FileMode.Create, FileAccess.Write);
            br = new BinaryReader(fsInput);
            wr = new BinaryWriter(fsOutput);

            //read
            LinkedList<Byte> inputBits = new LinkedList<byte>();
            LinkedList<Byte> outputBits = new LinkedList<byte>();
            byte[] tempd = br.ReadBytes((int)fsInput.Length);
            foreach (var VARIABLE in tempd)
            {
                string data = Convert.ToString(VARIABLE, 2).PadLeft(8, '0');

                foreach (char c in data)
                {
                    if (c == '1') inputBits.AddLast(1);
                    else inputBits.AddLast(0);
                }
            }
            br.Close();
            fsInput.Close();

            byte tmp;
            byte Xored;

            foreach (var b in inputBits)
            {
                tmp = lfsr.getLFSR_Value();
                Xored = lfsr.getXOR(tmp, b);
                lfsr.getShiftedSeed(Xored);
                //Console.Write(Xored);
                outputBits.AddLast(Xored);
            }

            //zapis

            byte[] OneByte = new byte[8];
            int count = 0;
            List<byte> byteToWriteList = new List<byte>();

            foreach (byte b in outputBits)
            {
                OneByte[count++] = b;
                if (count == 8)
                {
                    byte byteTowrite = BinaryToByte(OneByte);
                    byteToWriteList.Add(byteTowrite);
                    count = 0;
                }
            }

            wr.Write(byteToWriteList.ToArray());
            wr.Close();
            fsOutput.Close();

        }

        public void Decode()
        {
            fsInput = new FileStream(input, FileMode.Open);
            fsOutput = new FileStream(output, FileMode.Create, FileAccess.Write);
            br = new BinaryReader(fsInput);
            wr = new BinaryWriter(fsOutput);

            //read
            LinkedList<Byte> inputBits = new LinkedList<byte>();
            LinkedList<Byte> outputBits = new LinkedList<byte>();
            byte[] tempd = br.ReadBytes((int)fsInput.Length);
            foreach (var VARIABLE in tempd)
            {
                string data = Convert.ToString(VARIABLE, 2).PadLeft(8, '0');

                foreach (char c in data)
                {
                    if (c == '1') inputBits.AddLast(1);
                    else inputBits.AddLast(0);
                }
            }
            br.Close();
            fsInput.Close();

            byte temp;
            byte Xored;

            foreach (var b in inputBits)
            {
                temp = lfsr.getLFSR_Value();
                Xored = lfsr.getXOR(temp, b);
                lfsr.getShiftedSeed(b);
                //Console.Write(Xored);
                outputBits.AddLast(Xored);
            }

            //zapis
            byte[] OneByte = new byte[8];
            int count = 0;
            List<byte> byteToWriteList = new List<byte>();

            foreach (byte b in outputBits)
            {
                OneByte[count++] = b;
                if (count == 8)
                {
                    byte byteTowrite = BinaryToByte(OneByte);
                    byteToWriteList.Add(byteTowrite);
                    count = 0;
                }
            }

            wr.Write(byteToWriteList.ToArray());
            wr.Close();
            fsOutput.Close();
        }

        private static byte BinaryToByte(byte[] tab)
        {
            byte value = 0;
            if (tab[7] == 1) value += 1;
            if (tab[6] == 1) value += 2;
            if (tab[5] == 1) value += 4;
            if (tab[4] == 1) value += 8;
            if (tab[3] == 1) value += 16;
            if (tab[2] == 1) value += 32;
            if (tab[1] == 1) value += 64;
            if (tab[0] == 1) value += 128;

            return value;
        }
    }
}
