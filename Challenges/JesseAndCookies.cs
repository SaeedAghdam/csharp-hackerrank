namespace HackerRank.Challenges
{
    public static class JesseAndCookies
    {
        //https://www.hackerrank.com/challenges/one-week-preparation-kit-jesse-and-cookies/problem
        /*
         * Complete the 'cookies' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY A
         */

        public static int cookies(int k, List<int> A)
        {
            var total = 0;
            var less = A.ToList();
            var firstGreatList = A.Where(a => a >= k);

            while (true)
            {
                if (AllHasEnoughtSweet(k, less))
                    return total;

                if (less.Count < 2)
                    return -1;

                less = less.Where(a => a < k).ToList();
                if (firstGreatList.Any())
                    less.Add(firstGreatList.OrderByDescending(a => a).FirstOrDefault());

                var least = less.OrderBy(a => a).Take(2).ToList();
                less.Remove(least.First());
                less.Remove(least.Last());
                less.Insert(0, least.First() + (2 * least.Last()));
                total++;

                //Console.WriteLine(total);
                //least.ForEach(a => Console.Write($"{a} "));
                //Console.WriteLine();
                //less.ForEach(a => Console.Write($"{a} "));
                //Console.WriteLine();
                //Console.WriteLine("-----------------------------------------------");
            }
        }

        public static bool AllHasEnoughtSweet(int k, List<int> A)
        {
            return A.All(a => a >= k);
        }
        public static void Run()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();
            int result = cookies(k, A);
            Console.WriteLine(result);
        }
    }
}