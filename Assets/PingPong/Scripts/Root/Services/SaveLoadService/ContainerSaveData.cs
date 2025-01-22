using System;

namespace PingPong.Scripts.Root.Services.SaveLoadService
{
    [Serializable]
    public class ContainerSaveData
    {
        public int ActiveSkinId;
        public int ProgressLevel;
        public int Progress;
        public int TheBestScore;

        public ContainerSaveData(int activeSkinId, int progressLevel, int progress, int theBestScore)
        {
            ActiveSkinId = activeSkinId;
            ProgressLevel = progressLevel;
            Progress = progress;
            TheBestScore = theBestScore;
        }
    }
}