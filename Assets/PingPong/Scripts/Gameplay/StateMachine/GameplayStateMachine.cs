using System;
using System.Collections.Generic;
using PingPong.Scripts.Gameplay.Ball;
using PingPong.Scripts.Gameplay.Racket;
using PingPong.Scripts.Gameplay.StateMachine.State;
using PingPong.Scripts.Gameplay.UI;

namespace PingPong.Scripts.Gameplay.StateMachine
{
    public class GameplayStateMachine
    {
        private IState _currentState;
        private readonly Dictionary<Type, IState> _states;

        public GameplayStateMachine(
            BallMoveService ballMoveService,
            PlayerRacketService playerRacketService,
            EnemyRacketService enemyRacketService,
            GameplayUIController gameplayUIController
        )
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(InitState)] = new InitState(
                        this,
                        ballMoveService,
                        enemyRacketService,
                        playerRacketService
                    ),
                [typeof(GameLoopState)] = new GameLoopState(
                        playerRacketService
                    ),
                [typeof(PauseGameState)] = new PauseGameState(
                        playerRacketService
                    ),
                [typeof(EndState)] = new EndState(
                        gameplayUIController,
                        playerRacketService
                    )
            };
        }

        public void Enter<TState>()
        {
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}