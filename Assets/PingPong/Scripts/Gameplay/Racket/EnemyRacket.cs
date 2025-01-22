using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Racket
{
    public class EnemyRacket : BaseRacket
    {
        [Inject] private EnemyRacketService _enemyRacketService;

        protected override void Start()
        {
            _enemyRacketService.OnInit += MoveToStartPosition;
            base.Start();
        }

        protected override Vector3 GetVelocity()
        {
            return _enemyRacketService.GetVelocity(transform);
        }
    }
}