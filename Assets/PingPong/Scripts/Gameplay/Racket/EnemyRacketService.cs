using System;
using PingPong.Scripts.Gameplay.Ball;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Racket
{
    public class EnemyRacketService : IGameInitable
    {
        [Inject] private BallMove _ballMove;
        
        public Vector3 GetVelocity(Transform transform)
        {
            Vector3 position = transform.position;
            Vector3 targetPosition = new Vector3(_ballMove.transform.position.x, position.y, position.z);
            
            float deltaX = targetPosition.x - position.x;
            
            return Vector3.right * (deltaX / Time.fixedDeltaTime);
        }

        public Action OnInit { get; set; }
        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}