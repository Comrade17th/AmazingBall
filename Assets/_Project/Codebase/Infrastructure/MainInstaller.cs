using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.Core.Ball.ViewModel;
using _Project.Codebase.Core.Factories;
using _Project.Codebase.Core.InputProviders;
using _Project.Codebase.Core.Line;
using _Project.Codebase.Core.Spawnable;
using _Project.Codebase.Core.Wallet;
using _Project.Codebase.Interfaces;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private BallView _ballView;
        [SerializeField] private CoinCollector _coinCollector;
        
        [SerializeField] private BallRotationView _ballRotationView;
        [SerializeField] private BallCompressionView _ballCompressionView;
        [SerializeField] private BallColorView _ballColorView;
        
        [SerializeField] private LineView _lineView;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private MousePointerHandler _mousePointerHandler;

        [SerializeField] private HitVFX _hitVFXPrefab;
        [SerializeField] private CoinVFX _coinVFXPrefab;

        public override void InstallBindings()
        {
            BindCamera();
            BindInputProvider();
            BindPointerHandler();
            BindBall();
            BindLine();
            BindCoinCollector();
            BindWallet();
            BindCoinVFXFactory();
            
            Debug.Log($"MainInstaller installer version: {Application.version}");
        }

        private void BindCamera()
        {
            Container
                .BindInstance(Camera.main)
                .AsCached();
        }

        private void BindLine()
        {
            Container
                .Bind<ILineView>()
                .To<LineView>()
                .FromInstance(_lineView)
                .AsCached();
            
            Container
                .Bind<ILineViewModel>()
                .To<LineViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBall()
        {
            BallView ballView = _ballView.GetComponent<BallView>();
            
            Container
                .Bind<BallView>()
                .FromInstance(ballView); 
            
            Container
                .Bind<IReadOnlyBallTransform>()
                .To<BallView>()
                .FromInstance(ballView);
            
            Container
                .Bind<ICustomVelocity>()
                .To<CustomVelocity>()
                .AsSingle();
            
            Container
                .Bind<IBallModel>()
                .To<BallModel>()
                .AsSingle();
            
            BindBallViews(ballView);

            Container
                .Bind<IBallViewModel>()
                .To<BallViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBallViews(BallView ballView)
        {
            Container
                .Bind<IBallView>()
                .To<BallView>()
                .FromInstance(ballView)
                .AsCached();

            BindHitEffectView();
            BindColorView();
            BindRotationView();
            BindCompressionView();
        }

        private void BindHitEffectView()
        {
            BindHitVFXFactory();

            Container
                .Bind<IHitEffectView>()
                .To<BallHitEffectView>()
                .AsSingle();
        }

        private void BindRotationView()
        {
            Container
                .Bind<IBallRotationView>()
                .To<BallRotationView>()
                .FromInstance(_ballRotationView)
                .AsSingle();

            Container
                .Bind<IBallRotationViewModel>()
                .To<BallRotationViewModel>()
                .AsSingle();
        }

        private void BindColorView()
        {
            Container
                .Bind<IBallColorView>()
                .To<BallColorView>()
                .FromInstance(_ballColorView)
                .AsSingle();

            Container
                .Bind<IBallColorViewModel>()
                .To<BallColorViewModel>()
                .AsSingle();
        }

        private void BindCompressionView()
        {
            Container
                .Bind<IBallCompressionView>()
                .To<BallCompressionView>()
                .FromInstance(_ballCompressionView)
                .AsSingle();

            Container
                .Bind<IBallCompressionViewModel>()
                .To<BallCompressionViewModel>()
                .AsSingle();
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
            Container
                .Bind<IWalletView>()
                .To<WalletView>()
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
                .Bind<IPointerHandler>()
                .To<MousePointerHandler>()
                .FromInstance(_mousePointerHandler)
                .AsSingle()
                .NonLazy();
        }
    }
}