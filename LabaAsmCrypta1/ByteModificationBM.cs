using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace LabaAsmCrypta1
{
    class ByteModificationBM
    {

        public static byte[] getRandomSequence(int length)
        {

            byte[] sequence = new byte[length];
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
                T0 = T0 % p;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert the string  to a BigInteger value.");
            }

            
            BigInteger t = T0;
            BigInteger res;
            res = t * 256 / (p - 1);
            if (res != 255)
                res++;
            sequence[0] = (byte)res;
            
         
            for (int i = 1; i < length; i++)
            {
                t = BigInteger.ModPow(a, t, p);
                res = t * 256 / (p - 1);
                if (res != 255)
                    res++;
                Console.WriteLine(i);
                sequence[i] = (byte)res;
            }

           

            return sequence;
        }
    }
}
