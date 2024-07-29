using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.A9.UIExt
{
    public static class CoroutineExtension
    {
        public static void StartCoroutineInterrupt(this MonoBehaviour m, IEnumerator sc)
        {
            if (!CoroutineManager.instance)
            {
                Debug.Log("there is no coroutine coordinator , start coroutine failed");
                return;
            }
            CoroutineManager.instance.StartCoroutineInterrupt(m, sc);
        }
    }
}