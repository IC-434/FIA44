namespace CalcLibrary
{
    public static class Calculate
    {
        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="a">Summand 1</param>
        /// <param name="b">Summand 2</param>
        /// <returns>Sum</returns>
        public static int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Calculates the difference of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Calculates the product of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// Calculates the quotient of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }
}
