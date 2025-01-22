using PingPong.Scripts.Gameplay.StateMachine;
using PingPong.Scripts.Gameplay.StateMachine.State;
using PingPong.Scripts.Root.Services;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.UI
{
    public class PausePanelController : MonoBehaviour
    {
        [Inject] private GameplayStateMachine _gameplayStateMachine;
        [Inject] private LoadSceneService _loadSceneService;

        private void OnEnable()
        {
            _gameplayStateMachine.Enter<PauseGameState>();
        }

        public void ResumeGame()
        {
            _gameplayStateMachine.Enter<GameLoopState>();
            gameObject.SetActive(false);
        }

        public void ExitGame()
        {
            _loadSceneService.Load(1);
        }
    }
}