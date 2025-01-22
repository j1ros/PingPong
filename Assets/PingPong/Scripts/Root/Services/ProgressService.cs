using System;
using PingPong.Scripts.Root.Services.SaveLoadService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PingPong.Scripts.Root.Services
{
    public class ProgressService : IStartable
    {
        [Inject] private SaveLoadService.SaveLoadService _saveLoadService;
        private int _progress;
        public int CurrentProgressLevel { get; private set; }

        public int Progress
        {
            get => _progress;
            set
            {
                _progress += value;
                if (_progress >= 100)
                {
                    CurrentProgressLevel++;
                    _progress -= 100;
                }
                _saveLoadService.Save( -1, CurrentProgressLevel, _progress);
            }
        }
        
        public void Start()
        {
            _saveLoadService.OnLoaded += ProgressLoaded;
        }

        private void ProgressLoaded(ContainerSaveData data)
        {
            CurrentProgressLevel = data.ProgressLevel;
            Progress = data.Progress;
        }
    }
}