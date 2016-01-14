using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath
{
    class NineDigitQuotientPi
    {
        public static void GetCloseToPi(List<int> nineDidPerm)
        {
            double closeToPi = 1;
            double pi = Math.PI;
            int numerator = 0;
            int denominator = 0;
            for (int i = 0; i < nineDidPerm.Count; i++)
            {
                long startNumer = (int)Math.Floor(nineDidPerm[i] * (pi - Math.Abs(pi - closeToPi)));
                if (startNumer > nineDidPerm[nineDidPerm.Count - 1])
                {
                    break;
                }
                int startIndex = nineDidPerm.BinarySearch((int)startNumer);
                if(startIndex < 0 ){
                    startIndex = ~startIndex;
                }
                for (int j = startIndex ; j < nineDidPerm.Count; j++)
                {
                    double quotient = (double)nineDidPerm[j] / (double)nineDidPerm[i];
                    if (quotient > (pi + Math.Abs(pi - closeToPi)))
                    {
                        break;
                    }
                    if (Math.Abs(quotient - pi) < Math.Abs(pi - closeToPi))
                    {
                        numerator = nineDidPerm[j];
                        denominator = nineDidPerm[i];
                        closeToPi = quotient;
                    }
                }
            }
            Console.WriteLine(closeToPi);
            Console.WriteLine("The numerator was: {0:d}",  numerator);
            Console.WriteLine("The denominator was: {0:d}", denominator);
            return;
        }
        static void Main()
        {
            var nineDidgetList = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                nineDidgetList.Add(i);
            }
            var permutationList = new List<int>();
            foreach(List<int> item in nineDidgetList.Permute() ){
                int decNum = 0;
                for (int i = 0; i < item.Count; i++)
                {
                    decNum += item[item.Count-i-1] * (int)Math.Pow(10, i);
                }
                permutationList.Add(decNum);

                
            }
            GetCloseToPi(permutationList);
            Console.ReadLine();
        }
    }
}
