using System;
using System.Collections;
using System.Collections.Generic;
using Com.A9.Singleton;
using UnityEngine;

namespace Com.A9.UIExt
{
    public class CoroutineInstance
    {
        public IEnumerator starter;
        public Coroutine running;
    }

    public class CoroutineManager : Singleton<CoroutineManager>
    {
        public Dictionary<MonoBehaviour, List<CoroutineInstance>> crs = new Dictionary<MonoBehaviour, List<CoroutineInstance>>();

        IEnumerator Wrapper(IEnumerator job, Action on_finished)
        {
            yield return StartCoroutine(job);
            on_finished?.Invoke();
        }
        Coroutine CustomStart(MonoBehaviour m, IEnumerator sc)
        {
            var v = m.StartCoroutine(Wrapper(sc, () =>
            {
                CoroutineInstance ci = crs[m].Find(c => c.starter == sc);
                if (ci != null)
                {
                    crs[m].Remove(ci);
                }
                if (crs[m].Count == 0)
                {
                    crs.Remove(m);
                }
            }));
            return v;
        }

        public void StartCoroutineInterrupt(MonoBehaviour m, IEnumerator sc)
        {
            if (!crs.ContainsKey(m))
            {
                crs.Add(m, new List<CoroutineInstance>());
                CoroutineInstance ci = new CoroutineInstance();
                ci.starter = sc;
                ci.running = CustomStart(m, sc);
                crs[m].Add(ci);
            }
            else
            {
                CoroutineInstance ci = crs[m].Find(c => c.starter == sc);
                if (ci != null)
                {
                    m.StopCoroutine(ci.running);
                    ci.running = CustomStart(m, sc);
                }
                else
                {
                    ci = new CoroutineInstance();
                    ci.starter = sc;
                    ci.running = CustomStart(m, sc);
                    crs[m].Add(ci);
                }
            }
        }

        public void StartCoroutineNoInterrupt(MonoBehaviour m, IEnumerator sc)
        {
            if (!crs.ContainsKey(m))
            {
                crs.Add(m, new List<CoroutineInstance>());
                CoroutineInstance ci = new CoroutineInstance();
                ci.starter = sc;
                ci.running = CustomStart(m, sc);
                crs[m].Add(ci);
            }
            else
            {
                CoroutineInstance ci = crs[m].Find(c => c.starter == sc);
                if (ci != null)
                {

                }
                else
                {
                    ci = new CoroutineInstance();
                    ci.starter = sc;
                    ci.running = CustomStart(m, sc);
                    crs[m].Add(ci);
                }
            }
        }
    }
}