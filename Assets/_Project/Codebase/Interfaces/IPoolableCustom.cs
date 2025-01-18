using System;

namespace _Project.Codebase.Interfaces
{
    interface IPoolableCustom<T>
    {
        event Action<T> ReleaseRequested;
    } 
}