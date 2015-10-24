using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace LabaAsmCrypta1
{
    class BBS
    {
        public static byte[] getRandomSequence(int length)
        {

            byte[] sequence = new byte[length];
            byte[] bits_sequence = new byte[length*8];
            Random rd = new Random();
            string string_r0 = "";
            int temp;
            for (int i = 1; i < 79; i++)
            {
                temp = rd.Next(0, 10);
                string_r0 += Convert.ToString(temp);
            }

            BigInteger p = 0;
            BigInteger q = 0;
            BigInteger r0 = 0;
            BigInteger n = 0;
          
            try
            {
                p = BigInteger.Parse("D5BBB96D30086EC484EBA3D7F9CAEB07", NumberStyles.HexNumber);
                q = BigInteger.Parse("425D2B9BFDB25B9CF6C416CC6E37B59C1F", NumberStyles.HexNumber);
                n =  p* q;
                r0 = BigInteger.Parse(string_r0);
                r0 = r0%n;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert the string  to a BigInteger value.");
            }

            BigInteger r = r0;
            for (int i = 0; i < length*8; i++) 
            {
                r = BigInteger.ModPow(r, 2, n);
                bits_sequence[i] = (byte)(r%2);
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
