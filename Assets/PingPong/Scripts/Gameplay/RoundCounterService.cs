using PingPong.Scripts.Gameplay.StateMachine;
using PingPong.Scripts.Gameplay.StateMachine.State;
using PingPong.Scripts.Gameplay.UI;
using PingPong.Scripts.Root.Services;
using VContainer;

namespace PingPong.Scripts.Gameplay
{
    public class RoundCounterService
    {
        private const int MAX_ROUNDS_LOST = 2;
        [Inject] private GameplayStateMachine _gameplayStateMachine;
        [Inject] private GameplayUIController _gameplayUIController;
        [Inject] private ScoreService _scoreService;
        private int _currentPlayerPoints = 0;
        private int _currentEnemyPoints = 0;

        public void RestartRound()
        {
            _currentPlayerPoints = 0;
            _currentEnemyPoints = 0;
            _gameplayUIController.ChangeRoundScore(_currentPlayerPoints, _currentEnemyPoints);
        }
        
        public void RoundEnd(bool playerIsWin)
        {
            _scoreService.CurrentScore = 0;
            if (playerIsWin)
                _currentPlayerPoints++;
            else
                _currentEnemyPoints++;
            
            _gameplayUIController.ChangeRoundScore(_currentPlayerPoints, _currentEnemyPoints);
            if (_currentPlayerPoints == MAX_ROUNDS_LOST || _currentEnemyPoints == MAX_ROUNDS_LOST)
            {
                _gameplayStateMachine.Enter<EndState>();
            }
            else
            {
                _gameplayStateMachine.Enter<InitState>();
            }
        }
    }
}