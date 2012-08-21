using System;
using System.Runtime.InteropServices;

namespace ApproximationNET
{
    public static class Approximation
    {
        /// <summary>
        /// Sine approximation using polynominals.
        /// Has a low precision.
        /// </summary>
        /// <param name="x">The value</param>
        /// <returns>Sine of x</returns>
        public static float LowSin(float x)
        {
            //always wrap input angle to -PI..PI
            if (x < -(float)Math.PI)
                x += (float)Math.PI * 2;
            else if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            //compute sine
            if (x < 0)
                return (4 / (float)Math.PI) * x + (4 / (float)(Math.PI * Math.PI)) * x * x;
            
            return (4 / (float)Math.PI) * x - (4 / (float)(Math.PI * Math.PI)) * x * x;
        }

        /// <summary>
        /// Sine approximation using polynominals.
        /// Has a high precision.
        /// </summary>
        /// <param name="x">The value</param>
        /// <returns>Sine of x</returns>
        public static float HighSin(float x)
        {
            //always wrap input angle to -PI..PI
            if (x < -(float)Math.PI)
                x += (float)Math.PI * 2;
            else if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            //compute sine
            if (x < 0)
            {
                float sin = (4 / (float)Math.PI) * x + (4 / (float)(Math.PI * Math.PI)) * x * x;

                if (sin < 0)
                    return .225f * (sin * -sin - sin) + sin;
                
                return .225f * (sin * sin - sin) + sin;
            }
            else
            {
                float sin = (4 / (float)Math.PI) * x - (4 / (float)(Math.PI * Math.PI)) * x * x;

                if (sin < 0)
                    return .225f * (sin * -sin - sin) + sin;
                
                return .225f * (sin * sin - sin) + sin;
            }
        }

        /// <summary>
        /// Cosine approximation using polynominals.
        /// Has a low precision.
        /// </summary>
        /// <param name="x">The value</param>
        /// <returns>Cosine of x</returns>
        public static float LowCos(float x)
        {
            //always wrap input angle to -PI..PI
            if (x < -(float)Math.PI)
                x += (float)Math.PI * 2;
            else if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            //compute cosine: sin(x + PI/2) = cos(x)
            x += 1.57079632f;
            if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            if (x < 0)
                return (4 / (float)Math.PI) * x + (4 / (float)(Math.PI * Math.PI)) * x * x;
            
            return (4 / (float)Math.PI) * x - (4 / (float)(Math.PI * Math.PI)) * x * x;
        }

        /// <summary>
        /// Cosine approximation using polynominals.
        /// Has a high precision.
        /// </summary>
        /// <param name="x">The value</param>
        /// <returns>Cosine of x</returns>
        public static float HighCos(float x)
        {
            //always wrap input angle to -PI..PI
            if (x < -(float)Math.PI)
                x += (float)Math.PI * 2;
            else if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            //compute cosine: sin(x + PI/2) = cos(x)
            x += 1.57079632f;
            if (x > (float)Math.PI)
                x -= (float)Math.PI * 2;

            if (x < 0)
            {
                float cos = (4 / (float)Math.PI) * x + (4 / (float)(Math.PI * Math.PI)) * x * x;

                if (cos < 0)
                    return .225f * (cos * -cos - cos) + cos;
                
                return .225f * (cos * cos - cos) + cos;
            }
            else
            {
                float cos = (4 / (float)Math.PI) * x - (4 / (float)(Math.PI * Math.PI)) * x * x;

                if (cos < 0)
                    return .225f * (cos * -cos - cos) + cos;
                
                return .225f * (cos * cos - cos) + cos;
            }
        }

        /// <summary>
        /// Cosine approximation using Taylor series.
        /// </summary>
        /// <param name="x">The value</param>
        /// <returns>Sine of x</returns>
        public static float TaylorSin(float x)
        {
            return x - ((x * x * x) / 6) + ((x * x * x * x * x) / 120) - ((x * x * x * x * x * x * x) / 5040);
        }

        /// <summary>
        /// Takes the inverse square root of x using Newton-Raphson
        /// approximation with 1 pass after clever inital guess using
        /// bitshifting.
        /// </summary>
        /// <param name="x">The value.</param>
        /// <returns>The inverse square root of x</returns>
        public static float InvSqrt(float x)
        {
            Convert convert = new Convert();
            convert.x = x;
            float xhalf = 0.5f * x;
            convert.i = 0x5f3759df - (convert.i >> 1);
            x = convert.x;
            x = x * (1.5f - xhalf * x * x);
            return x;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Convert
        {
            [FieldOffset(0)]
            public float x;

            [FieldOffset(0)]
            public int i;
        }
    }
}