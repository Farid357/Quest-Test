using System;

namespace Quest.GameLogic
{
    public interface ICallbackReciever
    {
        public ICallbackReciever WithCondition(Func<bool> condition);
        public ICallbackReciever OnCompleted(Action completeCallback);
    }
}
