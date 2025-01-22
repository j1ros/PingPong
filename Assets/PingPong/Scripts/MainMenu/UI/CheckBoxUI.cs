using UnityEngine;

namespace PingPong.Scripts.MainMenu.UI
{
    public class CheckBoxUI : MonoBehaviour
    {
        [SerializeField] private GameObject _checkBoxMarker;

        public void Toggle(bool value)
        {
            _checkBoxMarker.SetActive(value);
        }
    }
}