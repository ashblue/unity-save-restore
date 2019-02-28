namespace CleverCrow.SaveRestore {
    public interface IStorage<T> where T : ISaveRestore {
        T GetById (string id);
    }
}
