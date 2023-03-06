namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n = 0;
            double d = 0;
            string mode="";

            Console.Write("Please input an integer number:");
            s = Console.ReadLine();
            n = Int32.Parse(s);
            Console.Write("Please input a double number: ");
            s = Console.ReadLine();
            d = Double.Parse(s);
            Console.Write("Please input the operator:");
            s = Console.ReadLine();
            mode = s;

            switch(mode)
            {
                case "+":
                    Console.WriteLine($"n+d: {n + d} ");
                    break;
                case "-":
                    Console.WriteLine($"n-d: {n - d} ");
                    break;
                case "*":
                    Console.WriteLine($"n*d: {n * d} ");
                    break;
                case "/":
                    Console.WriteLine($"n/d: {n / d}");
                    break;
            }

        }
    }
}