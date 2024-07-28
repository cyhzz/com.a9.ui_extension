using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.A9.Singleton;
using UnityEngine;

namespace Com.A9.UIExt
{
    public class TextManager : Singleton<TextManager>
    {
        public Transform grid;
        public string prefab;

        public void Present(Transform anchor, GameObject prefab, string txt, float in_duration, float symbol_gap, float duration, float hide_duration)
        {
            var al = grid.GetComponentsInChildren<TextPresenter>().ToList();
            var fd = al.Find(x => x.target == anchor);

            if (fd != null)
            {
                fd.Present(anchor, txt, in_duration, symbol_gap, duration, hide_duration);
                return;
            }

            var g = Instantiate(prefab, grid);
            g.GetComponent<TextPresenter>().
            Present(anchor, txt, in_duration, symbol_gap, duration, hide_duration);
        }
    }
}