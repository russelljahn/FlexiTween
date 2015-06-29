using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Vectrosity;

namespace FlexiTweening.Extensions
{
    public static class VectrosityExtensions
    {
        public static ITween<Color32> TweenColor([NotNull] this VectorLine line)
        {
            if (line == null) throw new ArgumentNullException("line");

            return FlexiTween.From(line.color)
                .OnUpdate(line.SetColor);
        }

        public static ITween<Color32> TweenColors([NotNull] this IList<VectorLine> lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");

            return FlexiTween.From(lines[0].color)
                .OnUpdate(color =>
                {
                    // ReSharper disable once ForCanBeConvertedToForeach
                    for (var i = 0; i < lines.Count; ++i)
                    {
                        lines[i].SetColor(color);
                    }
                }
                );
        }
    }
}
