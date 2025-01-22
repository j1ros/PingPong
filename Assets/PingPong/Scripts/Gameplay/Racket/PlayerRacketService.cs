using System;
using UnityEngine;
using VContainer.Unity;

namespace PingPong.Scripts.Gameplay.Racket
{
    public class PlayerRacketService : IStartable, IGameInitable
    {
        private Camera _mainCamera;
        public bool IsEnable;
        
        public Vector3 GetVelocity(Transform transform)
        {
            if(!IsEnable)
                return transform.position;
            
            Vector3 mouseWorldPosition = _mainCamera != null? 
                _mainCamera.ScreenToWorldPoint(
                    new Vector3(
                        Input.mousePosition.x,
                        Input.mousePosition.y,
                        transform.position.z - _mainCamera.transform.position.z
                        )
                    )
                    : transform.position;
            Vector3 currentPos = transform.position;
            Vector3 targetPos = new Vector3(mouseWorldPosition.x, currentPos.y, currentPos.z);
            
            float deltaX = targetPos.x - currentPos.x;

            return Mathf.Abs(deltaX) > 0 ? Vector3.right * deltaX / Time.fixedDeltaTime : Vector3.zero;
        }


        void IStartable.Start()
        {
            _mainCamera = Camera.main;
        }

        public Action OnInit { get; set; }
        public void Init()
        {
            IsEnable = true;
            OnInit?.Invoke();
        }
    }
}