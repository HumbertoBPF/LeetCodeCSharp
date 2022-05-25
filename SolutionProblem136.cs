using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SolutionProblem136
    {
        public int SingleNumber(int[] nums)
        {
            int singleNumber = 0;
            Dictionary<int, bool> numbersOccurrences = new Dictionary<int, bool>();

            foreach (int num in nums)
            {
                try
                {
                    // When a number has already been seen, we remove it from the dictionary since it is the second occurrence
                    bool isSeenNumber = numbersOccurrences[num];
                    numbersOccurrences.Remove(num);
                }
                catch
                {
                    // If it is the first time that the number is seen, add it to the dictionary
                    numbersOccurrences.Add(num, true);
                }
            }
            // The number that remains in the dictionary keys is the number that happen only once
            foreach (int num in numbersOccurrences.Keys)
            {
                singleNumber = num;
            }

            return singleNumber;
        }
    }
}
