using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace PingPong.Scripts.Root.Services
{
    public class LoadSceneService
    {
        public void Load(int sceneId)
        {
            LoadSceneAsync(sceneId);
        }

        private async void LoadSceneAsync(int sceneId)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneId);
            
            while(!sceneLoading.isDone)
                await Task.Yield();
        }
    }
}