namespace SimpleCalclator
{
    public class CalcOperation : ICalclator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public float Divide(int x, int y)
        {
            return (float)x / (float)y;
        }
    }
}
