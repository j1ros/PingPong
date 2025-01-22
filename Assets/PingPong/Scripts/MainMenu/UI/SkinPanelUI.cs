using System;
using System.Collections.Generic;
using PingPong.Scripts.Root.Services.Skin;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.MainMenu.UI
{
    public class SkinPanelUI : MonoBehaviour
    {
        [Inject] private SkinService _skinService;
        [SerializeField] private SkinUI _skinUIPrefab;
        [SerializeField] private Transform _parentTransform;
        private List<SkinUI> _skinsUI = new List<SkinUI>();

        private void Awake()
        {
            SkinSO[] skinsSO = Resources.LoadAll<SkinSO>("Skins");
            
            foreach (var skinSO in skinsSO)
            {
                SkinUI skinUiElement = Instantiate(_skinUIPrefab, _parentTransform);
                skinUiElement.Initialize(skinSO, _skinService.GetOpenStatusSkin(skinSO));
                skinUiElement.ChangeSkin += SkinChanged;
                _skinsUI.Add(skinUiElement);
            }
        }

        private void OnEnable()
        {
            foreach (var skinUI in _skinsUI)
            {
                skinUI.SetActiveStatus(_skinService.GetOpenStatusSkin(skinUI.Skin));
                if (skinUI.Skin.Id != _skinService.ActiveSkin.Id)
                {
                    skinUI.Clear();
                }
                else
                {
                    skinUI.ChooseSkin(false);
                }
            }
        }

        private void SkinChanged(SkinUI activatedSkinUI)
        {
            foreach (var skinUI in _skinsUI)
            {
                if(skinUI.Skin.Id != activatedSkinUI.Skin.Id)
                    skinUI.Clear();
            }
            _skinService.SetActiveSkin(activatedSkinUI.Skin, true);
        }

        public void CloseSkinPanel()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            foreach (var skinUiElement in _skinsUI)
            {
                skinUiElement.ChangeSkin -= SkinChanged;
            }
        }
    }
}