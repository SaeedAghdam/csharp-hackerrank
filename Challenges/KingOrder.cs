namespace HackerRank.Challenges
{
    //https://www.hackerrank.com/contests/gjirafa/challenges/new-king-order
    public static class KingOrder
    {
        public static void Run()
        {
            var names = new List<string>{
                "Steven XL", "Steven XVI", "David IX", "Mary XV", "Mary XIII", "Mary XX"
            };

            SortPrintKingsNames(names);
        }

        public static void SortPrintKingsNames(List<string> kings)
        {
            foreach (var king in kings.OrderBy(a => a, new RomanNameComparer()))
                Console.WriteLine(king);
        }
    }

    //Custom order class
    public class RomanNameComparer : IComparer<string>
    {
        private static Dictionary<string, int> romanNumbers = new();
        public int Compare(string a, string b)
        {
            var aS = a.Split(' ');
            var bS = b.Split(' ');

            var aName = aS[0];
            var aNumber = RomanToInt(aS[1]);

            var bName = bS[0];
            var bNumber = RomanToInt(bS[1]);

            if (aName == bName)
                return aNumber > bNumber ? 1 : -1;

            return aName.CompareTo(bName);
        }

        private static int RomanToInt(string s)
        {
            if (romanNumbers.TryGetValue(s, out var t))
                return t;

            int sum = 0;
            Dictionary<char, int> romanNumbersDictionary = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 }
            };
            for (int i = 0; i < s.Length; i++)
            {
                var currentRomanChar = s[i];
                romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
                if (i + 1 < s.Length && romanNumbersDictionary[s[i + 1]] > romanNumbersDictionary[currentRomanChar])
                    sum -= num;
                else
                    sum += num;
            }

            romanNumbers.TryAdd(s, sum);
            return sum;
        }
    }
}
