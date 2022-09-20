using GameManagmentControllers;
using Sound;
using Zenject;

namespace UI
{
    public class GameOverController
    {

        private GameOverUIView _gameOverUIView;
        private ScoreController _scoreController;
        private PauseController _pauseController;
        private RestartController _restartController;
        private UISoundController _UISoundController;
    
        [Inject]
        public GameOverController(GameOverUIView gameOverUIViewArg, ScoreController scoreControllerArg, PauseController pauseControllerArg, RestartController restartControllerArg, UISoundController uiSoundControllerArg)
        {
            _gameOverUIView = gameOverUIViewArg;
            _scoreController = scoreControllerArg;
            _pauseController = pauseControllerArg;
            _restartController = restartControllerArg;
            _UISoundController = uiSoundControllerArg;
        
            _gameOverUIView.onClickRestartButtonEvent += OnClickRestart;
        }

        private void DrawScore()
        {
            int score = _scoreController.GetScore();
            _gameOverUIView.SetScoreText(score);
        }

        private void OpenGameOverPanel()
        {
            _UISoundController.PlayOpenPanel();
            _gameOverUIView.ShowGameOverPanel();
            DrawScore();
        }

    

        public void GameOver()
        {
            OpenGameOverPanel();
            _pauseController.PauseOn();
        }

        private void OnClickRestart()
        {
            _UISoundController.PlayClick();
            _restartController.RestartScene();
        }
    



    }
}