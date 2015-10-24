using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class L89
    {
        public static byte[] getRandomSequence(int length)
        {
            if (length < 12)
                return new byte[0];
            byte[] sequence = new byte[length];
            byte[] bits_sequence = new byte[length*8];
            Random rd = new Random();
            int count = 0;

            while (count < 89) 
            {
                bits_sequence[count] = Convert.ToByte(rd.Next(0, 2));//[min до max-1] = [0,1]
                count++;
            }

            while (count < length*8)
            {
                bits_sequence[count] = Convert.ToByte((bits_sequence[count - 38] + bits_sequence[count - 89]) % 2);
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
