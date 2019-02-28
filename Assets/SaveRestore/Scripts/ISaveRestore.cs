namespace CleverCrow.SaveRestore {
    public interface ISaveRestore {
        string Id { get; }

        string Save ();
        void Load (string save);
        ISaveRestore GetCopy ();
    }
}