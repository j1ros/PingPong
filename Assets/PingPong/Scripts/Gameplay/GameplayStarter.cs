using PingPong.Scripts.Gameplay.StateMachine;
using PingPong.Scripts.Gameplay.StateMachine.State;
using PingPong.Scripts.Root.Services.SaveLoadService;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay
{
    public class GameplayStarter : MonoBehaviour
    {
        [Inject] private GameplayStateMachine _gameplayStateMachine;
        [Inject] private SaveLoadService _saveLoadService;

        private void Start()
        {
            _gameplayStateMachine.Enter<InitState>();
        }
    }
}