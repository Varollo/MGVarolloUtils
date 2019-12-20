namespace MGVarolloUtils.Math
{
    /// <summary>
    /// Used to define the angle notation, radians or degrees.
    /// </summary>
    public enum AngleType { radians, degrees };

    /// <summary>
    /// Utility class for extra Math functions
    /// </summary>
    public static class MathEx
    {
        /// <summary>
        /// A float conversion of Math.PI
        /// </summary>
        public static readonly float PI = (float)System.Math.PI;

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="deg">Angle in degrees</param>
        /// <returns>Returns the angle in radians</returns>
        public static float toRad(float deg) => PI * deg / 180f;
        public static float toRad(ref float deg) => PI * deg / 180f;

        /// <summary>
        /// Converts radians to degrees
        /// </summary>
        /// <param name="rad">Angle in radians</param>
        /// <returns>Returns the angle in degrees</returns>
        public static float toDeg(float rad) => rad * (PI / 180f);
        public static float toDeg(ref float rad) => rad * (PI / 180f);

        /// <summary>
        /// Map a value to a diferent range
        /// </summary>
        /// <param name="value">Value to be mapped</param>
        /// <param name="valueMin">Min possible value</param>
        /// <param name="valueMax">Max possible value</param>
        /// <param name="newMin">New min possible value</param>
        /// <param name="newMax">New max possible value</param>
        /// <returns>Returns the value remapped</returns>
        public static float Map(float value, float valueMin, float valueMax, float newMin, float newMax)
        {
            return (value - valueMin) / (valueMax - valueMin) * (newMax - newMin) + newMin;
        }
        public static float Map(ref float value, float valueMin, float valueMax, float newMin, float newMax)
        {
            value = (value - valueMin) / (valueMax - valueMin) * (newMax - newMin) + newMin;
            return value;
        }

        /// <summary>
        /// Clamps a value between a min and a max
        /// </summary>
        /// <param name="value">The value to be clamped</param>
        /// <param name="min">The min value possible</param>
        /// <param name="max">The max value possible</param>
        /// <returns>Returns the value clamped</returns>
        public static float Clamp(float value, float min = 0, float max = 1)
        {
            if (value < min) value = min;
            else if (value > max) value = max;
            return value;
        }
        public static float Clamp(ref float value, float min = 0, float max = 1)
        {
            if (value < min) value = min;
            else if (value > max) value = max;
            return value;
        }

        /// <summary>
        /// Linear interpolates two numbers with an amount
        /// </summary>
        /// <param name="start">The start value</param>
        /// <param name="end">The end value</param>
        /// <param name="amt">The amount</param>
        /// <param name="clampAmt">Clamp the amt between 0 and 1</param>
        /// <returns>Returns the value lerped</returns>
        public static float Lerp(float start, float end, float amt, bool clampAmt = true)
        {
            if (clampAmt) Clamp(ref amt);
            return (1 - amt) * start + amt * end;
        }

        /// <summary>
        /// Gets the sin of a angle
        /// </summary>
        /// <param name="theta">The angle</param>
        /// <param name="angleType">If it's degrees or radians</param>
        /// <returns>Returns the sin</returns>
        public static float Sin(float theta, AngleType angleType = AngleType.radians)
        {
            if (angleType == AngleType.radians) return (float)System.Math.Sin(theta);
            return (float)System.Math.Sin(toRad(theta));
        }

        /// <summary>
        /// Gets the cos of a angle
        /// </summary>
        /// <param name="theta">The angle</param>
        /// <param name="angleType">If it's degrees or radians</param>
        /// <returns>Returns the cos</returns>
        public static float Cos(float theta, AngleType angleType = AngleType.radians)
        {
            if (angleType == AngleType.radians) return (float)System.Math.Cos(theta);
            return (float)System.Math.Cos(toRad(theta));
        }

        /// <summary>
        /// The power of a number x
        /// </summary>
        /// <param name="x">The number</param>
        /// <param name="power">The power</param>
        /// <returns>Returns the power of x</returns>
        public static float Pow(float x, float power)
        {
            return (float)System.Math.Pow(x, power);
        }
        public static float Pow(ref float x, float power)
        {
            x = (float)System.Math.Pow(x, power);
            return x;
        }

        /// <summary>
        /// The square root of a number x
        /// </summary>
        /// <param name="x">Number</param>
        /// <returns>Returns the square root of x</returns>
        public static float Sqrt(float x)
        {
            return (float)System.Math.Sqrt(x);
        }
        public static float Sqrt(ref float x)
        {
            x =  (float)System.Math.Sqrt(x);
            return x;
        }

        /// <summary>
        /// Converts a 2D index to a 1D index
        /// </summary>
        /// <param name="i">The current row</param>
        /// <param name="j">The current colunm</param>
        /// <param name="rows">The number of rows</param>
        /// <returns>Returns the 1D index</returns>
        public static int To1DIndex(int i, int j, int rows)
        {
            return i + j * rows;
        }

        /// <summary>
        /// Converts a 1D index to a 2D index
        /// </summary>
        /// <param name="i">The 1D index</param>
        /// <param name="rows">The number of rows</param>
        /// <param name="columns">The number of colunms</param>
        /// <returns>Returns the 2D index</returns>
        public static int[] To2DIndex(int i, int rows, int columns)
        {
            int[] array = new int[2];

            array[0] = i % columns;
            array[1] = i / rows;

            return array;
        }

        /// <summary>
        /// Converts a two dimensional array to a one dimensional array.
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="array">The array</param>
        /// <returns>Returns the one dimensional array</returns>
        public static T[] To1DArray<T>(T[,] array)
        {
            T[] newArray = new T[array.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                int[] index = To2DIndex(i, array.GetLength(0), array.GetLength(1));
                newArray[i] = array[index[0], index[1]];
            }

            return newArray;
        }

        /// <summary>
        /// Converts a one dimensional array to a two dimensional array.
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="array">The array</param>
        /// /// <param name="rows">The number of rows</param>
        /// /// /// <param name="columns">The number of columns</param>
        /// <returns>Returns the two dimensional array</returns>
        public static T[,] To2DArray<T>(T[] array, int rows, int columns)
        {
            T[,] newArray = new T[rows,columns];

            for(int i = 0; i < rows; i++)
                for(int j = 0; j < columns; j++)
                {
                    newArray[i, j] = array[To1DIndex(i, j, rows)];
                }

            return newArray;
        }
    }
}
