using _Project.Codebase.Core.Attacker.BallAttacker;
using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.Core.Ball.ViewModel;
using _Project.Codebase.Core.Factories;
using _Project.Codebase.Core.Health.BallHealth;
using _Project.Codebase.Core.Health.EnemyHealth;
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
        [Header("Ball attached")]
        [SerializeField] private BallView _ballView;
        [SerializeField] private CoinCollector _coinCollector;
        [SerializeField] private BallHealthHitBox _ballHealthHitBox;
        
        [Header("Ball's mesh attached")]
        [SerializeField] private BallRotationView _ballRotationView;
        [SerializeField] private BallCompressionView _ballCompressionView;
        [SerializeField] private BallColorView _ballColorView;
        
        [Header("GUI")]
        [SerializeField] private WalletView _walletView;
        [SerializeField] private BallSpeedView _ballSpeedView;
        [SerializeField] private BallAngleView _angleView;
        [SerializeField] private BallHealthView _ballHealthView;
        
        [Header("Inputs")]
        [SerializeField] private MousePointerHandler _mousePointerHandler;
        
        [Header("Over world")]
        [SerializeField] private LineView _lineView;
        
        [Header("Prefabs")]
        [SerializeField] private HitVFX _hitVFXPrefab;
        [SerializeField] private CoinVFX _coinVFXPrefab;
        
        [Header("Enemy")]
        [SerializeField] private EnemyHealthBarView _enemyHealthBarView;
        [SerializeField] private EnemyHealthHitBox _enemyHealthHitBox;

        public override void InstallBindings()
        {
            BindCamera();
            BindInputProvider();
            BindPointerHandler();
            BindBall();
            BindSpeedView();
            BindAngelView();
            BindLine();
            BindBallHealth();
            BindBallAttacker();

            Container
                .Bind<IEnemyHealthModel>()
                .To<EnemyHealthModel>()
                .AsSingle();

            Container
                .Bind<IEnemyHealthView>()
                .To<EnemyHealthBarView>()
                .FromInstance(_enemyHealthBarView)
                .AsSingle();

            Container
                .Bind<IEnemyHealthHitBox>()
                .To<EnemyHealthHitBox>()
                .FromInstance(_enemyHealthHitBox)
                .AsSingle();

            Container
                .Bind<IEnemyHealthViewModel>()
                .To<EnemyHealthViewModel>()
                .AsSingle()
                .NonLazy();

            BindCoinCollector();
            BindWallet();
            BindCoinVFXFactory();
            
            Debug.Log($"MainInstaller installer version: {Application.version}");
        }

        private void BindBallAttacker()
        {
            BindBallAttackerModel();
            BindBallAttackRool();
            BindBallAttackerViewModel();
        }

        private void BindBallAttackerViewModel()
        {
            Container
                .Bind<IBallAttackerViewModel>()
                .To<BallAttackerViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBallAttackRool()
        {
            Container
                .Bind<IBallAttackRool>()
                .To<BallAttackRool>()
                .AsSingle();
        }

        private void BindBallAttackerModel()
        {
            Container
                .Bind<IBallAttackerModel>()
                .To<BallAttackerModel>()
                .AsSingle();
        }

        private void BindBallHealth()
        {
            BindBallHealthModel();
            BindBallHealthView();
            BindBallHealthHitBox();
            BindBallHealthViewModel();
        }

        private void BindBallHealthViewModel()
        {
            Container
                .Bind<IBallHealthViewModel>()
                .To<BallHealthViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBallHealthHitBox()
        {
            Container
                .Bind<IBallHealthHitBox>()
                .To<BallHealthHitBox>()
                .FromInstance(_ballHealthHitBox)
                .AsSingle();
        }

        private void BindBallHealthView()
        {
            Container
                .Bind<IBallHealthView>()
                .To<BallHealthView>()
                .FromInstance(_ballHealthView)
                .AsSingle();
        }

        private void BindBallHealthModel()
        {
            Container
                .Bind<IBallHealthModel>()
                .To<BallHealthModel>()
                .AsSingle();
        }

        private void BindAngelView()
        {
            Container
                .Bind<IBallAngleView>()
                .To<BallAngleView>()
                .FromInstance(_angleView)
                .AsSingle();

            Container
                .Bind<IBallAngleViewModel>()
                .To<BallAngleViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSpeedView()
        {
            Container
                .Bind<IBallSpeedView>()
                .To<BallSpeedView>()
                .FromInstance(_ballSpeedView)
                .AsSingle();

            Container
                .Bind<IBallSpeedViewModel>()
                .To<BallSpeedViewModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCamera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(Camera.main)
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