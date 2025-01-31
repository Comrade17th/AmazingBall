using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Codebase.Infrastructure
{
    public class BootSceneLoader : MonoBehaviour
    {
        private SceneProvider _sceneProvider;
        
        // [Inject]
        // private void Construct(SceneProvider sceneProvider)
        // {
        //     _sceneProvider = sceneProvider;
        // }

        private void Start()
        {
            //_sceneProvider.LoadMainScene();
            SceneManager.LoadScene("Main");
        }
    }
}