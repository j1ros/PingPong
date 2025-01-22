using DG.Tweening;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Ball
{
    public class BallMove : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _startPosition;
        private Vector3 _velocity;
        private Vector3 _targetVelocity;
        private float _currentSpeedMod = 1f;
        private Sequence _sequence;
        [Inject] private BallMoveService _ballMoveService;
        private Vector3 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                _rigidbody.linearVelocity = _velocity;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _startPosition = transform.position;

            _ballMoveService.OnInit += InitializeMovement;
        }

        private void InitializeMovement()
        {
            _sequence.Kill();
            transform.position = _startPosition;
            
            Velocity = _ballMoveService.GetStartVelocity();
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(_currentSpeedMod - 1f) > 0.1f)
            {
                Velocity = _targetVelocity * _currentSpeedMod;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            _targetVelocity = _ballMoveService.CalculateVelocity(Velocity, collision, out float modifier);
            Velocity = _targetVelocity;
            
            if (Mathf.Abs(modifier - 1f) > 0.1f)
            {
                _sequence = DOTween.Sequence();
                _sequence.Append(DOVirtual.Float(modifier, 1f, 1f, m => _currentSpeedMod = m));
            }
        }
    }
}