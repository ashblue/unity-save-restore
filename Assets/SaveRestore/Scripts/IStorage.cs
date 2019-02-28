namespace CleverCrow.SaveRestore {
    public interface IStorage {
        ISaveRestore GetById (string id);
    }
}