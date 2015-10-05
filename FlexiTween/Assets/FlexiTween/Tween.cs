using System;
using System.Collections;
using System.Linq;
using FlexiTween.Extensions;
using UnityEngine;

namespace FlexiTween
{
    public static class Tween
    {
        /// <summary>
        ///     Stops all tweens. Any complete callbacks are no longer invoked after the tweens are stopped.
        /// </summary>
        public static void SafelyAbort(params ITween[] tweens)
        {
            foreach (var tween in tweens.Where(t => t != null))
            {
                tween.Abort();
            }
        }

        public static Config<float> From(float startValue)
        {
            return new Config<float>(Mathf.Lerp, startValue);
        }

        public static Config<Vector2> From(Vector2 startValue)
        {
            return new Config<Vector2>(Vector2.Lerp, startValue);
        }

        public static Config<Vector3> From(Vector3 startValue)
        {
            return new Config<Vector3>(Vector3.Lerp, startValue);
        }

        public static Config<Vector4> From(Vector4 startValue)
        {
            return new Config<Vector4>(Vector4.Lerp, startValue);
        }

        public static Config<Color> From(Color startValue)
        {
            return new Config<Color>(Color.Lerp, startValue);
        }

        public static Config<Color32> From(Color32 startValue)
        {
            return new Config<Color32>(Color32.Lerp, startValue);
        }

        public static Config<Quaternion> From(Quaternion startValue)
        {
            return new Config<Quaternion>(Quaternion.Lerp, startValue);
        }
    }

    internal class Tween<T> : ITween
    {
        private readonly Config<T> _config;

        private float _currentTime;
        private bool _shouldCallbackCompletion = true;
        private bool _isFinished;

        public Tween(Config<T> config)
        {
            _config = config;
        }

        /// <summary>
        ///     Stops tween and invokes complete callbacks.
        /// </summary>
        public void Finish()
        {
            _shouldCallbackCompletion = true;
            _isFinished = true;
        }

        /// <summary>
        ///     Stops tween without invoking complete callbacks.
        /// </summary>
        public void Abort()
        {
            _shouldCallbackCompletion = false;
            _isFinished = true;
        }

        public event Action OnComplete;

        public void Start()
        {
            if (TweenStarter.instance == null)
            {
                Abort();
            }
            else
            {
                TweenStarter.instance.StartCoroutine(GetTweenEnumerator());
            }
        }

        public override string ToString()
        {
            return string.Format("Current time: {0}, duration: {1}, current value: {2}, end value: {3}",
                _currentTime, _config.duration, GetValue(_currentTime/_config.duration), _config.endValue);
        }

        /// <param name="normalizedTime">Should be float between 0f-1f.</param>
        private T GetValue(float normalizedTime)
        {
            const float fallbackEasingEndTime = 1f;
            var easingLength = _config.curve.GetEndTime(fallbackEasingEndTime);
            var amount = _config.curve.Evaluate(normalizedTime*easingLength);

            return _config.lerp(_config.startValue, _config.endValue, amount);
        }

        private IEnumerator GetTweenEnumerator()
        {
            while (_isFinished == false && _currentTime < _config.duration)
            {
                _config.update(GetValue(_currentTime/_config.duration));

                yield return null;

                _currentTime = Mathf.Clamp(_currentTime + Time.deltaTime, 0f, _config.duration);
            }

            // Clamp value to end value only if not aborting
            if (_isFinished == false)
            {
                _config.update(GetValue(1f));
            }

            _isFinished = true;

            if (_shouldCallbackCompletion == false)
                yield break;

            if (OnComplete != null)
                OnComplete();
        }
    }
}