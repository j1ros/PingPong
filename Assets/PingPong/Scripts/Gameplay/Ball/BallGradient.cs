using DG.Tweening;
using UnityEngine;

namespace PingPong.Scripts.Gameplay.Ball
{
    public class BallGradient : MonoBehaviour
    {
        private static readonly int _hitPosition = Shader.PropertyToID("_position");
        private static readonly int _hardness = Shader.PropertyToID("_hardness");
        private Material _material;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        private void OnCollisionEnter(Collision other)
        {
            _material.SetVector(_hitPosition, other.contacts[0].point - transform.position);
            Sequence sequence = DOTween.Sequence();

            sequence.Append(
                    DOVirtual.Float(1, 0.2f, 0.3f, hardness => _material.SetFloat(_hardness, hardness))
                )
                .Append(
                    DOVirtual.Float(0.2f, 1, 0.3f, hardness => _material.SetFloat(_hardness, hardness))
                )
                .SetEase(Ease.Linear);
        }
    }
}