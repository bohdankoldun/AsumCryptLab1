using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class WriterFile
    {
        public static void writeResultIntoFile(byte[] sequence, double[] quantile, string nameGenerator,int r)
        {
            double[] mas1 = CheckCriterionSequence.verificationEquableProbability(sequence, quantile);
            double[] mas2 = CheckCriterionSequence.verificationIndependence(sequence, quantile);
            double[] mas3 = CheckCriterionSequence.verificationUniformity(sequence, quantile, r);

            FileStream file1 = new FileStream("d:\\"+nameGenerator+".txt", FileMode.Create); 
            StreamWriter writer = new StreamWriter(file1);
            writer.WriteLine("Генератор: " + nameGenerator + "    Довжина послідовності = " + sequence.Length);
            writer.WriteLine();
            writer.WriteLine("Статистика послідовності: " + "рівн. - " + mas1[0] + " незал. - " + mas2[0] + " однор. - " + mas3[0]);
            writer.WriteLine();
            writer.WriteLine("Граничне значення:"); 
            writer.WriteLine("При alpha = 0,01:         " + "рівн. - " + mas1[1] + " незал. - " + mas2[1] + " однор. - " + mas3[1]);
            writer.WriteLine("При alpha = 0,05:         " + "рівн. - " + mas1[2] + " незал. - " + mas2[2] + " однор. - " + mas3[2]);
            writer.WriteLine("При alpha = 0,1:          " + "рівн. - " + mas1[3] + " незал. - " + mas2[3] + " однор. - " + mas3[3]);
            writer.WriteLine();

            if(sequence.Length >=1000)
                for (int i = 0; i < 1000; i++ )
                    writer.Write(sequence[i] + "  ");
            writer.Close(); 

        }
    }
}
