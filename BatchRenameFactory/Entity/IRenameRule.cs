using System;

namespace Entity
{
    public interface IRenameRule
    {
        string Name { get; }
        string Rename(string original);
        string RenameDir(string original);
    }
}
