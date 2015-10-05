using System;
using UnityEngine;

namespace FlexiTween
{
    public delegate T Lerp<T>(T from, T to, float t);

    public class Config<T>
    {
        public Lerp<T> lerp { get; private set; }
        public T startValue { get; private set; }
        public AnimationCurve curve { get; private set; }
        public T endValue { get; private set; }
        public float duration { get; private set; }
        public Action<T> update { get; private set; }

        public Config(Lerp<T> lerpFunction, T startValue)
        {
            lerp = lerpFunction;
            this.startValue = startValue;
            curve = AnimationCurveHelper.GetLinearCurve();
        }

        public Config<T> To(T value, float duration)
        {
            if (duration < 0)
                throw new ArgumentException("Duration is negative.", "duration");

            endValue = value;
            this.duration = duration;
            return this;
        }

        public Config<T> Easing(AnimationCurve curve)
        {
            if (curve == null)
                throw new ArgumentNullException("curve");

            this.curve = curve;
            return this;
        }

        public Config<T> OnUpdate(Action<T> action)
        {
            update = action;
            return this;
        }

        public ITween Start()
        {
            if (update == null)
                throw new NullReferenceException("Update function is not set.");

            var tween = new Tween<T>(this);
            tween.Start();
            return tween;
        }
    }
}