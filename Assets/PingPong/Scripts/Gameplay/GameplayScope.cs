using PingPong.Scripts.Gameplay.Ball;
using PingPong.Scripts.Gameplay.Racket;
using PingPong.Scripts.Gameplay.StateMachine;
using PingPong.Scripts.Gameplay.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PingPong.Scripts.Gameplay
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private BallMove _ballMove;
        [SerializeField] private GameplayUIController _gameplayUIController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_ballMove);
            builder.RegisterComponent(_gameplayUIController);
            builder.RegisterEntryPoint<PlayerRacketService>().AsSelf();
            builder.RegisterEntryPoint<EnemyRacketService>().AsSelf();
            builder.Register<BallMoveService>(Lifetime.Singleton);
            builder.Register<GameplayStateMachine>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RoundCounterService>().AsSelf();
        }
    }
}