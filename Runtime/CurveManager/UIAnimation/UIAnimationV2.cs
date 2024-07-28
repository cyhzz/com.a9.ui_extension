using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    public class UIAnimationV2 : MonoBehaviour
    {
        Vector3 StartScale
        {
            get
            {
                if (start_scale == Vector3.zero)
                {
                    start_scale = transform.localScale;
                }
                return start_scale;
            }
        }
        Vector3 start_scale;

        public void Wait(float duration, Action OnEnd) => StartCoroutine(Wait_(duration, OnEnd));
        public void CanvasAlpha(CurveType type, float from, float to, float duration, Action OnEnd = null) => StartCoroutine(CanvasAlpha_(type, from, to, duration, OnEnd));
        public void SpriteAlpha(CurveType type, float from, float to, float duration, Action OnEnd = null) => StartCoroutine(SpriteAlpha_(type, from, to, duration, OnEnd));
        public void Position(CurveType type, Vector2 from, Vector2 to, float duration, Action OnEnd = null) => StartCoroutine(Position_(type, from, to, duration, OnEnd));
        public void ScaleUp(CurveType type, float duration, Action OnEnd = null) => StartCoroutine(Scale_(type, Vector3.zero, StartScale, duration, OnEnd));
        public void ScaleDown(CurveType type, float duration, Action OnEnd = null) => StartCoroutine(Scale_(type, StartScale, Vector3.zero, duration, OnEnd));
        public void ScaleBounce(CurveType type, float duration, Action OnEnd = null) => StartCoroutine(ScaleZeroOne_(type, Vector3.zero, StartScale, duration, OnEnd));
        public void Scale(CurveType type, float duration, Vector2 mul_a, Vector2 mul_b, Action OnEnd = null)
        {
            StartCoroutine(Scale_(type, mul_a, mul_b, duration, OnEnd));
        }

        public void Scale(MonoBehaviour bh, CurveType type, float duration, Vector2 mul_a, Vector2 mul_b, Action OnEnd = null)
        {
            bh.StartCoroutine(Scale_(type, mul_a, mul_b, duration, OnEnd));
        }

        IEnumerator CanvasAlpha_(CurveType type, float from, float to, float duration, Action OnEnd = null)
        {
            float pg = 0;
            while (pg < 1)
            {
                float target = Mathf.LerpUnclamped(from, to, CurveManager.instance.Evaluate(type, pg));
                GetComponent<CanvasGroup>().alpha = target;
                pg += Time.unscaledDeltaTime / duration;
                yield return null;
            }
            GetComponent<CanvasGroup>().alpha = to;
            OnEnd?.Invoke();
        }

        IEnumerator SpriteAlpha_(CurveType type, float from, float to, float duration, Action OnEnd = null)
        {
            float pg = 0;
            Color start = GetComponent<SpriteRenderer>().color;
            while (pg < 1)
            {
                float target = Mathf.LerpUnclamped(from, to, CurveManager.instance.Evaluate(type, pg));
                GetComponent<SpriteRenderer>().color = new Color(start.r, start.g, start.b, target);
                pg += Time.unscaledDeltaTime / duration;
                yield return null;
            }
            GetComponent<SpriteRenderer>().color = new Color(start.r, start.g, start.b, to);
            OnEnd?.Invoke();
        }

        IEnumerator Scale_(CurveType type, Vector3 from, Vector3 to, float duration, Action OnEnd = null)
        {
            float pg = 0;
            while (pg < 1)
            {
                Vector3 target = Vector3.LerpUnclamped(from, to, CurveManager.instance.Evaluate(type, pg));

                transform.localScale = new Vector3(target.x, target.y, 1);
                pg += Time.unscaledDeltaTime / duration;
                yield return null;
            }
            transform.localScale = new Vector3(to.x, to.y, 1);
            OnEnd?.Invoke();
        }

        IEnumerator ScaleZeroOne_(CurveType type, Vector3 from, Vector3 to, float duration, Action OnEnd = null)
        {
            float pg = 0;
            while (pg < 1)
            {
                Vector3 target = Vector3.LerpUnclamped(from, to, CurveManager.instance.Evaluate(type, pg) + (1 - pg));

                transform.localScale = new Vector3(target.x, target.y, 1);
                pg += Time.unscaledDeltaTime / duration;
                yield return null;
            }
            OnEnd?.Invoke();
        }

        IEnumerator Position_(CurveType type, Vector3 from, Vector3 to, float duration, Action OnEnd = null)
        {
            float pg = 0;
            while (pg < 1)
            {
                Vector3 target = Vector3.LerpUnclamped(from, to, CurveManager.instance.Evaluate(type, pg));

                transform.position = new Vector3(target.x, target.y, 1);
                pg += Time.unscaledDeltaTime / duration;
                yield return null;
            }
            transform.position = new Vector3(to.x, to.y, 1);
            OnEnd?.Invoke();
        }

        IEnumerator Wait_(float time, Action OnEnd)
        {
            yield return new WaitForSecondsRealtime(time);
            OnEnd?.Invoke();
        }
    }
}