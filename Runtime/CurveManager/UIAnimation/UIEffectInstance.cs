using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    public interface IEffect
    {
        public void Play();
    }

    public class UIEffectInstance : MonoBehaviour, IEffect
    {
        public virtual void Play()
        {
        }
    }
}