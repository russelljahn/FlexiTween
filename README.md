# Note: #
* This is left up for educational purposes. There's value in keeping up old work to compare how far you've grown. 🙂
* For a production project, I would highly recommend [DOTween](http://dotween.demigiant.com/). I've had a great experience with that framework over the years. 

# FlexiTween
FlexiTween is a tweening framework for Unity3D with a focus on being easily adaptable for different data types, whether tweening Unity's own types such as `Transform` and `CanvasGroup` or your own.

FlexiTween provides a concise solution to quickly script animation.

#### Usage example: ####
```csharp
using FlexiTween;
using FlexiTween.Extensions;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition = new Vector3(0, 3, 0);
    [SerializeField] private float duration = 1;
    [SerializeField] private AnimationCurve curve = AnimationCurveHelper.GetLinearCurve();

    private ITween _tween;
    private bool _atTarget;
    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;

        TweenPosition();
    }

    private void TweenPosition()
    {
        var position = _atTarget
            ? _originalPosition
            : targetPosition;

        _atTarget = !_atTarget;

        _tween.SafelyAbort();
        _tween = Tween
            .From(transform.position)
            .To(position, duration)
            .OnUpdate(p => transform.position = p)
            .Easing(curve)
            .Start();

        _tween.OnComplete += TweenPosition;
    }
}
```
