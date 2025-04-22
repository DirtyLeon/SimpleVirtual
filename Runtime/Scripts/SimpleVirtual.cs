using System;
using DirtyWorks.Simple.Manager;

namespace DirtyWorks.Simple
{
    public static class SimpleVirtual
    {
        /// <summary>
        /// <para>
        /// Simplfied version of DOVirtual.
        /// </para><para>
        /// e.g. SimpleVirtual.float(0f, 1f, 1f, v => audio.volume = v);
        /// </para>
        /// </summary>
        public static SimpleFloatTween Float(float from, float to, float duration,
            Action<float> onUpdate, Action onComplete = null, Func<float, float> ease = null)
        {
            var tween = new SimpleFloatTween(from, to, duration, onUpdate, onComplete, ease);
            SimpleTweenManager.Register(tween);
            return tween;
        }
    }
}

