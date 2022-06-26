namespace Quest.Data
{
    public interface IScreenStorage
    {
        public void SaveData(ScreenData.Data data);

        public ScreenData LoadAllData();

        public bool TryLoad(out ScreenData.Data lastSavedData);

        public void SaveLastData(ScreenData.Data data);
    }
}