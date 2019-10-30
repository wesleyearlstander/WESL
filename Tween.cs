using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WESL
{
    public class Tween
    {
        public class Quadratic
        {
            public static float easeIn (float p)
            {
                return (float)Math.Pow(p, 2);
            }

            public static float easeIn (Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut (float p)
            {
                return p * (2f - p);
            }

            public static float easeOut (Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return 0.5f * (float)Math.Pow(p, 2);
                return -0.5f * ((p -= 1f) * (p - 2f) - 1f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Cubic
        {
            public static float easeIn (float p)
            {
                return (float)Math.Pow(p, 3);
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut (float p)
            {
                return 1f + ((p -= 1f) * (float)Math.Pow(p, 2));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut (float p)
            {
                if ((p *= 2f) < 1f) return 0.5f * (float)Math.Pow(p, 3);
                return 0.5f * ((p -= 2f) * (float)Math.Pow(p, 2) + 2f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Quartic
        {
            public static float easeIn (float p)
            {
                return (float)Math.Pow(p, 4);
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return 1f - ((p -= 1f) * (float)Math.Pow(p, 3));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return 0.5f * (float)Math.Pow(p, 4);
                return -0.5f * ((p -= 2f) * (float)Math.Pow(p, 3) - 2f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Quintic
        {
            public static float easeIn (float p)
            {
                return (float)Math.Pow(p, 5);
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return 1f + ((p -= 1f) * (float)Math.Pow(p, 4));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return 0.5f * (float)Math.Pow(p, 5);
                return 0.5f * ((p -= 2f) * (float)Math.Pow(p,4) + 2f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Sinusoidal
        {
            public static float easeIn (float p)
            {
                return (float)(1f - Math.Cos(p * Math.PI / 2f));
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return (float)(Math.Sin(p * Math.PI / 2f));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                return (float)(0.5f * (1f - Math.Cos(Math.PI * p)));
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Exponential
        {
            public static float easeIn (float p)
            {
                return (float)(p == 0f ? 0f : Math.Pow(1024f, p - 1f));
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return (float)(p == 1f ? 1f : 1f - Math.Pow(2f, -10f * p));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if (p == 0f) return 0f;
                if (p == 1f) return 1f;
                if ((p *= 2f) < 1f) return (float)(0.5f * Math.Pow(1024f, p - 1f));
                return (float)(0.5f * (-Math.Pow(2f, -10f * (p - 1f)) + 2f));
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Circular
        {
            public static float easeIn (float p)
            {
                return (float)(1f - Math.Sqrt(1f - p * p));
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return (float)(Math.Sqrt(1f - ((p -= 1f) * p)));
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return (float)(-0.5f * (Math.Sqrt(1f - Math.Pow(p, 2)) - 1));
                return (float)(0.5f * (Math.Sqrt(1f - (p -= 2f) * p) + 1f));
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Elastic
        {
            public static float easeIn(float p)
            {
                if (p == 0) return 0;
                if (p == 1) return 1;
                return (float)(-Math.Pow(2f, 10f * (p -= 1f)) * Math.Sin((p - 0.1f) * (2f * Math.PI) / 0.4f));
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                if (p == 0) return 0;
                if (p == 1) return 1;
                return (float)(Math.Pow(2f, -10f * p) * Math.Sin((p - 0.1f) * (2f * Math.PI) / 0.4f) + 1f);
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return (float)(-0.5f * Math.Pow(2f, 10f * (p -= 1f)) * Math.Sin((p - 0.1f) * (2f * Math.PI) / 0.4f));
                return (float)(Math.Pow(2f, -10f * (p -= 1f)) * Math.Sin((p - 0.1f) * (2f * Math.PI) / 0.4f) * 0.5f + 1f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Back
        {
            static float c = 1.7f;
            static float c2 = 2.6f;

            public static float easeIn(float p)
            {
                return p * p * ((c + 1f) * p - c);
            }

            public static float easeIn(Timer t)
            {
                float p = t.GetPercentage();
                return easeIn(p);
            }

            public static float easeOut(float p)
            {
                return (p -= 1f) * p * ((c + 1f) * p + c) + 1f;
            }

            public static float easeOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeOut(p);
            }

            public static float easeInOut(float p)
            {
                if ((p *= 2f) < 1f) return 0.5f * ((float)Math.Pow(p, 2) * ((c2 + 1f) * p - c2));
                return 0.5f * ((p -= 2f) * p * ((c2 + 1f) * p + c2) + 2f);
            }

            public static float easeInOut(Timer t)
            {
                float p = t.GetPercentage();
                return easeInOut(p);
            }
        }

        public class Bounce
        {
            public static float easeIn(float p, int bounces = 6)
            {
                bounces = Math.Min(bounces, 6);
                bounces = Math.Max(bounces, 2);
                return (float)(Math.Abs(20 * p * Math.Cos(bounces*Math.PI * p)/ Math.Exp(3)));
            }

            public static float easeIn(Timer t, int bounces = 6)
            {
                float p = t.GetPercentage();
                return easeIn(p, bounces);
            }

            public static float easeOut (float p, int bounces = 6)
            {
                bounces = Math.Min(bounces, 6);
                bounces = Math.Max(bounces, 2);
                return (float)(1-easeIn(p - 1, bounces));
            }

            public static float easeOut(Timer t, int bounces = 6)
            {
                float p = t.GetPercentage();
                return easeOut(p, bounces);
            }

            public static float easeInOut (float p, int bounces = 6)
            {
                bounces = Math.Min(bounces, 6);
                bounces = Math.Max(bounces, 2);
                return (p <= 0.5) ? easeIn(p, bounces) : easeOut(p, bounces);
            }

            public static float easeInOut(Timer t, int bounces = 6)
            {
                float p = t.GetPercentage();
                return easeInOut(p, bounces);
            }
        }
    }
}
