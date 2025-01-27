using System;

namespace _Project.Codebase.Interfaces
{
    public interface IPoolableCustom<T>
    {
        event Action<T> ReleaseRequested;
    } 
}