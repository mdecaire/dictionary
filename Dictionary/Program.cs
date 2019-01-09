using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            int ratio = 2;//that ratio which numbers are compared to

            List<long> initialArray = new List<long> { 1, 2, 1, 2, 4 };

            long tripletCount = countTriplets(initialArray, ratio);
            Console.WriteLine(tripletCount);
        }
        static long countTriplets(List<long> arr, long ratio)
        {
            //counter for the number of triplets there are
            long result = 0;

            //stores the count of the number of second elements that occur
            Dictionary<long, long> secondElementInTripletCount = new Dictionary<long, long>();

            //stores the final part of the triplet AND the number of occurences
            Dictionary<long, long> finalElementInTripleCount = new Dictionary<long, long>();

            long countOfElementsNeeded = 0;
            //loops through entire array 
            foreach (long index in arr)
            {
                //looks for the element to occur in  the final count
                if (finalElementInTripleCount.ContainsKey(index))
                {
                    //if it finds the element has occured the triple is complete and will be added to result
                    result += finalElementInTripleCount[index];
                }

                //looks for element at index to occur in first map
                if (secondElementInTripletCount.ContainsKey(index))
                {
                    //counts how many times a number has occured to determine results needed
                    countOfElementsNeeded = secondElementInTripletCount[index];

                    //only concerned with the index times the ratio
                    long correctElement = index * ratio;

                    //adding the expected final number of triplet to map
                    if (finalElementInTripleCount.ContainsKey(correctElement))//if it already exists in map
                    {
                        finalElementInTripleCount[correctElement] += countOfElementsNeeded;
                    }
                    else//if it does not yet exist in map
                    {
                        finalElementInTripleCount.Add(correctElement, countOfElementsNeeded);
                    }
                }
                if (secondElementInTripletCount.ContainsKey(index * ratio))
                {
                    //adds a count to the ratio if it has already occured
                    secondElementInTripletCount[index * ratio] += 1;
                }
                else
                {
                    //creates element if it does not exist already
                    secondElementInTripletCount.Add(index * ratio, 1);
                }

            }
            return result;
        }

    }
}
