using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace FlexiTween
{
    public class TweenStarter : MonoBehaviour
    {
        private static bool _appHasQuitted;
        private static TweenStarter _instance;

        [CanBeNull]
        public static TweenStarter instance
        {
            get
            {
                if (_appHasQuitted)
                {
                    /*throw new InvalidOperationException(
                        "Application has already quitted but new FlexiTween is trying to be created.");*/
                    return null;
                }

                if (_instance == null)
                    _instance = FindObjectsOfType<TweenStarter>().SingleOrDefault();

                if (_instance != null)
                    return _instance;

                var go = new GameObject(typeof (TweenStarter).Name)
                {
                    hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector
                };

                DontDestroyOnLoad(go);
                _instance = go.AddComponent<TweenStarter>();

                return _instance;
            }
        }

        [UsedImplicitly]
        private void OnApplicationQuit()
        {
            _appHasQuitted = true;
        }
    }
}