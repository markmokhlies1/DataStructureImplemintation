namespace Application
{
    public class InfixToPostfixEvaluator
    {
        private static int GetPrecedence(char op)
        {
            return op switch
            {
                '+' or '-' => 1,
                '*' or '/' => 2,
                _ => 0,
            };
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static string ConvertToPostfix(string infix)
        {
            Stack<char> stack = new Stack<char>();
            List<string> postfix = new List<string>();

            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];

                if (char.IsLetterOrDigit(c))
                {
                    postfix.Add(c.ToString());
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix.Add(stack.Pop().ToString());
                    }
                    stack.Pop(); // Remove '(' from the stack
                }
                else if (IsOperator(c))
                {
                    while (stack.Count > 0 && GetPrecedence(stack.Peek()) >= GetPrecedence(c))
                    {
                        postfix.Add(stack.Pop().ToString());
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix.Add(stack.Pop().ToString());
            }

            return string.Join(" ", postfix);
        }

        public static double EvaluatePostfix(string postfix, Dictionary<char, int> values)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in postfix.Split(' '))
            {
                if (char.IsLetterOrDigit(token[0]) && token.Length == 1) // Operand
                {
                    stack.Push(values[token[0]]);
                }
                else if (IsOperator(token[0])) // Operator
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(token[0] switch
                    {
                        '+' => a + b,
                        '-' => a - b,
                        '*' => a * b,
                        '/' => a / b,
                        _ => throw new InvalidOperationException("Invalid operator."),
                    });
                }
            }

            return stack.Pop();
        }

    }

}
