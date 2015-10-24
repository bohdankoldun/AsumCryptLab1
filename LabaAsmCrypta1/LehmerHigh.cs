using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class LehmerHigh
    {
        protected long mod = 4294967296; // 2^32
        protected long a = 65537; // 2^16+1
        protected long c = 119;
        
        public  virtual  byte[] getRandomSequence(int length)
        {
            Random rd = new Random();
            long x0 = rd.Next();
            while(x0 == 0)
                x0 = rd.Next();
            long x_next = x0;
            byte[] bits_sequence = new byte[length * 8];
            string  bits;
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                
                x_next =x_next%mod;
                bits = Convert.ToString(x_next, 2);
                while (bits.Length < 32)
                    bits = '0'+bits;

                for (int j = 0; j < 8; j++) 
                {
                    if(bits[j] == '1')
                        bits_sequence[count]= 1;
                    else
                        bits_sequence[count]= 0;
                    count++;
                }
                x_next = x_next * a + c;
            }

            byte[] sequence = new byte[length];
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
