using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Com.A9.UIExt
{
    public class UIPositionInstance : MonoBehaviour
    {
        public Vector2 offset;
        public UIAnimationV2 anim;
        public CurveType type;
        public float duration;
        public UnityEvent OnEnd;
        public void Play()
        {
            anim.Position(type, transform.position, transform.position + new Vector3(offset.x, offset.y, 0), duration, () => { OnEnd?.Invoke(); });
        }
    }
}