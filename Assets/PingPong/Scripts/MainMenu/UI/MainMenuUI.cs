using PingPong.Scripts.Root.Services;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.MainMenu.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _skinsPanel;
        [Inject] private LoadSceneService _loadSceneService;
        
        public void StartGame()
        {
           _loadSceneService.Load(2); 
        }

        public void OpenSkinsPanel()
        {
            _skinsPanel.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}