using PingPong.Scripts.Gameplay.Ball;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Racket
{
    public class PlayerRacket : BaseRacket
    {
        [Inject] private ScoreService _scoreService;
        [Inject] private PlayerRacketService _playerRacketService;

        protected override void Start()
        {
            _playerRacketService.OnInit += MoveToStartPosition;
            base.Start();
        }

        protected override Vector3 GetVelocity()
        {
            return _playerRacketService.GetVelocity((transform));
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out BallMove ball))
            {
                _scoreService.CurrentScore++;
            }
        }
    }
}