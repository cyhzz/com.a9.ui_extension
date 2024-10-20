using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectBar : MonoBehaviour
{
    [SerializeField]
    RectTransform target;
    RectTransform Target
    {
        get
        {
            if (target == null)
                target = GetComponent<RectTransform>();
            return target;
        }
    }
    float startSizeX;
    float StartSizeX
    {
        get
        {
            if (Target == null)
            {
                return 0;
            }
            if (startSizeX == 0)
                startSizeX = Target.sizeDelta.x;
            return startSizeX;
        }
    }

    public void Fill(float value)
    {
        if (Target == null)
        {
            return;
        }
        Target.sizeDelta = new Vector2(StartSizeX * value, Target.sizeDelta.y);
    }
}
