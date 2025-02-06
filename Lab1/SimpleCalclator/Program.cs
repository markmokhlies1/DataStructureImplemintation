namespace SimpleCalclator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalcOperation ope1 = new CalcOperation();
            int x = 5, y = 9;
            int z=ope1.Add(x, y);
            Console.WriteLine(z);
            float w=ope1.Divide(x, y);
            Console.WriteLine(w);
            Console.ReadKey();
        }
    }
}
