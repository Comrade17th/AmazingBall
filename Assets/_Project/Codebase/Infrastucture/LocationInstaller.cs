using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPoint;

        public override void InstallBindings()
        {
            Debug.Log($"InstallBindings");
        }
    }
}