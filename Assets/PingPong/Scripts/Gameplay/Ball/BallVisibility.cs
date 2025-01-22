using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Ball
{
    public class BallVisibility : MonoBehaviour
    {
        [Inject] private RoundCounterService _roundCounterService;
        [SerializeField] private Transform _playerLostCheck;
        [SerializeField] private Transform _enemyLostCheck;
        
        private void OnBecameInvisible()
        {
            float ballToPlayerDistance = Vector3.Distance(_playerLostCheck.position, transform.position);
            float ballToEnemyDistance = Vector3.Distance(_enemyLostCheck.position, transform.position);
            _roundCounterService.RoundEnd(ballToPlayerDistance > ballToEnemyDistance ? true : false);
        }
    }
}