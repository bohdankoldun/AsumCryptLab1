using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LabaAsmCrypta1
{
    class CheckCriterionSequence
    {
        public static double[] verificationEquableProbability(byte[] sequence, double [] quantile)
        {
            double[] xiSquare = new double[quantile.Length+1];
            double[] count = new double[256];

            //скільки раз кожен байт зустрічається в нашій послідовності
            for (int i = 0; i < sequence.Length; i++)
                count[sequence[i]]++;

            //рахуєм статистику нашої послідовності
            double n = sequence.Length / 256;
            for (int i = 0; i < 256; i++)
                xiSquare[0] += Math.Pow((count[i] - n), 2);

            xiSquare[0] /= n;
           
           //граничні статистики
            for (int i = 0; i < quantile.Length; i++)
                xiSquare[i + 1] = Math.Pow(2 * 255, 0.5) * quantile[i] + 255;
                
            return xiSquare;
        }



        public static double[] verificationIndependence(byte[] sequence, double[] quantile)
        {
            double[] xiSquare = new double[quantile.Length+1];
            int[,] count = new int[256,256];
            int[] countFirst = new int[256];
            int[] countSecond = new int[256];
            int n = sequence.Length/2;  // кількість пар, які ми бере
            int m = n * 2;
         
            //кількість кожної пари байтів, скільки кожен байт зустрі-ся на 1-му і 2-му місці
            for (int i = 0; i < m; i = i+2)
            {
                int k = sequence[i], b = sequence[i + 1];
               // Console.Write(k + "-"+b+" ");
                count[k, b]++;
                countFirst[k]++;
                countSecond[b]++;
            }

            FileStream file1 = new FileStream("d:\\hhhh.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file1);
            for (int i = 0; i < 256; i++)
            {

                for (int j = 0; j < 256; j++)

                    writer.Write(count[i, j] + "   ");

                writer.WriteLine();
            }
            file1.Close();

            double temp = 0,pow;
            for (int i = 0; i < 256; i++)
            {
                if (countFirst[i] != 0)
                {
                    temp = 0;
                    for (int j = 0; j < 256; j++)
                    {
                        if (countSecond[j] != 0)
                        {
                            pow = Math.Pow(count[i, j], 2);
                            temp += pow/countSecond[j];
                        }
                    }
                   
                    temp /= countFirst[i];
                    xiSquare[0] += temp;
                }

            }
           
            xiSquare[0] = n * (xiSquare[0]-1);
          

            //граничні статистики
            double l = 255 * 255;
            for (int i = 0; i < quantile.Length; i++)
                xiSquare[i+1] = Math.Pow(2 * l, 0.5) * quantile[i] + l;
               
            return xiSquare;
        }



        public static double[] verificationUniformity(byte[] sequence,double[] quantile, int r)
        {
            double[] xiSquare = new double[quantile.Length+1];
            int[,] vij = new int[256, r];
            int[] vi = new int[256];
            int m = sequence.Length / r;
            int n = m*r;

            for (int i = 0; i < r; i++)
                for (int j = 0; j < m; j++)
                    vij[sequence[i*m+j],i]++;
                
            for (int i = 0; i < n; i++)
                vi[sequence[i]]++;

            int ai = m;
         

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < r; j++)
                    if (vi[i] != 0 && ai !=0)
                        xiSquare[0] += 1000000*Math.Pow(vij[i, j], 2)/(vi[i] * ai);
            }

            xiSquare[0] = n * (xiSquare[0] /1000000 - 1);

            double l = 255*(r-1);
            for (int i = 0; i < quantile.Length; i++)
                xiSquare[i+1] = Math.Pow(2 * l, 0.5) * quantile[i] + l;

            return xiSquare;
        }
    }
}
