using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuUiView : MonoBehaviour
    {
        [SerializeField] private Transform _menuPanelContainer;
        [Space] 
        [SerializeField] private Button _returnInGameButton;
        [SerializeField] private Button _startNewGameButton;
        [Space] 
        [SerializeField] private Button _soundButton;
        [SerializeField] private Text _soundStatusText;
        [Space] 
        [SerializeField] private Button _exitGameButton;
        
        public event Action onClickButtonBackInGameEvent;
        public event Action onClickButtonStartNewGameEvent;
        public event Action onClickButtonExitGameEvent;
        public event Action onClickButtonSoundChangeEvent;
        
        private const string SOUND_MUTE_STATUS_TRUE = "Sound: OFF";
        private const string SOUND_MUTE_STATUS_FALSE = "Sound: ON";

        private void Start()
        {
            _startNewGameButton.onClick.AddListener(OnClickButtonStartNewGame);
            _exitGameButton.onClick.AddListener(OnClickButtonExitGame);
            _returnInGameButton.onClick.AddListener(OnClickButtonBackInGame);
            _soundButton.onClick.AddListener(OnClickButtonSoundChange);
        }

        public void SetSoundStatusText(bool statusArg)
        {
            if (statusArg)
            {
                _soundStatusText.text = SOUND_MUTE_STATUS_TRUE;
            }
            else
            {
                _soundStatusText.text = SOUND_MUTE_STATUS_FALSE;
            }
        }


        private void OnClickButtonSoundChange()
        {
            onClickButtonSoundChangeEvent?.Invoke();
        }

        private void OnClickButtonBackInGame()
        {
            onClickButtonBackInGameEvent?.Invoke();
        }

        private void OnClickButtonExitGame()
        {
            onClickButtonExitGameEvent?.Invoke();
        }

        private void OnClickButtonStartNewGame()
        {
            onClickButtonStartNewGameEvent?.Invoke();
        }

        public void ShowMenuPanel()
        {
            _menuPanelContainer.gameObject.SetActive(true);
        }

        public void HideMenuPanel()
        {
            _menuPanelContainer.gameObject.SetActive(false);
        }
    }
}