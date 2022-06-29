namespace Quest.Data
{
    public interface IScreenStorage
    {
        public void SaveData(ScreenData.Screen data);

        public ScreenData LoadAllData();

        public bool TryLoad(out ScreenData.Screen lastSavedData);

        public void SaveLastScreen(ScreenData.Screen data);
    }
}