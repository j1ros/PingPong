using UnityEngine;

namespace PingPong.Scripts.Gameplay.StateMachine.State
{
    public class InitState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IGameInitable _ballMoveService;
        private readonly IGameInitable _enemyRacketService;
        private readonly IGameInitable _playerRacketService;

        public InitState(
            GameplayStateMachine gameplayStateMachine, 
            IGameInitable ballMoveService,
            IGameInitable enemyRacketService,
            IGameInitable playerRacketService
            )
        {
            _gameplayStateMachine = gameplayStateMachine;
            _ballMoveService = ballMoveService;
            _enemyRacketService = enemyRacketService;
            _playerRacketService = playerRacketService;
        }
        
        public void Enter()
        {
            Time.timeScale = 1f;
            
            _ballMoveService.Init();
            _enemyRacketService.Init();
            _playerRacketService.Init();
            
            _gameplayStateMachine.Enter<GameLoopState>();
        }
    }
}