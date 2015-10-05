namespace FlexiTween.Extensions
{
    public static class TweenExtensions
    {
        public static void SafelyAbort(this ITween tween)
        {
            if (tween != null)
                tween.Abort();
        }

        public static void SafelyFinish(this ITween tween)
        {
            if (tween != null)
                tween.Finish();
        }

        /// <summary>
        /// todo: remove
        /// </summary>
        public static Config<T> To<T>(this Config<T> tween, T value, TweenSettings settings)
        {
            return tween.To(value, settings.Duration).Easing(settings.Curve);
        }
    }
}
