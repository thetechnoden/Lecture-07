using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    public class Calculator<T>
    {
        public delegate T BinaryOperation(T a, T b);

        public BinaryOperation Addition { get; set; }
        public BinaryOperation Subtraction { get; set; }
        public BinaryOperation Multiplication { get; set; }
        public BinaryOperation Division { get; set; }

        public Calculator(BinaryOperation addition, BinaryOperation subtraction, BinaryOperation multiplication, BinaryOperation division)
        {
            Addition = addition;
            Subtraction = subtraction;
            Multiplication = multiplication;
            Division = division;
        }

        public T Add(T a, T b)
        {
            return Addition(a, b);
        }

        public T Subtract(T a, T b)
        {
            return Subtraction(a, b);
        }

        public T Multiply(T a, T b)
        {
            return Multiplication(a, b);
        }

        public T Divide(T a, T b)
        {
            if (EqualityComparer<T>.Default.Equals(b, default(T)))
            {
                throw new DivideByZeroException("Division by zero is impossible.");
            }
            return Division(a, b);
        }
    }
}
