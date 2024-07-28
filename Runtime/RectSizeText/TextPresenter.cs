using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Com.A9.UIExt
{
    public class TextPresenter : MonoBehaviour
    {
        public Text text;
        public CanvasGroup gp;
        public Transform target;

        public List<RectTransform> resizes;

        public List<string> queue = new List<string>();

        void Update()
        {
            ValidatePos();
        }

        void ValidatePos()
        {
            if (target != null)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(target.position);
                transform.position = pos;
            }
        }

        public void Present(Transform tg, string txt, float in_duration, float symbol_gap, float duration, float hide_duration)
        {
            queue.Add(txt);
            target = tg;

            ValidatePos();

            if (cr != null)
                StopCoroutine(cr);
            cr = StartCoroutine(Text_(in_duration, symbol_gap, duration, hide_duration));
        }

        Coroutine cr;
        IEnumerator Text_(float in_duration, float symbol_gap, float duration, float hide_duration)
        {
            var txt = queue[0];
            for (float i = 0; i < in_duration; i += Time.deltaTime)
            {
                gp.alpha = i / in_duration;
                yield return null;
            }
            gp.alpha = 1;

            for (int i = 0; i < txt.Length; i++)
            {
                text.text = txt.Substring(0, i + 1);
                Resize();
                yield return new WaitForSeconds(symbol_gap);
            }

            yield return new WaitForSeconds(duration);

            for (float i = 0; i < hide_duration; i += Time.deltaTime)
            {
                gp.alpha = 1 - i / hide_duration;
                yield return null;
            }
            gp.alpha = 0;
            text.text = "";
            Resize();

            queue.RemoveAt(0);
            if (queue.Count > 0)
            {
                cr = StartCoroutine(Text_(in_duration, symbol_gap, duration, hide_duration));
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Resize()
        {
            for (int i = 0; i < resizes.Count; i++)
            {
                var fitter = resizes[i].GetComponent<ContentSizeFitter>();
                var layout = resizes[i].GetComponent<LayoutGroup>();

                if (fitter)
                {
                    fitter.enabled = false;
                    fitter.enabled = true;
                    fitter.SetLayoutHorizontal();
                    fitter.SetLayoutVertical();
                }
                if (layout)
                {
                    layout.enabled = false;
                    layout.enabled = true;

                    layout.CalculateLayoutInputHorizontal();
                    layout.CalculateLayoutInputVertical();
                    layout.SetLayoutHorizontal();
                    layout.SetLayoutVertical();
                    LayoutRebuilder.ForceRebuildLayoutImmediate(layout.GetComponent<RectTransform>());
                }
            }
        }
    }
}