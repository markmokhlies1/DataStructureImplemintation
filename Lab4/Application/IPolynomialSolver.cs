namespace Application
{
    public interface IPolynomialSolver
    {
        void SetPolynomial(char poly, int[][] terms);
        string Print(char poly);
        void ClearPolynomial(char poly);
        float EvaluatePolynomial(char poly, float value);
        int[][] Add(char poly1, char poly2);
        int[][] Subtract(char poly1, char poly2);
        int[][] Multiply(char poly1, char poly2);
    }
}
