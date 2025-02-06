namespace Application
{
    public class PolynomialSolver : IPolynomialSolver
    {
        private Dictionary<char, List<(int Coefficient, int Exponent)>> polynomials = new();

        public void SetPolynomial(char poly, int[][] terms)
        {
            if (terms == null || terms.Length == 0)
                throw new ArgumentException("Terms cannot be null or empty.");

            var termList = terms.Select(t => (Coefficient: t[0], Exponent: t[1])).ToList();
            termList.Sort((a, b) => b.Exponent.CompareTo(a.Exponent));

            polynomials[poly] = termList;
        }

        public string Print(char poly)
        {
            if (!polynomials.ContainsKey(poly))
                throw new InvalidOperationException("Polynomial not set.");

            var terms = polynomials[poly];
            return string.Join(" + ", terms.Select(t => $"{t.Coefficient}x^{t.Exponent}"));
        }

        public void ClearPolynomial(char poly)
        {
            if (!polynomials.ContainsKey(poly))
                throw new InvalidOperationException("Polynomial not set.");

            polynomials.Remove(poly);
        }

        public float EvaluatePolynomial(char poly, float value)
        {
            if (!polynomials.ContainsKey(poly))
                throw new InvalidOperationException("Polynomial not set.");

            float result = 0;
            foreach (var (coefficient, exponent) in polynomials[poly])
            {
                result += coefficient * (float)Math.Pow(value, exponent);
            }
            return result;
        }

        public int[][] Add(char poly1, char poly2) => CombinePolynomials(poly1, poly2, (a, b) => a + b);

        public int[][] Subtract(char poly1, char poly2) => CombinePolynomials(poly1, poly2, (a, b) => a - b);

        public int[][] Multiply(char poly1, char poly2)
        {
            if (!polynomials.ContainsKey(poly1) || !polynomials.ContainsKey(poly2))
                throw new InvalidOperationException("Polynomial not set.");

            var result = new List<(int Coefficient, int Exponent)>();

            foreach (var term1 in polynomials[poly1])
            {
                foreach (var term2 in polynomials[poly2])
                {
                    result.Add((term1.Coefficient * term2.Coefficient, term1.Exponent + term2.Exponent));
                }
            }

            var grouped = result.GroupBy(t => t.Exponent)
                                .Select(g => (Coefficient: g.Sum(t => t.Coefficient), Exponent: g.Key))
                                .Where(t => t.Coefficient != 0)
                                .OrderByDescending(t => t.Exponent)
                                .ToArray();

            return grouped.Select(t => new int[] { t.Coefficient, t.Exponent }).ToArray();
        }

        private int[][] CombinePolynomials(char poly1, char poly2, Func<int, int, int> operation)
        {
            if (!polynomials.ContainsKey(poly1) || !polynomials.ContainsKey(poly2))
                throw new InvalidOperationException("Polynomial not set.");

            var result = polynomials[poly1]
                .Concat(polynomials[poly2])
                .GroupBy(t => t.Exponent)
                .Select(g => (Coefficient: operation(g.Sum(t => t.Coefficient), 0), Exponent: g.Key))
                .Where(t => t.Coefficient != 0)
                .OrderByDescending(t => t.Exponent)
                .ToArray();

            return result.Select(t => new int[] { t.Coefficient, t.Exponent }).ToArray();
        }
    }
}
