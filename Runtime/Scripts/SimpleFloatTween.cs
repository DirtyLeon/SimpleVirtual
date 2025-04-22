using System;
using UnityEngine;

namespace DirtyWorks.Simple
{
    public class SimpleFloatTween
    {
        private float start;
        private float end;
        private float duration;
        private float elapsed;
        private Action<float> onUpdate;
        private Action onComplete;
        private Func<float, float> easing;
        private bool isKilled = false;

        public void Kill() => isKilled = true;

        public SimpleFloatTween(float start, float end, float duration, 
            Action<float> onUpdate, Action onComplete = null, Func<float, float> easing = null)
        {
            this.start = start;
            this.end = end;
            this.duration = duration;
            this.elapsed = 0f;
            this.onUpdate = onUpdate;
            this.onComplete = onComplete;
            this.easing = easing ?? EaseLinear;

            onUpdate?.Invoke(start);
        }

        public bool Update(float deltaTime)
        {
            if (isKilled)
                return true;    // Return if is killed. 

            elapsed += deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float easedT = easing(t);
            float current = Mathf.Lerp(start, end, easedT);
            onUpdate?.Invoke(current);

            if (t >= 1f)
            {
                onComplete?.Invoke();
                return true; // Completed.
            }

            return false; // Continues.
        }

        private static float EaseLinear(float t) => t;
    }
}
