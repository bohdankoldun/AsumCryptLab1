using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class L20
    {

        public static byte[] getRandomSequence(int length)
        {
            if (length < 3)
                return new byte[0];

            byte[] sequence = new byte[length];
            byte[] bits_sequence = new byte[length * 8];
            int count = 0;

            Random rd = new Random();
            while (count < 20)
            {
                bits_sequence[count] = Convert.ToByte(rd.Next(0, 2));
                count++;
            }

            
            while (count < length*8) 
            {
                bits_sequence[count] = Convert.ToByte((bits_sequence[count - 3] + bits_sequence[count - 5] + bits_sequence[count - 9] + bits_sequence[count - 20])%2);
                count++;
            }

            //переводим послідовність бітів в послідовність байтів
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
