using _Project.Codebase.Core;
using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private BallView _ballView;

        //private MouseInputProvider _inputProvider;

        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsCached(); // why using AsCached
            Container.Bind<IInputProvider>().To<MouseInputProvider>().AsSingle(); // add decision to keybord, mouse, phone, move to project installer?

            CreateBall();
            
            Debug.Log($"MainInstaller InstallBindings");
        }

        private void CreateBall()
        {
            //BallView ballView = Container
            //    .InstantiatePrefabForComponent<BallView>(_ballPrefab, _ballSpawnPoint.position, Quaternion.identity, null); // Zenject gives warning of bad practice

            Container
                .Bind<BallView>()
                .FromInstance(_ballView)
                .AsSingle();
        }
    }
}