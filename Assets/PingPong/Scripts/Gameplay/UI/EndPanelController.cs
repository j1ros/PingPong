using PingPong.Scripts.Gameplay.StateMachine;
using PingPong.Scripts.Gameplay.StateMachine.State;
using PingPong.Scripts.Root.Services;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.UI
{
    public class EndPanelController : MonoBehaviour
    {
        [Inject] private LoadSceneService _loadSceneService;
        [Inject] private GameplayStateMachine _gameplayStateMachine;
        [Inject] private RoundCounterService _roundCounterService;
        [Inject] private ProgressService _progressService;

        public void Restart()
        {
            _gameplayStateMachine.Enter<InitState>();
            _roundCounterService.RestartRound();
            
            gameObject.SetActive(false);
        }
        
        public void Exit()
        {
            _loadSceneService.Load(1);
        }
    }
}