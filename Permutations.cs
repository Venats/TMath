using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Written by Taylor Ferguson.
//Takes a given list and creates a list of all possible permuations of it
//can only handel lists of 12 items or less, more would return lists of 13! items which would take up to much memeory 
namespace TMath
{
    public static class Permutations
    {

        private static List<T> DecodeLehmer<T>(Factoradic lehmerCode, Dictionary<int, T> totalOrder)
        {
            var decoded = new List<T>();
            int max = totalOrder.Count;
            var dictCopy = new List<T>(totalOrder.Select(x => x.Value));
            for (int i = max-1; i >= 0; i--)
            {
                int toBeAdded = lehmerCode.GetPlaceValue(i);
                T item = dictCopy[toBeAdded];
                decoded.Add(item);
                dictCopy.Remove(item);

            }
                return decoded;
        }

        public static List<List<T>> Permute<T>(this List<T> toBePermuted){
            var permutation = new List<List<T>>();
            int index = 0;
            var totalOrder = new Dictionary<int,T>();
            foreach(T item in toBePermuted){
                totalOrder[index++] = item;
            }
            if(toBePermuted.Count()>=13){
                Console.WriteLine("List to big to Permute");
                return null;
            }
            var max = new Factoradic(FactorialTable.Get(toBePermuted.Count()));
            var lehmerCode = new Factoradic(0);
            int count = 0;
            while (lehmerCode < max)
            {
                permutation.Add(DecodeLehmer(lehmerCode, totalOrder));
                count++;
                lehmerCode++;
            }
            return permutation;
        }
        //test code:
        //static void Main() { 
        //    var testList = new List<String>();
        //    testList.Add("a");
        //    testList.Add("b");
        //    testList.Add("c");
        //    testList.Add("d");
        //    testList.Add("e");
        //    foreach (var p in testList.Permute())
        //    {
        //        Console.WriteLine(String.Join("", p));
        //    }
        //    Console.ReadLine();
        //}
    }
}
