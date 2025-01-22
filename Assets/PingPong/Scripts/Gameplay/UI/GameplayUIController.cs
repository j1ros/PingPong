using TMPro;
using UnityEngine;

namespace PingPong.Scripts.Gameplay.UI
{
    public class GameplayUIController : MonoBehaviour
    {
        [SerializeField] private GameObject _endPanel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private TextMeshProUGUI _roundScoreText;

        public void ChangeRoundScore(int playerScore, int enemyScore)
        {
            _roundScoreText.text = playerScore.ToString() + " : " + enemyScore.ToString();
        }
        
        public void PauseGame()
        {
            _pausePanel.SetActive(true);
        }
        
        public void ShowEndPanel()
        {
            _endPanel.SetActive(true);
        }
    }
}