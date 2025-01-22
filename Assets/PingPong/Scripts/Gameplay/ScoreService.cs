using System;
using PingPong.Scripts.Gameplay.UI;
using PingPong.Scripts.Root.Services.SaveLoadService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PingPong.Scripts.Gameplay
{
    public class ScoreService : IStartable, IInitializable
    {
        [Inject] private SaveLoadService _saveLoadService;
        public Action ScoreChanged;
        private int _bestScore;
        public int BestScore => _bestScore;
        private int _currentScore;

        public int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                if (_currentScore > _bestScore)
                {
                    _bestScore = _currentScore;
                    _saveLoadService.Save(-1, -1, -1, _bestScore);
                }
                ScoreChanged?.Invoke();
            }
        }
        
        public void Start()
        {
            
        }

        private void SaveLoaded(ContainerSaveData data)
        {
            _bestScore = data.TheBestScore;
        }

        public void Initialize()
        {
            _saveLoadService.OnLoaded += SaveLoaded;
        }
    }
}