namespace HackerRank
{
    //https://www.hackerrank.com/challenges/one-week-preparation-kit-lego-blocks/problem

    public static class LegoBlocks
    {
        private static long _mod = 1000000000 + 7;
        /*
            * Complete the 'legoBlocks' function below.
            *
            * The function is expected to return an INTEGER.
            * The function accepts following parameters:
            *  1. INTEGER n
            *  2. INTEGER m
            */

        public static int legoBlocks(int n, int m)
        {
            if (n < 2 || m < 1) return 0;
            if (m == 1) return 1;

            // - Step 1: consider only one row
            var total = new long[m + 1];

            // set a flag (-1) to calculate only once
            for (int i = 0; i < total.Length; i++)
                total[i] = -1;

            FillTot(total, m);

            // - Step 2: extend to all rows
            for (var i = 0; i < total.Length; i++)
            {
                long tmp = 1;
                for (var j = 0; j < n; j++)
                {
                    tmp = (tmp * total[i]) % _mod;
                }
                total[i] = tmp;
            }

            // - Step 3: subtract the vertically unstable
            // don't calculate the vertically unstable at first
            var result = new long[m + 1];
            // set a flag (-1) to calculate only once
            for (var i = 0; i < result.Length; i++)
                result[i] = -1;

            getResult(total, result, m);

            // solution 1:
            // - subtract the vertically unstable
            // return (int) ((total[m] - result[m]) % MOD);

            // solution 2:
            // - return the result
            return (int)(result[m] % _mod);
        }


        static long getResult(long[] total, long[] result, int i)
        {
            if (result[i] == -1)
            {
                if (i != 1)
                {
                    result[i] = total[i];
                    for (int j = 1; j < i; j++)
                        result[i] -= getResult(total, result, j) * total[i - j] % _mod;
                }
                else
                    result[i] = 1;
            }
            return result[i];
        }

        // fill totals partially
        static long FillTot(long[] total, int i)
        {
            if (i < 0) return 0;

            if (total[i] == -1)
            {
                if (i == 0 || i == 1)
                    total[i] = 1;
                else
                    total[i] = (FillTot(total, i - 1) + FillTot(total, i - 2) + FillTot(total, i - 3) + FillTot(total, i - 4)) % _mod;
            }
            return total[i];
        }
        public static void Run()
        {
            var t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                var firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                var n = Convert.ToInt32(firstMultipleInput[0]);
                var m = Convert.ToInt32(firstMultipleInput[1]);
                var result = legoBlocks(n, m);
                Console.WriteLine(result);
            }
        }
    }
}