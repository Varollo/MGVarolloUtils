namespace MGVarolloUtils.Math
{
    public static class MathTweener
    {
        #region Simple;
        public static float SimpleEase(float start = 0, float finish = 1, float ease = 0.5f)
        {
            return start + (finish - start) * ease;
        }

        public static float Linear(float k)
        {
            return k;
        }
        #endregion

        #region Quadratic
        public static float QuadraticIn(float k)
        {
            return k * k;
        }

        public static float QuadraticOut(float k)
        {
            return k * (2f - k);
        }

        public static float QuadraticInOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k;
            return -0.5f * ((k -= 1f) * (k - 2f) - 1f);
        }
        #endregion

        #region Cubic
        public static float CubicIn(float k)
        {
            return k * k * k;
        }

        public static float CubicOut(float k)
        {
            return 1f + ((k -= 1f) * k * k);
        }

        public static float CubicInOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k;
            return 0.5f * ((k -= 2f) * k * k + 2f);
        }
        #endregion

        #region Quartic
        public static float QuarticIn(float k)
        {
            return k * k * k * k;
        }

        public static float QuarticOut(float k)
        {
            return 1f - ((k -= 1f) * k * k * k);
        }

        public static float QuarticInOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k * k;
            return -0.5f * ((k -= 2f) * k * k * k - 2f);
        }
        #endregion

        #region Quintic
        public static float QuinticIn(float k)
        {
            return k * k * k * k * k;
        }

        public static float QuinticOut(float k)
        {
            return 1f + ((k -= 1f) * k * k * k * k);
        }

        public static float QuinticInOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k * k * k;
            return 0.5f * ((k -= 2f) * k * k * k * k + 2f);
        }
        #endregion

        #region Sinusoidal
        public static float SinusoidalIn(float k)
        {
            return 1f - MathEx.Cos(k * MathEx.PI / 2f);
        }

        public static float SinusoidalOut(float k)
        {
            return MathEx.Sin(k * MathEx.PI / 2f);
        }

        public static float SinusoidalInOut(float k)
        {
            return 0.5f * (1f - MathEx.Cos(MathEx.PI * k));
        }
        #endregion

        #region Exponential
        public static float ExponentialIn(float k)
        {
            return k == 0f ? 0f : MathEx.Pow(1024f, k - 1f);
        }

        public static float ExponentialOut(float k)
        {
            return k == 1f ? 1f : 1f - MathEx.Pow(2f, -10f * k);
        }

        public static float ExponentialInOut(float k)
        {
            if (k == 0f) return 0f;
            if (k == 1f) return 1f;
            if ((k *= 2f) < 1f) return 0.5f * MathEx.Pow(1024f, k - 1f);
            return 0.5f * (-MathEx.Pow(2f, -10f * (k - 1f)) + 2f);
        }
        #endregion

        #region Circular
        public static float CircularIn(float k)
        {
            return 1f - MathEx.Sqrt(1f - k * k);
        }

        public static float CircularOut(float k)
        {
            return MathEx.Sqrt(1f - ((k -= 1f) * k));
        }

        public static float CircularInOut(float k)
        {
            if ((k *= 2f) < 1f) return -0.5f * (MathEx.Sqrt(1f - k * k) - 1);
            return 0.5f * (MathEx.Sqrt(1f - (k -= 2f) * k) + 1f);
        }
        #endregion

        #region Elastic
        public static float ElasticIn(float k)
        {
            if (k == 0) return 0;
            if (k == 1) return 1;
            return -MathEx.Pow(2f, 10f * (k -= 1f)) * MathEx.Sin((k - 0.1f) * (2f * MathEx.PI) / 0.4f);
        }

        public static float ElasticOut(float k)
        {
            if (k == 0) return 0;
            if (k == 1) return 1;
            return MathEx.Pow(2f, -10f * k) * MathEx.Sin((k - 0.1f) * (2f * MathEx.PI) / 0.4f) + 1f;
        }

        public static float ElasticInOut(float k)
        {
            if ((k *= 2f) < 1f) return -0.5f * MathEx.Pow(2f, 10f * (k -= 1f)) * MathEx.Sin((k - 0.1f) * (2f * MathEx.PI) / 0.4f);
            return MathEx.Pow(2f, -10f * (k -= 1f)) * MathEx.Sin((k - 0.1f) * (2f * MathEx.PI) / 0.4f) * 0.5f + 1f;
        }
        #endregion

        #region Back
        private static readonly float s = 1.70158f;
        private static readonly float s2 = 2.5949095f;

        public static float BackIn(float k)
        {
            return k * k * ((s + 1f) * k - s);
        }

        public static float BackOut(float k)
        {
            return (k -= 1f) * k * ((s + 1f) * k + s) + 1f;
        }

        public static float BackInOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * (k * k * ((s2 + 1f) * k - s2));
            return 0.5f * ((k -= 2f) * k * ((s2 + 1f) * k + s2) + 2f);
        }
        #endregion

        #region Bounce
        public static float BounceIn(float k)
        {
            return 1f - BounceOut(1f - k);
        }

        public static float BounceOut(float k)
        {
            if (k < (1f / 2.75f))
            {
                return 7.5625f * k * k;
            }
            else if (k < (2f / 2.75f))
            {
                return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
            }
            else if (k < (2.5f / 2.75f))
            {
                return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
            }
            else
            {
                return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
            }
        }

        public static float BounceInOut(float k)
        {
            if (k < 0.5f) return BounceIn(k * 2f) * 0.5f;
            return BounceOut(k * 2f - 1f) * 0.5f + 0.5f;
        }
        #endregion
    }
}
