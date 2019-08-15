using System.Numerics;

namespace Day4.Library
{
    // Implement extension method to get string binary representation of 
    // a double precision real number in IEEE 754 format
    public static class DoubleToBinaryConverter
    {
        /// <summary>
        /// Gets binary representation of a double precision real number
        /// </summary>
        /// <param name="numberSource">Given number</param>
        /// <returns>String binary representation</returns>
        public static string ConvertDoubleToBinary(this double numberSource)
        {
            if (double.IsNaN(numberSource))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            if (double.IsPositiveInfinity(numberSource))
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }

            if (double.IsNegativeInfinity(numberSource))
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (numberSource == double.Epsilon)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }

            if (numberSource == 0)
            {
                if (double.IsNegativeInfinity(1.0 / numberSource))
                {
                    return "1000000000000000000000000000000000000000000000000000000000000000";
                }
                else
                {
                    return "0000000000000000000000000000000000000000000000000000000000000000";
                }
            }

            string result = "";

            string sign = "0";
            if (numberSource < 0.0)
            {
                sign = "1";
                numberSource = -numberSource;
            }

            BigInteger wholePart = (BigInteger)numberSource;
            double decimalPart = numberSource - (double)wholePart;

            string wholePartBinary = ConvertBigIntToBinary((BigInteger)numberSource);
            string decimalPartBinary = ConvertDecimalPortionToBinary(decimalPart);

            int firstBitPosition = (wholePartBinary + decimalPartBinary).IndexOf('1');
            int shift = wholePartBinary.Length - firstBitPosition - 1;            

            string exponent = ConvertBigIntToBinary(1023 + shift);
            exponent = exponent.PadLeft(11, '0');

            string mantissa = (wholePartBinary + decimalPartBinary).Substring(firstBitPosition + 1);

            result = sign + exponent + mantissa;

            if (result.Length <= 64)
            {
                result = result.PadRight(64, '0');
            }
            else
            {
                result = result.Remove(64);
            }

            return result;
        }

        /// <summary>
        /// Converts positive big integer to string binary representation
        /// </summary>
        /// <param name="numberSource">Given number</param>
        /// <returns>String binary representation</returns>
        private static string ConvertBigIntToBinary(BigInteger numberSource)
        {
            if (numberSource == 0)
            {
                return "0";
            }

            string result = "";
            int bit;

            while (numberSource > 0)
            {
                bit = (int)(numberSource % 2);
                numberSource = numberSource / 2;
                result = bit.ToString() + result;
            }

            return result;
        }

        /// <summary>
        /// Converts decimal portion to string binary representation
        /// </summary>
        /// <param name="numberSource">Given decimal portion</param>
        /// <returns>String binary representation</returns>
        private static string ConvertDecimalPortionToBinary(double numberSource)
        {
            if (numberSource == 0)
            {
                return "0";
            }

            string result = "";
            int bit;

            while (numberSource > 0.0)
            {
                numberSource = numberSource * 2;
                bit = (int)(numberSource);
                if (numberSource >= 1.0)
                {
                    numberSource -= 1.0;
                }
                result += bit.ToString();
            }

            return result;
        }
    }
}
