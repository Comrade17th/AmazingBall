using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Codebase.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        //private ZenjectSceneLoader _zenjectSceneLoader;
        private SceneProvider _sceneProvider;
        
        public override void InstallBindings()
        {
            Debug.Log("BootstrapInstaller InstallBindings");
            //Container.Bind<ZenjectSceneLoader>().AsSingle();

            Container.Bind<SceneProvider>()
                .AsSingle();
        }
    }
}