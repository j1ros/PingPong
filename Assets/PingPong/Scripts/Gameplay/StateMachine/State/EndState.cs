using PingPong.Scripts.Gameplay.Racket;
using PingPong.Scripts.Gameplay.UI;
using UnityEngine;

namespace PingPong.Scripts.Gameplay.StateMachine.State
{
    public class EndState : IState
    {
        private readonly GameplayUIController _gameplayUIController;
        private readonly PlayerRacketService _playerRacketService;
        
        public EndState(
            GameplayUIController gameplayUIController,
            PlayerRacketService playerRacketService
        )
        {
            _gameplayUIController = gameplayUIController;
            _playerRacketService = playerRacketService;
        }
        
        public void Enter()
        {
            Time.timeScale = 0f;

            _playerRacketService.IsEnable = false;
            _gameplayUIController.ShowEndPanel();
        }
    }
}