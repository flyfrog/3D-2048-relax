using Sound;
using Zenject;

namespace UI
{
    public class HeaderUIController
    {
        private HeaderUIView _headerUIView;
        private MenuUIController _menuUIController;
        private ScoreController _scoreController;
        private UISoundController _UISoundController;
    
        [Inject]
        public HeaderUIController(HeaderUIView headerUIViewArg, MenuUIController menuUIControllerArg, ScoreController scoreControllerArg, UISoundController uiSoundControllerArg)
        {
            _headerUIView = headerUIViewArg;
            _menuUIController = menuUIControllerArg;
            _scoreController = scoreControllerArg;
            _UISoundController = uiSoundControllerArg;

            _headerUIView.onClickButtonOpenMenuEvent += ClickOpenMenuPanel;
            _scoreController.onScoreChangedEvent += RefreshScoreText;
        }

        private void RefreshScoreText(int score)
        {
            _headerUIView.SetScoreText(score);
        }
    
        private void ClickOpenMenuPanel()
        {
            _UISoundController.PlayClick();
            _menuUIController.OpenMenuPanel(); 
        }


    }
}