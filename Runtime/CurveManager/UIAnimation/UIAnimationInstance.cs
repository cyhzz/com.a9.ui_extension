using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Com.A9.UIExt
{
    public enum AnimationStyle
    {
        POSITION, ROTATION, SCALE_UP, SCALE_DOWN, SCALE_BOUNCE, SCALE_PRECISE, CANVAS_ALPHA, SPRITE_ALPHA
    }

    public class UIAnimationInstance : UIEffectInstance
    {
        public UIAnimationV2 anim;
        public AnimationStyle style;
        public CurveType type;
        public float duration;
        public UnityEvent OnEnd;

        public float mul_a;
        public float mul_b;
        public Vector2 vec_a;
        public Vector2 vec_b;

        public override void Play()
        {
            if (anim == null)
            {
                anim = GetComponent<UIAnimationV2>();
            }
            if (style == AnimationStyle.SCALE_DOWN)
                anim.ScaleDown(type, duration, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.SCALE_UP)
                anim.ScaleUp(type, duration, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.SCALE_BOUNCE)
                anim.ScaleBounce(type, duration, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.SCALE_PRECISE)
                anim.Scale(type, duration, vec_a, vec_b, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.POSITION)
                anim.Position(type, vec_a, vec_b, duration, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.CANVAS_ALPHA)
                anim.CanvasAlpha(type, mul_a, mul_b, duration, () => { OnEnd?.Invoke(); });
            else if (style == AnimationStyle.SPRITE_ALPHA)
                anim.SpriteAlpha(type, mul_a, mul_b, duration, () => { OnEnd?.Invoke(); });
        }
    }
}