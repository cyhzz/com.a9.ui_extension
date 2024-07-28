using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    public class AnimationCurveHolder : MonoBehaviour, IEvaluable
    {
        public CurveType curve_type;
        public AnimationCurve curve;

        public float Evaluate(float pg)
        {
            return curve.Evaluate(pg);
        }

        public CurveType Type()
        {
            return curve_type;
        }
    }
}