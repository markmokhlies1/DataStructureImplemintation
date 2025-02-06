using System.Collections.Generic;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InfixToPostfixEvaluator evaluator = new InfixToPostfixEvaluator();
            Console.WriteLine("Enter a symbolic infix expression:");
            string infix = Console.ReadLine();


            string postfix = InfixToPostfixEvaluator.ConvertToPostfix(infix);
            Console.WriteLine($"Postfix Expression: {postfix}");

            Dictionary<char, int> values = new Dictionary<char, int>();
            foreach (char c in infix)
            {
                if (char.IsLetter(c) && !values.ContainsKey(c))
                {
                    Console.Write($"Enter value for {c}: ");
                    values[c] = int.Parse(Console.ReadLine());
                }
            }

            double result =InfixToPostfixEvaluator.EvaluatePostfix(postfix, values);
            Console.WriteLine($"Result: {result}");
        }
    }
}
