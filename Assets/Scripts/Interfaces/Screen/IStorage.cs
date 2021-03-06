namespace Quest.SaveSystem
{
    public interface IStorage
    {
        public T Load<T>(string key);
        public void Save<T>(string key, T saveObject);
        public bool Exists(string path);
    }
}