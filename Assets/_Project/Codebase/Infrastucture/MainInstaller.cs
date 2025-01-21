using _Project.Codebase.Core;
using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.Core.Wallet;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class MainInstaller : MonoInstaller
    {
        //[SerializeField] private GameObject _ballPrefab;
        [SerializeField] private BallView _ballView;
        [SerializeField] private CoinCollector _coinCollector;
        [SerializeField] private PointerHandler _pointerHandler;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsCached();
            
            BindInputProvider();
            BindPointerHandler();
            BindBallView();
            BindPhysicsBody();
            BindCoinCollector();
            BindWallet();

            Debug.Log($"MainInstaller InstallBindings");
        }

        private void BindCoinCollector()
        {
            Container
                .Bind<CoinCollector>()
                .FromInstance(_coinCollector)
                .AsSingle();
        }

        private void BindWallet()
        {
            Container
                .Bind<WalletModel>()
                .AsSingle();

            Container
                .Bind<WalletViewModel>()
                .AsSingle();
        }

        private void BindPhysicsBody()
        {
            PhysicsBody physicsBody = _ballView.GetComponent<PhysicsBody>();

            Container
                .Bind<PhysicsBody>()
                .FromInstance(physicsBody)
                .AsSingle();
        }

        private void BindInputProvider()
        {
            Container
                .Bind<IInputProvider>()
                .To<MouseInputProvider>()
                .AsSingle();
        }

        private void BindPointerHandler()
        {
            Container
                .Bind<PointerHandler>()
                .FromInstance(_pointerHandler)
                .AsSingle();
        }

        private void BindBallView()
        {
            Container
                .Bind<BallView>()
                .FromInstance(_ballView)
                .AsSingle()
                .NonLazy();
        }
    }
}