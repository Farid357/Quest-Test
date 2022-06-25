namespace Quest.SaveSystem
{
    public interface IStorage
    {
        public T Load<T>(string key, T loadObject);
        public void Save<T>(string key, T saveObject);
        public bool Exists(string path);
    }
}