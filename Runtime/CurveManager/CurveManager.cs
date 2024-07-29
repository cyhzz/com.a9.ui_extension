using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Com.A9.Singleton;
using UnityEngine;
namespace Com.A9.UIExt
{
    public interface IEvaluable
    {
        public CurveType Type();
        public float Evaluate(float pg);
    }

    public enum CurveType
    {
        LINEAR,
        EASE_IN_SINE,
        EASE_IN_QUAD,
        EASE_IN_CUBIC,
        EASE_IN_QUART,
        EASE_IN_QUINT,
        EASE_IN_EXPO,
        EASE_IN_CIRC,
        EASE_IN_BACK,
        EASE_IN_ELASTIC,
        EASE_IN_BOUNCE,

        EASE_OUT_SINE,
        EASE_OUT_QUAD,
        EASE_OUT_CUBIC,
        EASE_OUT_QUART,
        EASE_OUT_QUINT,
        EASE_OUT_EXPO,
        EASE_OUT_CIRC,
        EASE_OUT_BACK,
        EASE_OUT_ELASTIC,
        EASE_OUT_BOUNCE,

        EASE_IN_OUT_SINE,
        EASE_IN_OUT_QUAD,
        EASE_IN_OUT_CUBIC,
        EASE_IN_OUT_QUART,
        EASE_IN_OUT_QUINT,
        EASE_IN_OUT_EXPO,
        EASE_IN_OUT_CIRC,
        EASE_IN_OUT_BACK,
        EASE_IN_OUT_ELASTIC,
        EASE_IN_OUT_BOUNCE,
    }

    public class CurveManager : Singleton<CurveManager>
    {
        public List<AnimationCurveHolder> anim_curve;
        public AnimationCurve GetAnimCurve(string id)
        {
            return anim_curve.Find(c => c.id == id).curve;
        }

        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;
        const float c3 = c1 + 1;
        const float c4 = (2 * Mathf.PI / 3);
        const float c5 = (2 * Mathf.PI) / 4.5f;
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        protected override void Awake()
        {
            base.Awake();
        }

        public float Evaluate(string id, float fg)
        {
            return anim_curve.Find(c => c.id == id).Evaluate(fg);
        }

        public float Evaluate(CurveType type, float fg)
        {
            if (type == CurveType.LINEAR) return fg;
            else if (type == CurveType.EASE_IN_SINE) return EaseInSine(fg);
            else if (type == CurveType.EASE_IN_QUAD) return EaseInQuad(fg);
            else if (type == CurveType.EASE_IN_CUBIC) return EaseInCubic(fg);
            else if (type == CurveType.EASE_IN_QUART) return EaseInQuart(fg);
            else if (type == CurveType.EASE_IN_QUINT) return EaseInQuint(fg);
            else if (type == CurveType.EASE_IN_EXPO) return EaseInExpo(fg);
            else if (type == CurveType.EASE_IN_CIRC) return EaseInCirc(fg);
            else if (type == CurveType.EASE_IN_BACK) return EaseInBack(fg);
            else if (type == CurveType.EASE_IN_ELASTIC) return EaseInElastic(fg);
            else if (type == CurveType.EASE_IN_BOUNCE) return EaseInBounce(fg);

            else if (type == CurveType.EASE_OUT_SINE) return EaseOutSine(fg);
            else if (type == CurveType.EASE_OUT_QUAD) return EaseOutQuad(fg);
            else if (type == CurveType.EASE_OUT_CUBIC) return EaseOutCubic(fg);
            else if (type == CurveType.EASE_OUT_QUART) return EaseOutQuart(fg);
            else if (type == CurveType.EASE_OUT_QUINT) return EaseOutQuint(fg);
            else if (type == CurveType.EASE_OUT_EXPO) return EaseOutExpo(fg);
            else if (type == CurveType.EASE_OUT_CIRC) return EaseOutCirc(fg);
            else if (type == CurveType.EASE_OUT_BACK) return EaseOutBack(fg);
            else if (type == CurveType.EASE_OUT_ELASTIC) return EaseOutElastic(fg);
            else if (type == CurveType.EASE_OUT_BOUNCE) return EaseOutBounce(fg);

            else if (type == CurveType.EASE_IN_OUT_SINE) return EaseInOutSine(fg);
            else if (type == CurveType.EASE_IN_OUT_QUAD) return EaseInOutQuad(fg);
            else if (type == CurveType.EASE_IN_OUT_CUBIC) return EaseInOutCubic(fg);
            else if (type == CurveType.EASE_IN_OUT_QUART) return EaseInOutQuart(fg);
            else if (type == CurveType.EASE_IN_OUT_QUINT) return EaseInOutQuint(fg);
            else if (type == CurveType.EASE_IN_OUT_EXPO) return EaseInOutExpo(fg);
            else if (type == CurveType.EASE_IN_OUT_CIRC) return EaseInOutCirc(fg);
            else if (type == CurveType.EASE_IN_OUT_BACK) return EaseInOutBack(fg);
            else if (type == CurveType.EASE_IN_OUT_ELASTIC) return EaseInOutElastic(fg);
            else if (type == CurveType.EASE_IN_OUT_BOUNCE) return EaseInOutBounce(fg);

            return 0;
        }

        float EaseInSine(float fg) => 1 - Mathf.Cos((fg * Mathf.PI) / 2);
        float EaseInQuad(float fg) => fg * fg;
        float EaseInCubic(float fg) => fg * fg * fg;
        float EaseInQuart(float fg) => fg * fg * fg * fg;
        float EaseInQuint(float fg) => fg * fg * fg * fg * fg;
        float EaseInExpo(float fg) => fg == 0 ? 0 : Mathf.Pow(2, 10 * fg - 10);
        float EaseInCirc(float fg) => 1 - Mathf.Sqrt(1 - Mathf.Pow(fg, 2));
        float EaseInBack(float fg) => c3 * fg * fg * fg - c1 * fg * fg;
        float EaseInElastic(float fg) => fg == 0 ? 0 : fg == 1 ? 1 : -Mathf.Pow(2, 10 * fg - 10) * Mathf.Sin((fg * 10 - 10.75f) * c4);
        float EaseInBounce(float fg) => 1 - EaseOutBounce(1 - fg);

        float EaseOutSine(float fg) => Mathf.Sin((fg * Mathf.PI) / 2);
        float EaseOutQuad(float fg) => 1 - (1 - fg) * (1 - fg);
        float EaseOutCubic(float fg) => 1 - Mathf.Pow(1 - fg, 3);
        float EaseOutQuart(float fg) => 1 - Mathf.Pow(1 - fg, 4);
        float EaseOutQuint(float fg) => 1 - Mathf.Pow(1 - fg, 5);
        float EaseOutExpo(float fg) => fg == 1 ? 1 : 1 - Mathf.Pow(2, -10 * fg);
        float EaseOutCirc(float fg) => Mathf.Sqrt(1 - Mathf.Pow(fg - 1, 2));
        float EaseOutBack(float fg) => 1 + c3 * Mathf.Pow(fg - 1, 3) + c1 * Mathf.Pow(fg - 1, 2);
        float EaseOutElastic(float fg) => fg == 0 ? 0 : fg == 1 ? 1 : Mathf.Pow(2, -10 * fg) * Mathf.Sin((fg * 10 - 0.75f) * c4) + 1;
        float EaseOutBounce(float fg)
        {
            if (fg < 1 / d1)
            {
                return n1 * fg * fg;
            }
            else if (fg < 2 / d1)
            {
                return n1 * (fg - 1.5f / d1) * fg + 0.75f;
            }
            else if (fg < 2.5f / d1)
            {
                return n1 * (fg -= 2.25f / d1) * fg + 0.9375f;
            }
            else
            {
                return n1 * (fg -= 2.625f / d1) * fg + 0.984375f;
            }
        }

        float EaseInOutSine(float fg) => -(Mathf.Cos(Mathf.PI * fg) - 1) / 2;
        float EaseInOutQuad(float fg) => fg < 0.5f ? 2 * fg * fg : 1 - Mathf.Pow(-2 * fg + 2, 2) / 2;
        float EaseInOutCubic(float fg) => fg < 0.5f ? 4 * fg * fg * fg : 1 - Mathf.Pow(-2 * fg + 2, 3) / 2;
        float EaseInOutQuart(float fg) => fg < 0.5f ? 8 * fg * fg * fg * fg : 1 - Mathf.Pow(-2 * fg + 2, 4) / 2;
        float EaseInOutQuint(float fg) => fg < 0.5f ? 16 * fg * fg * fg * fg * fg : 1 - Mathf.Pow(-2 * fg + 2, 5) / 2;
        float EaseInOutExpo(float fg) => fg == 0 ? 0 : fg == 1 ? 1 : fg < 0.5f ? Mathf.Pow(2, 20 * fg - 10) / 2 : (2 - Mathf.Pow(2, -20 * fg + 10)) / 2;
        float EaseInOutCirc(float fg) => fg < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * fg, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * fg + 2, 2)) + 1) / 2;
        float EaseInOutBack(float fg) => fg < 0.5f ? (Mathf.Pow(2 * fg, 2) * ((c1 + 1) * 2 * fg - c2)) / 2 : (Mathf.Pow(2 * fg - 2, 2) * ((c2 + 1) * (fg * 2 - 2) + c2) + 2) / 2;
        float EaseInOutElastic(float fg) => fg == 0 ? 0 : fg == 1 ? 1 : fg < 0.5f ? -(Mathf.Pow(2, 20 * fg - 10) * Mathf.Sin((20 * fg - 11.125f) * c5)) / 2 : (Mathf.Pow(2, -20 * fg + 10) * Mathf.Sin((20 * fg - 11.125f) * c5)) / 2 + 1;
        float EaseInOutBounce(float fg) => fg < 0.5f ? (1 - EaseOutBounce(1 - 2 * fg)) / 2 : (1 + EaseOutBounce(2 * fg - 1)) / 2;
    }
}