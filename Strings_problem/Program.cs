using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] avg = { 25, 23, 1, 2, 3, 4, 5, 6, 7, 8, 9, 80, 78, 88 };
            Console.WriteLine(AutoScale(avg, 2));
        }
        public int SumSubarrayMins(int[] nums)
        {
            long result = 0;
            int n = nums.Length;
            Stack<int> inc = new Stack<int>();

            for (int i = 0; i <= n; i++)
            {
                //find sum of minimum subarray 
                while (inc.Count > 0 && (i == n || nums[inc.Peek()] > nums[i]))
                {
                    int currIndex = inc.Pop();
                    int leftBound = inc.Count > 0 ? inc.Peek() : -1;
                    int rightBound = i;
                    result += (currIndex - leftBound) * (rightBound - currIndex) * (long)nums[currIndex];
                }
                inc.Push(i);
            }

            return (int)(result % 1000000007);
        }

        public int SumSubarrayMins1(int[] arr)
        {
            Stack<int> stk = new Stack<int>();
            long res = 0;
            int mid_index = 0;
            int n = arr.Length;
            stk.Push(-1);
            for (int i = 0; i < n; i++)
            {
                while (stk.Count > 1 && arr[i] < arr[stk.Peek()])
                {
                    mid_index = stk.Pop();

                    res += ((long)arr[mid_index] * (mid_index - stk.Peek()) * (i - mid_index));
                    //Console.WriteLine(res);
                }
                stk.Push(i);
            }

            while (stk.Count > 1)
            {
                mid_index = stk.Pop();
                res += ((long)arr[mid_index] * (mid_index - stk.Peek()) * (n - mid_index));
                //Console.WriteLine(res);
            }

            return (int)(res % 1000000007);
        }

        public static int AutoScale(int[] avg, int instances)
        {
            int j = 0;
            while (j < avg.Length)
            {
                if (avg[j] < 25)
                {
                    if(instances>1)
                    {
                        instances = (int)Math.Ceiling((double)instances/ 2);
                        j = j + 10;
                    }                   
                }
                else if (avg[j] > 60)
                {
                    if (instances < 217)
                    {
                        instances = (instances * 2);
                        j = j + 10;
                    }
                }
                else
                {
                    j++;
                }
            }
            return instances;
        }
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            int m = horizontalCuts.Length;
            int n = verticalCuts.Length;
            long hSlice = Math.Max(horizontalCuts[0], (h - horizontalCuts[m - 1]));
            long vSlice = Math.Max(verticalCuts[0], (w - verticalCuts[n - 1]));
            for (int i = 1; i < m; i++)
            {
                hSlice = Math.Max(hSlice, (horizontalCuts[i] - horizontalCuts[i - 1]));
            }

            for (int j = 1; j < n; j++)
            {
                vSlice = Math.Max(vSlice, (verticalCuts[j] - verticalCuts[j - 1]));
            }

            return (int)((hSlice * vSlice) % (1000000007));
        }
        //public int splitString(String s)
        //{
        //    char[] array = s.toCharArray();
        //    int[] dp = new int[array.length + 1];
        //    dp[0] = 1;
        //    for (int i = 1; i < dp.length; i++)
        //    {
        //        int j = i - 1;
        //        while (j >= 0 && j >= i - 3)
        //        {
        //            if (isPrime(s.substring(j, i)))
        //            {
        //                dp[i] += dp[j];
        //            }
        //            j--;
        //        }
        //    }
        //    return dp[array.length];
        //}
        //public boolean isPrime(String s)
        //{
        //    int num = Integer.parseInt(s);
        //    if (num < 2)
        //    {
        //        return false;
        //    }
        //    for (int i = 2; i * i <= num; i++)
        //    {
        //        if (num % i == 0)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
