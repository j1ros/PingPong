using System;
using VContainer;

namespace PingPong.Scripts.Root.Services.SaveLoadService
{
    public class SaveLoadService
    {
        [Inject] private ISave _saveService;
        public Action<ContainerSaveData> OnLoaded;
        private int _activeSkinId;
        private int _progressLevel;
        private int _progress;
        private int _theBestScore;
        public void Save(int activeSkinId = -1, int progressLevel = -1, int progress = -1, int theBestScore = -1)
        {
            if (activeSkinId != -1)
            {
                _activeSkinId = activeSkinId;
            }
            if (progressLevel != -1)
            {
                _progressLevel = progressLevel;
            }
            if (progress != -1)
            {
                _progress = progress;
            }
            if (theBestScore != -1)
            {
                _theBestScore = theBestScore;
            }
            
            ContainerSaveData saveData = new ContainerSaveData(_activeSkinId, _progressLevel, _progress, _theBestScore);
            _saveService.Save("save", saveData);
        }

        public void Load()
        {
            ContainerSaveData loadedData = _saveService.Load("save");
            OnLoaded?.Invoke(loadedData);
        }
    }
}