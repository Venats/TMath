using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath
{
    class FactorialTable
    {
        private static int[] saved = new int[13];
        private static bool[] isSet = Enumerable.Repeat<bool>(false, 13).ToArray();

        public static int Get(int n) {

            if (isSet[n])
            {
                return saved[n];

            }
            saved[n] = Factorial(n);
            isSet[n] = true;
            return saved[n];

        }

        private static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int result = n*Get(n - 1);
            return result;
        }


    }
}
