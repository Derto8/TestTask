namespace TestTask
{
    internal class Program
    {
        private static readonly Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        static void Main(string[] args)
        {
            Console.WriteLine(Validate("(a[b{c}]d)"));
        }


        public static bool Validate(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (bracketPairs.ContainsValue(c))
                {
                    if (stack.Count == 0 || stack.Pop() != GetOpeningBracket(c))
                    {
                        return false;
                    }
                }
                else if (bracketPairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
            }

            return stack.Count == 0;
        }

        private static char GetOpeningBracket(char closingBracket)
        {
            foreach (KeyValuePair<char, char> pair in bracketPairs)
            {
                if (pair.Value == closingBracket)
                {
                    return pair.Key;
                }
            }

            throw new ArgumentException("Invalid closing bracket");
        }
    }
}
