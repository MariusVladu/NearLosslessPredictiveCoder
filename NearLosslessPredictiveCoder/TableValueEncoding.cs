using NearLosslessPredictiveCoder.Entities;
using System;

namespace NearLosslessPredictiveCoder
{
    public static class TableValueEncoding
    {
        public static TableEncodedValue EncodeValue(int value)
        {
            var encodedValue = new TableEncodedValue();

            if (value == 0)
            {
                return encodedValue;
            }

            encodedValue.NumberOf1Before0 = (int)Math.Log(Math.Abs(value), 2) + 1;

            if (value < 0)
            {
                int xLimit = (int)Math.Pow(2, encodedValue.NumberOf1Before0) - 1;
                encodedValue.ValueAfter0 = value + xLimit;
            }
            else
                encodedValue.ValueAfter0 = value;

            return encodedValue;
        }

        public static int DecodeValue(TableEncodedValue encodedValue)
        {
            int xLeftLimit = -((int)Math.Pow(2, encodedValue.NumberOf1Before0) - 1);

            if (xLeftLimit + encodedValue.ValueAfter0 >= xLeftLimit / 2)
                return encodedValue.ValueAfter0;

            return xLeftLimit + encodedValue.ValueAfter0;
        }
    }
}
