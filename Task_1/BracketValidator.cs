namespace Task_1
{
    public class BracketValidator
    {
        private static readonly Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        /// <summary>
        /// Метод проверки строки, на правильную последовательность
        /// открывающий/закрывающих скобок
        /// </summary>
        /// <param name="input">Строка содержащая скобки</param>
        /// <returns></returns>
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

            throw new ArgumentException("Невозможно закрыть скобку");
        }
    }
}