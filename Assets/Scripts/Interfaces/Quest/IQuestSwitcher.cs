namespace Quest.GameLogic
{
    public interface IQuestSwitcher
    {
        public IQuest CurrentQuest { get; }
    }
}