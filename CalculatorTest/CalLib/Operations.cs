namespace CalLib
{
    public class Operations
    {
        public double Summation(double a, double b) => a + b;
        public double Subtraction(double a, double b) => a - b;
        public double Multiplication(double a, double b) => a * b;
        public double Division(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Không thể chia cho 0.");
            return a / b;
        }
    }
}
