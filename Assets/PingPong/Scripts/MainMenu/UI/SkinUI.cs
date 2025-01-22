using System;
using PingPong.Scripts.Root.Services.Skin;
using TMPro;
using UnityEngine;

namespace PingPong.Scripts.MainMenu.UI
{
    public class SkinUI : MonoBehaviour
    {
        public Action<SkinUI> ChangeSkin;
        public SkinSO Skin { get; private set; }
        private bool _isOpen = false;
        [SerializeField] private CheckBoxUI _checkBox;
        [SerializeField] private TextMeshProUGUI _colorText;
        [SerializeField] private TextMeshProUGUI _textureText;
        [SerializeField] private TextMeshProUGUI _meshText;
        [SerializeField] private GameObject _isClosePanel;
        
        public void Initialize(SkinSO skinSo, bool isOpen)
        {
            Skin = skinSo;
            _checkBox.Toggle(false);
            _colorText.text = skinSo.Color.ToString();
            _textureText.text = skinSo.Texture.name;
            _meshText.text = skinSo.Mesh.name;
            
            _isOpen = isOpen;
            _isClosePanel.SetActive(!_isOpen);
        }

        public void ChooseSkin(bool save)
        {
            _checkBox.Toggle(true);
            if (save)
                ChangeSkin?.Invoke(this);
        }

        public void Clear()
        {
            _checkBox.Toggle(false);
        }

        public void SetActiveStatus(bool getOpenStatusSkin)
        {
            _isOpen = getOpenStatusSkin;
            _isClosePanel.SetActive(!_isOpen);
        }
    }
}