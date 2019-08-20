using System;
using System.Globalization;
using System.Threading;

namespace Day6.Library
{
    // Develop an immutable Polynomial class for working
    // with polynomials of a real type (use a sz-array
    // to store coefficients). Override virtual methods
    // of the Object class. Overload operations acceptable
    // for working with polynomials including "==" and "!=".
    public class Polynomial
    {
        /// <summary>
        /// SZ-array to store coefficients
        /// </summary>
        private double[] coefficients;

        /// <summary>
        /// Constructor taking coefficients of polynimial as argument
        /// </summary>
        /// <param name="coeffs">Coefficients of polynimial</param>
        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null || coeffs.Length == 0)
            {
                throw new ArgumentException("coeffs should not be null or empty");
            }

            int degree = coeffs.Length - 1;

            this.coefficients = new double[degree + 1];

            Array.Copy(coeffs, this.coefficients, degree + 1);

            this.HighestDegree = degree;

            this.Resize();
        }

        /// <summary>
        /// Highest degree of the polynomial
        /// </summary>
        public int HighestDegree { get; private set; }

        /// <summary>
        /// Converts a polynomial to its string representation
        /// </summary>
        /// <returns>String that represents polynomial</returns>
        public override string ToString()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;

            if (this.HighestDegree == 0)
            {
                return this.coefficients[0].ToString();
            }

            string result = string.Empty;

            int i;
            string sign = "";

            for (i = this.HighestDegree; i > 1; i--)
            {
                if (this.coefficients[i] != 0)
                {
                    sign = this.GetSign(coefficients[i]);

                    if (this.coefficients[i] == 1)
                    {
                        result += sign + "x^" + i;
                    }
                    else if (this.coefficients[i] == -1)
                    {
                        result += "-" + "x^" + i;
                    }
                    else
                    {
                        result += sign + this.coefficients[i] + "x^" + i;
                    }
                }
            }

            if (i > 0 && this.coefficients[i] != 0)
            {
                sign = this.GetSign(coefficients[i]);

                if (this.coefficients[i] == 1)
                {
                    result += sign + "x";
                }
                else if (this.coefficients[i] == -1)
                {
                    result += "-x";
                }
                else
                {
                    result += sign + this.coefficients[i] + "x";
                }
            }

            if (this.coefficients[0] != 0)
            {
                sign = this.GetSign(coefficients[0]);

                result += sign + this.coefficients[0];
            }

            return result.TrimStart('+');
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current polynomial
        /// </summary>
        /// <param name="obj">The object to compare with the current polynomial</param>
        /// <returns>True, if the specified object is equal to the current polynomial</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Polynomial polynomial = (Polynomial)obj;

            return this.ToString() == polynomial.ToString();
        }

        /// <summary>
        /// Gets a hash code for the current polynomial
        /// </summary>
        /// <returns>A hash code for the current polynomial</returns>
        public override int GetHashCode()
        {
            int result = 0;

            foreach (double coefficient in this.coefficients)
            {
                result += coefficient.GetHashCode() ^ ((int)(31 + coefficient) + 1);
            }

            return result;
        }

        /// <summary>
        /// Sums two polynomials as new polynomial
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>The sum of two polynomials as new polynomial</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int length = Math.Max(a.coefficients.Length, b.coefficients.Length);
            double[] coeffs = new double[length];

            for (int i = 0; i < a.coefficients.Length; i++)
            {
                coeffs[i] = a.coefficients[i];
            }

            for (int i = 0; i < b.coefficients.Length; i++)
            {
                coeffs[i] += b.coefficients[i];
            }

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Substracts one polynomial from another
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>The result of substraction of two polynomials as new polynomial</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int length = Math.Max(a.coefficients.Length, b.coefficients.Length);
            double[] coeffs = new double[length];

            for (int i = 0; i < a.coefficients.Length; i++)
            {
                coeffs[i] = a.coefficients[i];
            }

            for (int i = 0; i < b.coefficients.Length; i++)
            {
                coeffs[i] -= b.coefficients[i];
            }

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Multiplicates polynomial by number
        /// </summary>
        /// <param name="a">Given polynomial</param>
        /// <param name="number">Given number</param>
        /// <returns>Result of multiplication of polynomial by number as new polynomial</returns>
        public static Polynomial operator *(Polynomial a, double number)
        {
            double[] coeffs = new double[a.coefficients.Length];

            for (int i = 0; i < a.coefficients.Length; i++)
            {
                coeffs[i] = a.coefficients[i] * number;
            }

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Multiplicates number by polynomial
        /// </summary>
        /// <param name="number">Given number</param>
        /// <param name="a">Given polynomial</param>
        /// <returns>Result of multiplication of number by polynomial as new polynomial</returns>
        public static Polynomial operator *(double number, Polynomial a)
        {
            return a * number;
        }

        /// <summary>
        /// Multiplicates two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>The product of two polynomials as new polynomial</returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            double[] coeffs = new double[a.coefficients.Length + b.coefficients.Length - 1];

            for (int i = 0; i < a.coefficients.Length; i++)
            {
                for (int j = 0; j < b.coefficients.Length; j++)
                {
                    coeffs[i + j] += a.coefficients[i] * b.coefficients[j];
                }
            }

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Checks if two polynomials are equal
        /// </summary>
        /// <param name="obj1">First polynomial</param>
        /// <param name="obj2">Second polynomial</param>
        /// <returns>True if polynomials are equal</returns>
        public static bool operator ==(Polynomial obj1, Polynomial obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Checks if two polynomials are not equal
        /// </summary>
        /// <param name="obj1">First polynomial</param>
        /// <param name="obj2">Second polynomial</param>
        /// <returns>True if polynomials are not equal</returns>
        public static bool operator !=(Polynomial obj1, Polynomial obj2)
        {
            return !obj1.Equals(obj2);
        }

        /// <summary>
        /// Calculates derivative of the polynomial
        /// </summary>
        /// <returns>The derivative of polynomial as new polynomial</returns>
        public Polynomial Derivative()
        {
            double[] coeffs = new double[this.coefficients.Length - 1];

            for (int i = 0; i < coeffs.Length; i++)
            {
                coeffs[i] = (i + 1) * this.coefficients[i + 1];
            }

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Calculates the result of polynomial function
        /// </summary>
        /// <param name="x">Given argument</param>
        /// <returns>The result of polynomial function</returns>
        public double Calculate(double x)
        {
            double result = 0;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                result += this.coefficients[i] * Math.Pow(x, i);
            }

            return result;
        }

        /// <summary>
        /// Gets the special sign of coefficient
        /// </summary>
        /// <param name="number">Given coefficient</param>
        /// <returns>"+" if number is positive, empty string otherwise</returns>
        private string GetSign(double number)
        {
            if (number >= 0)
            {
                return "+";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Changes the size of coefficients array if needed
        /// </summary>
        private void Resize()
        {
            bool sizeChanged = false;

            while (this.coefficients[this.HighestDegree] == 0 && this.HighestDegree > 0)
            {
                this.HighestDegree -= 1;
                sizeChanged = true;
            }

            if (sizeChanged)
            {
                double[] newCoefficients = new double[this.HighestDegree + 1];

                Array.Copy(this.coefficients, newCoefficients, this.HighestDegree + 1);
                
                this.coefficients = newCoefficients;
            }
        }
    }
}
