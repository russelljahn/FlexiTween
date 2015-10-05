using System;
using UnityEngine;

namespace FlexiTween
{
    [Serializable]
    public class TweenSettings
    {
        public float Duration = 1;
        public AnimationCurve Curve = AnimationCurveHelper.GetLinearCurve();
    }
}