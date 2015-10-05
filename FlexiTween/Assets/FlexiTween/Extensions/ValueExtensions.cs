using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FlexiTween.Extensions
{
    public static class ValueExtensions
    {
        public static Config<float> TweenMinHeight([NotNull] this LayoutElement layoutElement)
        {
            if (layoutElement == null) throw new ArgumentNullException("layoutElement");

            return Tween
                .From(layoutElement.minHeight)
                .OnUpdate(height => layoutElement.minHeight = height);
        }

        public static Config<float> TweenFontSize([NotNull] this Text text)
        {
            if (text == null) throw new ArgumentNullException("text");

            return Tween
                .From(text.fontSize)
                .OnUpdate(size => text.fontSize = Mathf.FloorToInt(size));
        }

        public static Config<Color> TweenColor([NotNull] this Graphic graphic)
        {
            if (graphic == null) throw new ArgumentNullException("graphic");

            return Tween
                .From(graphic.color)
                .OnUpdate(color => graphic.color = color);
        }

        public static Config<float> TweenAlpha([NotNull] this CanvasGroup canvasGroup)
        {
            if (canvasGroup == null) throw new ArgumentNullException("canvasGroup");

            return Tween
                .From(canvasGroup.alpha)
                .OnUpdate(alpha => canvasGroup.alpha = alpha);
        }

        public static Config<float> TweenFillAmount([NotNull] this Image image)
        {
            if (image == null) throw new ArgumentNullException("image");

            return Tween
                .From(image.fillAmount)
                .OnUpdate(amount => image.fillAmount = amount);
        }
    }
}