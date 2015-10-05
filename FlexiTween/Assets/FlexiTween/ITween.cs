using System;

namespace FlexiTween
{
    public interface ITween
    {
        void Finish();
        void Abort();
        event Action OnComplete;
    }
}