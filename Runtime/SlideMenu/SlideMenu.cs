using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    public class SlideMenu : MonoBehaviour
    {
        public Transform self;
        public List<Transform> grid;
        public int current;

        public Vector2 show_pos;
        public Vector2 hide_pos;
        public Vector2 begin_pos;

        public float duration;

        public CurveType show;
        public CurveType hide;

        void Start()
        {
            Vector3[] ary = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(ary);
            float width = Mathf.Abs(ary[0].x - ary[2].x);
            show_pos = self.position + new Vector3(width, 0, 0);
            hide_pos = self.position - new Vector3(width, 0, 0);
            begin_pos = self.position;
        }

        [ContextMenu("RecordBegin")]
        public void RecordBegin()
        {
            begin_pos = grid[0].position;
        }


        [ContextMenu("RecordShow")]
        public void RecordShow()
        {
            show_pos = grid[0].position;
        }

        [ContextMenu("RecordHide")]
        public void RecordHide()
        {
            hide_pos = grid[0].position;
        }

        public void Reset()
        {
            current = 0;
            grid.ForEach(c => c.position = hide_pos);
            grid[current].transform.position = begin_pos;
        }

        public void Page1()
        {
            current = 1;
            grid.ForEach(c => c.position = hide_pos);
            grid[current].transform.position = begin_pos;
        }

        public void Page1Reverse()
        {
            grid.ForEach(c => c.position = hide_pos);
            StartCoroutine(Move_(grid[1], hide_pos, begin_pos, duration, CurveType.EASE_OUT_CUBIC));
            current = 1;
        }

        public void Next()
        {
            if (current >= grid.Count - 1)
            {
                return;
            }
            StartCoroutine(Move_(grid[current], begin_pos, hide_pos, duration, CurveType.EASE_OUT_CUBIC));
            StartCoroutine(Move_(grid[current + 1], show_pos, begin_pos, duration, CurveType.EASE_OUT_CUBIC));
            current++;
        }

        public void Back()
        {
            if (current <= 0)
            {
                return;
            }
            StartCoroutine(Move_(grid[current], begin_pos, show_pos, duration, CurveType.EASE_OUT_CUBIC));
            StartCoroutine(Move_(grid[current - 1], hide_pos, begin_pos, duration, CurveType.EASE_OUT_CUBIC));
            current--;
        }

        Coroutine C;

        IEnumerator Move_(Transform target, Vector2 from, Vector2 to, float duration, CurveType curve)
        {
            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                target.position = Vector3.Lerp(from, to, CurveManager.instance.Evaluate(curve, i / duration));
                Debug.Log(target.position);
                yield return null;
            }
            target.position = to;
        }

    }
}