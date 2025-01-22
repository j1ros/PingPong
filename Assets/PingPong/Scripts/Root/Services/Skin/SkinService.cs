using PingPong.Scripts.Root.Services.SaveLoadService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PingPong.Scripts.Root.Services.Skin
{
    public class SkinService : IStartable
    {
        public SkinSO ActiveSkin { get; private set; }
        private SkinSO[] _skins;
        [Inject] private SaveLoadService.SaveLoadService _saveLoadService;
        [Inject] private ProgressService _progressService;
        
        public void Start()
        {
            _skins = Resources.LoadAll<SkinSO>("Skins");

            _saveLoadService.OnLoaded += ChangeActiveSkin;
            _saveLoadService.Load();
        }
        
        public void SetActiveSkin(SkinSO skin, bool save)
        {
            ActiveSkin = skin;
            if (save)
            {
                _saveLoadService.Save(ActiveSkin.Id);
            }
        }

        public bool GetOpenStatusSkin(SkinSO skin)
        {
            return _progressService.CurrentProgressLevel >= skin.ProgressLevel;
        }

        private void ChangeActiveSkin(ContainerSaveData obj)
        {
            foreach (var skin in _skins)
            {
                if (skin.Id == obj.ActiveSkinId)
                {
                    SetActiveSkin(skin, false);
                }
            }
        }

    }
}