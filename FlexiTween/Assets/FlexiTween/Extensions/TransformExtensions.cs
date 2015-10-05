using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FlexiTween.Extensions
{
    public static class TransformExtensions
    {
        public static Config<Vector3> TweenPosition([NotNull] this Transform transform)
        {
            if (transform == null) throw new ArgumentNullException("transform");

            return Tween
                .From(transform.position)
                .OnUpdate(position => transform.position = position);
        }

        public static Config<Vector3> TweenLocalPosition([NotNull] this Transform transform)
        {
            if (transform == null) throw new ArgumentNullException("transform");

            return Tween
                .From(transform.localPosition)
                .OnUpdate(position => transform.localPosition = position);
        }

        public static Config<Quaternion> TweenRotation([NotNull] this Transform transform)
        {
            if (transform == null) throw new ArgumentNullException("transform");

            return Tween
                .From(transform.rotation)
                .OnUpdate(rotation => transform.rotation = rotation);
        }

        public static Config<Quaternion> TweenLocalRotation([NotNull] this Transform transform)
        {
            if (transform == null) throw new ArgumentNullException("transform");

            return Tween
                .From(transform.localRotation)
                .OnUpdate(rotation => transform.localRotation = rotation);
        }

        public static Config<Vector3> TweenLocalScale([NotNull] this Transform transform)
        {
            if (transform == null) throw new ArgumentNullException("transform");

            return Tween
                .From(transform.localScale)
                .OnUpdate(scale => transform.localScale = scale);
        }
    }
}