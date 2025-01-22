using System;
using PingPong.Scripts.Root.Services;
using TMPro;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        [Inject] private ScoreService _scoreService;

        private void Start()
        {
            _scoreService.ScoreChanged += ChangeScore;
            _bestScoreText.text = _scoreService.BestScore.ToString();
            _currentScoreText.text = "0";
        }

        private void ChangeScore()
        {
            _currentScoreText.text = _scoreService.CurrentScore.ToString();
            _bestScoreText.text = _scoreService.BestScore.ToString();
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= ChangeScore;
        }
    }
}