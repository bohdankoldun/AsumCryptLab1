using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class Geffe
    {
        private byte[] L9 = new byte[9];
        private byte[] L10 = new byte[10];
        private byte[] L11 = new byte[11];

        private byte[] getRegisterSequence(byte[] L, int length)
        {
            byte[] sequence = new byte[length];
            int count = 0;
            while (count < L.Length ) {
                sequence[count] = L[count];
                count++;
            }

            if (L.Length == 11)
                while (count < length) {
                    sequence[count] = Convert.ToByte((sequence[count-11] + sequence[count-9])%2);
                    count++;
                }

            if (L.Length == 9)
                while (count < length)
                {
                    sequence[count] = Convert.ToByte((sequence[count-9] + sequence[count-8] + sequence[count-6] + sequence[count-5]) % 2);
                    count++;
                }

            if (L.Length == 10)
                while (count < length)
                {
                    sequence[count] = Convert.ToByte((sequence[count-10] + sequence[count-7]) % 2);
                    count++;
                }
            
            return sequence;
        }

        public byte[] getRandomSequence(int length)
        {
            byte[] sequence = new byte[length];
            byte[] bits_sequence = new byte[length*8];
            
            Random rd = new Random();
            int count1 = 0, count2 = 0, count3 = 0;
            while (count1 < 11)
            {
                L11[count1] = Convert.ToByte(rd.Next(0, 2));//[min до max-1] = [0,1]
                count1++;
            }
            while (count2 < 9)
            {
                L9[count2] = Convert.ToByte(rd.Next(0, 2));//[min до max-1] = [0,1]
                count2++;
            }
            while (count3 < 10)
            {
                L10[count3] = Convert.ToByte(rd.Next(0, 2));//[min до max-1] = [0,1]
                count3++;
            }

            byte[] x = getRegisterSequence(L11, length * 8);
            byte[] y = getRegisterSequence(L9, length * 8);
            byte[] s = getRegisterSequence(L10, length * 8);

            int count = 0;
            while (count < length*8) {
                bits_sequence[count] = Convert.ToByte((s[count] * x[count] + (1 + s[count]) * y[count]) % 2);
                count++;

            }

            for (int j = 0; j < length; j++)
            {
                byte b = 0;
                for (int i = 0; i < 8; i++)
                    if (bits_sequence[j*8 + i] == 1)
                        b += Convert.ToByte(Math.Pow(2, 7 - i));
                sequence[j] = b;
            }

            return sequence;
        }
    }
}
