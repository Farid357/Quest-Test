using Quest.SaveSystem;
using System.IO;
using UnityEngine;

namespace Quest.Data
{
    public sealed class ScreenStorage : IScreenStorage
    {
        private readonly IStorage _storage = new JSONStorage();
        private readonly string _path = Path.Combine(Application.streamingAssetsPath + "/ScreenData.json");
        private readonly string _lastSavedDataPath = Path.Combine(Application.streamingAssetsPath + "/Data.json");
        private readonly ScreenData _screenData = new();

        public void SaveData(ScreenData.Data data)
        {
            _screenData.Add(data);
            _storage.Save(_path, _screenData);
        }

        public ScreenData LoadAllData() => _storage.Load<ScreenData>(_path);

        public bool TryLoad(out ScreenData.Data lastSavedData)
        {
            lastSavedData = _storage.Load<ScreenData.Data>(_lastSavedDataPath);
            return lastSavedData == null;
        }

        public void SaveLastData(ScreenData.Data data) => _storage.Save(_lastSavedDataPath, data);
    }
}
