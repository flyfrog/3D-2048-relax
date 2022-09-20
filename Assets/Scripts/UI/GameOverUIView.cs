using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverUIView : MonoBehaviour
    {
        [SerializeField] private Transform _gameOverPanel;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Button _restartButton;
    
        public event Action onClickRestartButtonEvent;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnclickRestartGameButton);
        }

        private void OnclickRestartGameButton()
        {
            onClickRestartButtonEvent?.Invoke();
        }

        public void SetScoreText(int scoreArg)
        {
            string scoreText = scoreArg.ToString();
            _scoreText.text = scoreText;
        }
    
        public void ShowGameOverPanel()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    
        public void HideGameOverPanel()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }
    
    }
}