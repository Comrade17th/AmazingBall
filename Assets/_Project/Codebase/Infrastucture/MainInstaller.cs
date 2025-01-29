using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.Factories;
using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.Core.Spawnable;
using _Project.Codebase.Core.Wallet;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Ball_View _ballView;
        [SerializeField] private CoinCollector _coinCollector;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private PointerHandler _pointerHandler;
        
        [SerializeField] private HitVFX _hitVFXPrefab;
        [SerializeField] private CoinVFX _coinVFXPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsCached();
            
            BindInputProvider();
            BindPointerHandler();

            BindBall();

            BindCoinCollector();
            BindWallet();
            
            BindHitVFXFactory();
            BindCoinVFXFactory();
            
            Debug.Log($"MainInstaller installer version: {Application.version}");
        }

        private void BindBall()
        {
            Ball_View ballView = _ballView.GetComponent<Ball_View>();
            
            Container
                .Bind<Ball_View>()
                .FromInstance(ballView);
            
            Container
                .Bind<IReadOnlyBallTransform>()
                .To<Ball_View>()
                .FromInstance(ballView);
            
            Container
                .Bind<ICustomVelocity>()
                .To<CustomVelocity>()
                .AsSingle();
            
            Container
                .Bind<IBallModel>()
                .To<BallModel>()
                .AsSingle();
            
            Container
                .Bind<IBallView>()
                .To<Ball_View>()
                .FromInstance(ballView)
                .AsCached();
            
            Container
                .Bind<BallViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCoinVFXFactory()
        {
            Container
                .Bind<CoinVFX>()
                .FromInstance(_coinVFXPrefab)
                .AsSingle();
            
            Container
                .Bind<CoinCollectEffectFactory>()
                .AsSingle();
        }

        private void BindHitVFXFactory()
        {
            Container
                .Bind<HitVFX>()
                .FromInstance(_hitVFXPrefab)
                .AsSingle();
            
            Container
                .Bind<HitEffectFactory>()
                .AsSingle();
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
            Container.Bind<WalletView>()
                .FromInstance(_walletView)
                .AsSingle();
            
            Container
                .Bind<WalletModel>()
                .AsSingle();

            Container
                .Bind<WalletViewModel>()
                .AsSingle()
                .NonLazy();
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
    }
}