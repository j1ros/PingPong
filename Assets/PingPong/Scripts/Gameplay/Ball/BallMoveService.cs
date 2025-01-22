using System;
using PingPong.Scripts.Gameplay.Racket;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PingPong.Scripts.Gameplay.Ball
{
    public class BallMoveService : IGameInitable
    {
        private const float SPEED = 5f;
        private const float DISPERSION = 0.2f;

        public Vector3 CalculateVelocity(Vector3 ballDirection, Collision collision, out float modifier)
        {
            modifier = 1f;
            Vector3 direction = ballDirection;
            
            if (collision.gameObject.TryGetComponent(out BaseRacket racket))
            {
                modifier = Mathf.Clamp(racket.Magnitude, 1f, 5f);
                direction += racket.Velocity;
            }
            direction.Normalize();

            ContactPoint contactPoint = collision.GetContact(0);

            Vector3 normalContactPoint = new Vector3(
                contactPoint.normal.x + Random.Range(-DISPERSION, DISPERSION),
                contactPoint.normal.y + Mathf.Sign(ballDirection.y) *Random.Range(0, DISPERSION),
                contactPoint.normal.z
            ).normalized;
            
            return Vector3.Reflect(direction, normalContactPoint) * SPEED;
        }

        public Vector3 GetStartVelocity()
        {
            return (Vector3.up * Random.Range(-1f, 1f) + Vector3.right * Random.Range(-0.2f, 0.2f)).normalized * SPEED;
        }

        public Action OnInit { get; set; }
        
        public void Init()
        {
            OnInit?.Invoke();
        }
    }
}