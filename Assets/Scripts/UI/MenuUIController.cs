using GameManagmentControllers;
using Sound;
using Zenject;

namespace UI
{
    public class MenuUIController
    {
        private MenuUiView _menuUiView;
        private AudioMixerController _audioMixerController;
        private RestartController _restartController;
        private PauseController _pauseController;
        private UISoundController _UISoundController;
        private ExitController _exitController;
            

        [Inject]
        public MenuUIController(MenuUiView menuUiViewArg, AudioMixerController audioMixerControllerArg,
            RestartController restartControllerArg, PauseController pauseControllerArg, UISoundController uiSoundControllerArg, ExitController exitControllerArg)
        {
            _menuUiView = menuUiViewArg;
            _audioMixerController = audioMixerControllerArg;
            _restartController = restartControllerArg;
            _pauseController = pauseControllerArg;
            _UISoundController = uiSoundControllerArg;
            _exitController = exitControllerArg;

            _menuUiView.onClickButtonBackInGameEvent += BackInGame;
            _menuUiView.onClickButtonExitGameEvent += ExitGame;
            _menuUiView.onClickButtonStartNewGameEvent += StartNewGame;
            _menuUiView.onClickButtonSoundChangeEvent += ChangeSoundState;
            _audioMixerController.OnChangedMuteState += DrawMuteState;
        }

        private void StartNewGame()
        {
            _UISoundController.PlayClick();
            _restartController.RestartScene();
        }

        private void ExitGame()
        {
            _UISoundController.PlayClick();
            _exitController.ExitGame();
        }

        private void BackInGame()
        {
            _UISoundController.PlayClick();
            _pauseController.PauseOff();
            CloseMenuPanel();
        }


        private void ChangeSoundState()
        {
            _UISoundController.PlayClick();
            _audioMixerController.SwitchMuteState();
        }

        public void DrawMuteState()
        {
            bool soundMuteState = _audioMixerController.GetMuteState();
            _menuUiView.SetSoundStatusText(soundMuteState);
        }


        public void OpenMenuPanel()
        {
            _UISoundController.PlayOpenPanel();
            _pauseController.PauseOn();
            _menuUiView.ShowMenuPanel();
        }

        public void CloseMenuPanel()
        {
            _UISoundController.PlayOpenPanel();
            _menuUiView.HideMenuPanel();
        }
    }
}