using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace FlexiTween.Extensions
{
    public static class SpriteRendererExtensions
    {
        public static Config<Color> TweenColor([NotNull] this SpriteRenderer spriteRenderer)
        {
            if (spriteRenderer == null) throw new ArgumentNullException("spriteRenderer");

            return Tween
                .From(spriteRenderer.color)
                .OnUpdate(color => spriteRenderer.color = color);
        }

        public static Config<Color> TweenColor([NotNull] this IList<SpriteRenderer> spriteRenderers)
        {
            if (spriteRenderers == null) throw new ArgumentNullException("spriteRenderers");

            return Tween
                .From(spriteRenderers.First().color)
                .OnUpdate(color =>
                {
                    foreach (var renderer in spriteRenderers)
                    {
                        renderer.color = color;
                    }
                });
        } 
    }
}