using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath
{
    class Factoradic
    {
        private List<int> baseFactoradic;
        private int baseTen;
        public Factoradic(int baseTen)
        {
            baseFactoradic = ToFactoradic(baseTen);
            this.baseTen = baseTen;
        }

        public List<int> ToFactoradic(int baseTen)
        {
            List<int> placeValues = new List<int>() ;
            int i = 0;
            while (baseTen != 0)
            {
                placeValues.Add(baseTen % (i + 1));
                baseTen = baseTen / (i + 1);
                i++;
            }
            return placeValues;

        }

        public static Factoradic operator +(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            int sum = aTen + bTen;
            var sumFactoradic = new Factoradic(sum);
            return sumFactoradic;
        }

        public static Factoradic operator *(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            int product = aTen * bTen;
            var productFactoradic = new Factoradic(product);
            return productFactoradic;
        }

        public static Factoradic operator ++(Factoradic a)
        {
            int aTen = a.ToBaseTen();
            var sumFactoradic = new Factoradic(aTen+1);
            return sumFactoradic;
        }

        public static Factoradic operator -(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            int difference = aTen - bTen;
            var diffFactoradic = new Factoradic(difference);
            return diffFactoradic;
        }
        public override int GetHashCode()
        {
            return baseTen.GetHashCode();
        }
        public override bool Equals(Object a)
        {
            Factoradic b = a as Factoradic;
            if (b == null)
            {
                return false;
            }
            int bTen = b.ToBaseTen();
            bool tF = bTen == baseTen;
            return tF;
        }

        public static bool operator >=(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            bool tF = aTen >= bTen;
            return tF;
        }

        public static bool operator <=(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            bool tF = aTen <= bTen;
            return tF;
        }

        public static bool operator <(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            bool tF = aTen < bTen;
            return tF;
        }

        public static bool operator >(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            bool tF = aTen > bTen;
            return tF;
        }

        public static Factoradic operator /(Factoradic a, Factoradic b)
        {
            int aTen = a.ToBaseTen();
            int bTen = b.ToBaseTen();
            int quotient = aTen / bTen;
            var quotFactoradic = new Factoradic(quotient);
            return quotFactoradic;
        }

        public int ToBaseTen()
        {
            return baseTen;
        }

        public override String ToString()
        {
            String factString = "";
            for (int i = baseFactoradic.Count - 1; i >= 0; i--)
            {
                factString += baseFactoradic[i].ToString() + "*" + (i).ToString() + "!";
                if (i != 0)
                {
                    factString += " + ";
                }

            }
            return factString;
        }

        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = n; i > 0; i--)
            {
                result *= i;
            }
                return result;
        }

        static void Main(string[] args)
        {
            Factoradic num = new Factoradic(-1000);
            Console.WriteLine(num.ToString());
            int numBaseTen = num.ToBaseTen();
            Console.WriteLine(numBaseTen);
            Console.ReadLine();
        }
    }
}
