using System;

namespace PingPong.Scripts.Gameplay
{
    public interface IGameInitable
    {
        public Action OnInit { get; set; }
        public void Init();
    }
}