using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NerdHeadExtensions.Vectors
{
    public static class Vectors
    {
        public static void RandomVector3(this ref Vector3 myVector, Vector3 min, Vector3 max)
        {
            myVector = new Vector3(Mathf.Round(Random.Range(min.x, max.x)), Mathf.Round(Random.Range(min.y, max.y)), Mathf.Round(Random.Range(min.z, max.z)));
        }

        public static Vector3 Round(this Vector3 vector3)
        {
            return new Vector3(Mathf.Round(vector3.x), Mathf.Round(vector3.y), Mathf.Round(vector3.z));
        }
    }
}
