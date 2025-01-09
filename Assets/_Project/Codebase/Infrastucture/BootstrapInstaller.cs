using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class BootstrapInstaller : MonoInstaller
    {
        private ZenjectSceneLoader _zenjectSceneLoader;
        private SceneProvider _sceneProvider;
        
        public override void InstallBindings()
        {
            Debug.Log($"boot");
            Container.Bind<ZenjectSceneLoader>().AsSingle();

            Container.Bind<SceneProvider>()
                .AsSingle();
        }
    }
}