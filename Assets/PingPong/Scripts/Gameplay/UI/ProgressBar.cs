using PingPong.Scripts.Root.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace PingPong.Scripts.Gameplay.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [Inject] private ProgressService _progressService;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TextMeshProUGUI _progressText;

        private void OnEnable()
        {
            int currentProgress = Random.Range(1, 100);
            _progressService.Progress = currentProgress;
            _progressText.text = "+" + currentProgress;
            _progressImage.fillAmount = (float)currentProgress / 100f;
        }
    }
}