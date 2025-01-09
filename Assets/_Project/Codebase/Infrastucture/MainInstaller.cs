using _Project.Codebase.Core;
using _Project.Codebase.Core.InputProviders;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Transform _ballSpawnPoint;
        [SerializeField] private BallView _ballView;

        //private MouseInputProvider _inputProvider;

        public override void InstallBindings()
        {
            Debug.Log($"MainInstaller InstallBindings");

            Container.BindInstance(Camera.main).AsCached(); // why using AsCached
            Container.Bind<IInputProvider>().To<MouseInputProvider>().AsSingle(); // add decision to keybord, mouse, phone
        }
    }
}