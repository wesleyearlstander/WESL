using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static WESL.Helper;

namespace WESL
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Resets transform to identity
        /// </summary>
        /// <param name="t">Unity transform</param>
        public static void ResetTransform(this Transform t)
        {
            t.position = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

        /// <summary>
        /// Move's transform from current position to location in world space
        /// </summary>
        /// <param name="t">Unity transform</param>
        /// <param name="location">Location in world space to move to</param>
        /// <param name="time">Time needed to move to position</param>
        /// <returns></returns>
        public static IEnumerator MoveTransform (this Transform t, Vector3 location, float time)
        {
            Vector3 start = t.position;
            Timer timer = new Timer(time);
            while (!timer.IsDone())
            {
                t.position = Vector3.Lerp(start, location, timer.GetPercentage());
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }

        //colour extensions
        /// <summary>
        /// Change the alpha value of the Color by tint.
        /// </summary>
        /// <param name="color">Unity color</param>
        /// <param name="tint">change alpha by -1f to 1f</param>
        public static void tintAlpha(this Color color, float tint)
        {
            color = new Color(color.r, color.g, color.b, Mathf.Clamp(color.a + tint, 0, 1));
        }

        /// <summary>
        /// Returns this Color with the alpha tinted by tint.
        /// </summary>
        /// <param name="color">Unity color</param>
        /// <param name="tint">change alpha by -1f to 1f</param>
        /// <returns>this Color tinted by tint</returns>
        public static Color withTintAlpha (this Color color, float tint)
        {
            return new Color(color.r, color.g, color.b, Mathf.Clamp(color.a + tint, 0, 1));
        }

        /// <summary>
        /// Returns this Color with the alpha set to alpha.
        /// </summary>
        /// <param name="color">Unity color</param>
        /// <param name="alpha">set alpha from 0 to 1f</param>
        /// <returns>this Color with alpha set to alpha</returns>
        public static Color withAlpha (this Color color, float alpha)
        {
            Mathf.Clamp(alpha, 0, 1);
            return new Color(color.r, color.g, color.b, alpha);
        }

        /// <summary>
        /// Returns this Color with alpha interpolated between start and end at percentage.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="start">start alpha value from 0 to 1</param>
        /// <param name="end">end alpha value from 0 to 1</param>
        /// <param name="percentage">evaluation percentage from 0 to 1</param>
        /// <returns>this Color with alpha interpolated between start and end at percentage</returns>
        public static Color LerpAlpha (this Color color, float start, float end, float percentage)
        {
            Mathf.Clamp(start, 0, 1);
            Mathf.Clamp(end, 0, 1);
            Mathf.Clamp(percentage, 0, 1);
            return new Color(color.r, color.g, color.b, Mathf.Lerp(start, end, percentage));
        }

        /// <summary>
        /// Returns this Color with alpha interpolated between start and end  at the timer's percentage.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="start">start alpha value from 0 to 1</param>
        /// <param name="end">end alpha value from 0 to 1</param>
        /// <param name="percentage">timer to evaluate Lerp against</param>
        /// <returns>this Color with alpha interpolated between start and end at the timer's percentage</returns>
        public static Color LerpAlpha(this Color color, float start, float end, Timer timer)
        {
            Mathf.Clamp(start, 0, 1);
            Mathf.Clamp(end, 0, 1);  
            return new Color(color.r, color.g, color.b, Mathf.Lerp(start, end, timer.GetPercentage()));
        }
    }
}
