using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabaAsmCrypta1
{
    class Librarian
    {

        public static byte[] getRandomSequence(int length)
        {
            byte[] text = File.ReadAllBytes("youtext.txt");
            byte[] sequence = new byte[length];
            Random rd = new Random();
            int startValue =  rd.Next(0, 1000);
           
            for (int i = startValue; i < length + startValue; i++)
              
                sequence[i - startValue] = text[i];
        
            return sequence;
        }
    }
}
