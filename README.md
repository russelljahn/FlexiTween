# FlexiTween
FlexiTween is a tweening framework for Unity3D with a focus on being easily adaptable for different data types, whether tweening Unity's own types such as `Transform` and `CanvasGroup` or your own.

FlexiTween provides a concise solution to quickly script animation.

####Usage examples:
```csharp
using FlexiTweening;
using FlexiTweening.Extensions;
using UnityEngine;

[RequireComponent(typeof (CanvasGroup))]
public class TweenExamples : MonoBehaviour
{
    [SerializeField] private AnimationCurve _easingCurve;
    [SerializeField] private float _duration = 0.5f;

    private CanvasGroup _canvasGroup;
    private ITween _tween;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void DoFadeExample1()
    {
        /* Simple example of fading out a CanvasGroup. */
        _tween = FlexiTween.From(_canvasGroup.alpha)
            .OnUpdate(alpha => _canvasGroup.alpha = alpha)
            .To(0.0f, _duration)
            .Easing(_easingCurve) // Optional easing curve
            .OnComplete(() => Debug.Log("Finished fading!")) // Optional callback
            .Start(); // Must call Start() to execute the tween
    }

    public void DoFadeExample2()
    {
        /* For many types, there are also some included extensions to simplify tweening. */
        _tween = _canvasGroup.TweenAlpha()
            .To(0.0f, _duration)
            .Easing(_easingCurve) // Optional easing curve
            .OnComplete(() => Debug.Log("Finished fading!")) // Optional callback
            .Start(); // Must call Start() to execute the tween
    }

    public void StopTweenExample1()
    {
        /* This stops the tween, and won't execute the optional callback if it was provided. */
        _tween.Abort();
    }


    public void StopTweenExample2()
    {
        /* This stops the tween, but the callback is still executed. */
        _tween.Finish();
    }
}
```
