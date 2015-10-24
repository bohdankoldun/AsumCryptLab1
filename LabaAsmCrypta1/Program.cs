using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Numerics;


namespace LabaAsmCrypta1
{
    class Program
    {
        static void Main(string[] args) 
        {
            // квантилі для альфа = 0,01; 0,05; 0,1
            double[] quantile = {2.326, 1.645, 1.215};
            int r =10;

            byte[] seq6 = Librarian.getRandomSequence(100000);
            WriterFile.writeResultIntoFile(seq6, quantile, "Librarian", r);
        
            LehmerHigh lmhigh = new LehmerHigh();
           byte[] seq8 = lmhigh.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq8, quantile, "LehmerHigh", r);
           
          Random rand = new Random();
          byte[] seq0 = new byte[1000000];
          rand.NextBytes(seq0);
          WriterFile.writeResultIntoFile(seq0, quantile, "Вбудований",  r);
               
           Geffe geffe = new Geffe();
           byte[] seq9 = geffe.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq9, quantile, "Geffe", r);

           byte[] seq = BBS.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq, quantile,"BBS",r);
            
          byte[] seq1 = ByteModificationBBS.getRandomSequence(1000000);
          WriterFile.writeResultIntoFile(seq1, quantile, "ByteModificationBBS", r);
            
          byte[] seq2 = L20.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq2, quantile, "L20", r);
            
           byte[] seq3 = L89.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq3, quantile, "L89", r);

        byte[] seq4 = BM.getRandomSequence(10000);
         WriterFile.writeResultIntoFile(seq4, quantile, "BM", r);

         byte[] seq5 = ByteModificationBM.getRandomSequence(10000);
         WriterFile.writeResultIntoFile(seq5, quantile, "ByteModificationBM", r);

          

           LehmerLow lmlow = new LehmerLow();
           byte[] seq7 = lmlow.getRandomSequence(1000000);
           WriterFile.writeResultIntoFile(seq7, quantile, "LehmerLow", r);


            
        }
    }
}
