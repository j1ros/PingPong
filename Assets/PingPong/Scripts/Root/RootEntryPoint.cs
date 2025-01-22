using PingPong.Scripts.Root.Services;
using PingPong.Scripts.Root.Services.SaveLoadService;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Root
{
    public class RootEntryPoint : MonoBehaviour
    {
        [Inject] private LoadSceneService _loadSceneService;
        [Inject] private SaveLoadService _saveLoadService;

        private void Start()
        {
            _loadSceneService.Load(1);
        }
    }
}