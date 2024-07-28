using System.Collections;
using System.Collections.Generic;
using Com.A9.Singleton;
using UnityEngine;
using UnityEngine.UI;
namespace Com.A9.UIExt
{
    public class HoverBanner : MonoBehaviour
    {
        public GameObject tip;
        public Text txt;

        public void Show(string text)
        {
            text = text.Replace("<b>", "\n");
            tip.SetActive(true);
            txt.text = text;
        }

        public void Hide()
        {
            tip.SetActive(false);
        }
    }

}
