using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class SceneProvider
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly string _mainSceneName = "Main";
        
        [Inject]
        public SceneProvider(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader; // some shit
        }

        public void LoadMainScene()
        {
            _sceneLoader.LoadScene(_mainSceneName);
        }
    }
}