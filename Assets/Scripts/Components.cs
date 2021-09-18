using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace NerdHeadExtensions
{
    public static class Components
    {
        /// <summary>
        /// This function is not recommended!
        /// Recommended to store the TextMeshProUGUI in the script and change using TextMeshProUGUI.text = "";
        /// </summary>
        public static void ChangeText(this GameObject textObject, string text)
        {
            if (textObject.GetComponent<TextMeshProUGUI>() != null)
                textObject.GetComponent<TextMeshProUGUI>().text = text;
            else
                textObject.GetComponent<Text>().text = text;
        }
        /// <summary>
        /// This function is not recommended!
        /// Recommended to store the TextMeshProUGUI in the script and change using TextMeshProUGUI.text = "";
        /// </summary>
        public static void ChangeText(this Transform textObject, string text)
        {
            if (textObject.GetComponent<TextMeshProUGUI>() != null)
                textObject.GetComponent<TextMeshProUGUI>().text = text;
            else
                textObject.GetComponent<Text>().text = text;
        }
        /// <summary>
        /// This function is not recommended!
        /// Recommended to store the TextMeshProUGUI in the script and change using TextMeshProUGUI.text = "";
        /// </summary>
        public static void ChangeText(this Button textObject, string text)
        {
            if (textObject.GetComponentInChildren<TextMeshProUGUI>() != null)
                textObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
            else
                textObject.GetComponentInChildren<Text>().text = text;

        }
    }
}