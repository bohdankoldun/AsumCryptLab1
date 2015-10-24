using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;


namespace LabaAsmCrypta1
{
    class BM
    {
        public static byte[] getRandomSequence(int length)
        {
           
          byte[] sequence = new byte[length];
          byte[] bits_sequence = new byte[length*8];
          Random rd = new Random();
          string stringT0 = "";
          int temp;
          for (int i = 0; i < 77; i++)
          {
              temp = rd.Next(0, 10);
              stringT0 += temp;
          }
         
          BigInteger p = 0;
          BigInteger a = 0;
          BigInteger T0 = 0;
          try
          {
              p = BigInteger.Parse("93466510612868436543809057926265637055082661966786875228460721852868821292003");
              a = BigInteger.Parse("41402113656871763270073938229168765778879686959780184368336806110280536326998");
              T0 = BigInteger.Parse(stringT0);
          }
          catch (FormatException)
          { 
              Console.WriteLine("Unable to convert the string  to a BigInteger value.");
          }
            
            BigInteger half_p = (p-1) / 2;
            BigInteger t = T0;
            if (t < half_p)
                bits_sequence[0] = 1;
            else
                bits_sequence[0] = 0;

            for(int i = 1; i < length*8; i++) 
            {
                Console.WriteLine(i);
                t = BigInteger.ModPow(a, t, p);
                if (t < half_p)
                    bits_sequence[i] = 1;
                else
                    bits_sequence[i] = 0;
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
