using UnityEngine;

namespace PingPong.Scripts.Gameplay.Racket
{
    public abstract class BaseRacket : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _startPos;
        public Vector3 Velocity => _rigidbody.linearVelocity;
        public float Magnitude => _rigidbody.linearVelocity.magnitude;
        
        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _startPos = transform.position;
        }

        protected void MoveToStartPosition()
        {
            transform.position = _startPos;
        }

        protected abstract Vector3 GetVelocity();
        
        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = GetVelocity();
        }

    }
}