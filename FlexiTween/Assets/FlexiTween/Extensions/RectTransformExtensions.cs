using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FlexiTween.Extensions
{
    public static class RectTransformExtensions
    {
        public static Config<Vector2> TweenAnchoredPosition([NotNull] this RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException("rectTransform");

            return Tween
                .From(rectTransform.anchoredPosition)
                .OnUpdate(position => rectTransform.anchoredPosition = position);
        }

        public static Config<Vector2> TweenSizeDelta([NotNull] this RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException("rectTransform");

            return Tween
                .From(rectTransform.sizeDelta)
                .OnUpdate(delta => rectTransform.sizeDelta = delta);
        }

        public static Config<Vector4> TweenOffsetMinAndMax([NotNull] this RectTransform rectTransform)
        {
            if (rectTransform == null) throw new ArgumentNullException("rectTransform");

            var startValue = new Vector4(
                rectTransform.offsetMin.x, rectTransform.offsetMin.y,
                rectTransform.offsetMax.x, rectTransform.offsetMax.y);

            return Tween
                .From(startValue)
                .OnUpdate(vector =>
                {
                    rectTransform.offsetMin = new Vector2(vector.x, vector.y);
                    rectTransform.offsetMax = new Vector2(vector.z, vector.w);
                });
        }
    }
}