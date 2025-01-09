using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastucture
{
    public class BootSceneLoader : MonoBehaviour
    {
        private SceneProvider _sceneProvider;
        
        [Inject]
        private void Construct(SceneProvider sceneProvider)
        {
            _sceneProvider = sceneProvider;
        }

        private void Start()
        {
            _sceneProvider.LoadMainScene();
        }
    }
}