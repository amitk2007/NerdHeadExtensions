using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NerdHeadExtensions
{
    public static class Program
    {
        #region string
        public static string Remove(this string str, string remove)
        {
            return str.Replace(remove, "").Trim();
        }
        public static string ToTimeFormat(this float number)
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(number);
            return time.ToString("hh':'mm':'ss");
        }
        public static string Connect(string connector, params object[] strings)
        {
            string final = strings[0].ToString();

            for (int i = 1; i < strings.Length; i++)
            {
                final += connector + strings[i].ToString();
            }

            return final;
        }
        public static string[] Split(this string str, string seperator)
        {
            return str.Split(new string[] { seperator }, System.StringSplitOptions.None);
        }
        public static string ReplaceRichText(this string text, string replace, string withStart, string withEnd)
        {
            string final = "";
            text = "☺" + text + "☺";
            /// Make extention for split on string (with another string)
            string[] bolds = text.Split(replace);

            for (int i = 0; i < bolds.Length - 1; i++)
            {
                final += bolds[i];
                final = i % 2 == 0 ? final + withStart : final + withEnd;
            }
            final += bolds[bolds.Length - 1];
            final = final.Remove("☺");
            return final;
        }
        #endregion

        #region numbers
        public static void AddInLoop(this ref int number, int add, int range)
        {
            number += add;
            number = number % range;
        }
        public static void AddInLoop(this ref int number, int range)
        {
            number += 1;
            number = number % range;
        }

        public static float ClampAngle(this float _angle, float _min, float _max)
        {
            _angle = Mathf.Abs(_angle % 360);
            if (_angle < -360f) { _angle += 360f; }
            if (_angle > 360f) { _angle -= 360f; }
            return Mathf.Clamp(_angle, _min, _max);
        }
        #endregion

        public static void LookAt2D(this Transform transform, Transform traget)
        {
            transform.right = traget.position - transform.position;
            //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //diff.Normalize();
            //
            //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        public static void LookAt2D(this Transform transform, Vector3 tragetPos)
        {
            transform.right = tragetPos - transform.position;
        }

        /// <summary>
        /// Gives you the position og the mouse in game coordinates (z = 0)
        /// Work only then the camera projection is set to orthographic (Otherwise it will not give a correct value)
        /// </summary>
        /// <param name="cam"> The main camera used</param>
        /// <returns></returns>
        public static Vector3 GetMouseScreenPos(this Camera cam)
        {
            if (cam.orthographic)
            {
                Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                return pos;
            }
            else
            {
                Debug.LogError("Please set the camera projection to orthographic to get the mouse position");
            }
            return Vector3.zero;
        }


        #region Extras - To fix

        public static Object Instantiate(Object original, Vector3 position)
        {
            return Object.Instantiate(original, position, Quaternion.identity);
        }
        #endregion
    }
}
