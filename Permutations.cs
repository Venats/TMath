using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath
{
    class Permutations<T>
    {
        public static List<List<T>> Permute(List<T> toBePermuted){
            var permutation = new List<List<T>>();
            int index = 0;
            Dictionary<int, T> d = new Dictionary<int,T>();
            foreach(T item in toBePermuted){
                d[index++] = item;
            }

            return permutation;
        }
    }
}
