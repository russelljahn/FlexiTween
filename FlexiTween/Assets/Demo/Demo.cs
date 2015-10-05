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