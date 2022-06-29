using Quest.Data;

namespace Quest.GameLogic
{
    public interface IPusher
    {
        public IPusher Push<T>() where T : IQuest;
        public ICallbackReciever SetTransitions(ScreenData.Screen[] transitions);
    }
}
