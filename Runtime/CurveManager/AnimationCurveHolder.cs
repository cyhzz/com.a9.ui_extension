using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    [System.Serializable]
    public class AnimationCurveHolder
    {
        public string id;
        public AnimationCurve curve;

        public float Evaluate(float pg)
        {
            return curve.Evaluate(pg);
        }
    }
}