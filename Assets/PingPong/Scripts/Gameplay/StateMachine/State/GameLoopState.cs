using PingPong.Scripts.Gameplay.Racket;
using UnityEngine;

namespace PingPong.Scripts.Gameplay.StateMachine.State
{
    public class GameLoopState : IState
    {
        private readonly PlayerRacketService _playerRacketService;
        
        public GameLoopState(PlayerRacketService playerRacketService)
        {
            _playerRacketService = playerRacketService;
        }
        
        public void Enter()
        {
            Time.timeScale = 1f;
            _playerRacketService.IsEnable = true;
        }
    }
}