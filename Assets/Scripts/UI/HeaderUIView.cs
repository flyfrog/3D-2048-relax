using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeaderUIView : MonoBehaviour
    {
        [SerializeField] private Button _openMenuButton;
        [SerializeField] private Text _scoreText; 
    

        public event Action onClickButtonOpenMenuEvent;

        private void Start()
        {
            _openMenuButton.onClick.AddListener(OnClickButtonOpenMenu);
        }

        private void OnClickButtonOpenMenu()
        {  
            onClickButtonOpenMenuEvent?.Invoke();
        }

        public void SetScoreText(int scoreArg)
        {
            string scoreText = scoreArg.ToString();
            _scoreText.text = scoreText;
        }
    
    }
}