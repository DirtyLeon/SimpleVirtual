using System.Collections.Generic;
using UnityEngine;

namespace DirtyWorks.Simple.Manager
{
    public class SimpleTweenManager : MonoBehaviour
    {
        private static SimpleTweenManager instance;
        private List<SimpleFloatTween> activeTweens = new();

        public static void Register(SimpleFloatTween tween)
        {
            if (instance == null)
            {
                var go = new GameObject("SimpleTweenManager");
                DontDestroyOnLoad(go);
                instance = go.AddComponent<SimpleTweenManager>();
            }

            instance.activeTweens.Add(tween);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = activeTweens.Count - 1; i >= 0; i--)
            {
                var tween = activeTweens[i];
                if (tween.Update(deltaTime))
                    activeTweens.RemoveAt(i); // Remove if complete
            }
        }
    }
}
