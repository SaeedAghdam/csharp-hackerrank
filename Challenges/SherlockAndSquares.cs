namespace HackerRank.Challenges
{
    //https://www.hackerrank.com/challenges/sherlock-and-squares
    public static class SherlockAndSquares
    {
        public static void Run()
        {
            Console.WriteLine(squares(17, 17));
        }

        public static int squares(int a, int b)
        {
            var counter = 0;

            if (a > b)
                return counter;

            var sqrtA = Math.Sqrt(a);
            var sqrtB = Math.Sqrt(b);

            for (int i = (int)sqrtA; i <= (int)sqrtB; i++)
            {
                var _i = i * i;
                if (_i >= a && a <= b)
                    counter++;
            }

            return counter;
        }
    }
}
