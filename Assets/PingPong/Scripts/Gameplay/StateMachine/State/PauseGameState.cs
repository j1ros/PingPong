using PingPong.Scripts.Gameplay.Racket;
using UnityEngine;

namespace PingPong.Scripts.Gameplay.StateMachine.State
{
    public class PauseGameState : IState
    {
        private readonly PlayerRacketService _playerRacketService;

        public PauseGameState(
            PlayerRacketService playerRacketService
            )
        {
            _playerRacketService = playerRacketService;
        }
        public void Enter()
        {
            Time.timeScale = 0;
            _playerRacketService.IsEnable = false;
        }
    }
}