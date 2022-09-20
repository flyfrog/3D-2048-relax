using SO;
using UI;
using UnityEngine;

using Zenject;

public class RedZoneCubeDetector: ITickable
{
    private GameOverController _gameOverController;
    private RedZoneAreaView _redZoneAreaUiViewer;
    private float _timerRedZoneCurrentTime = 0f;
    private bool _cubeInRedZoneFlag;
    private float _redZoneGameOverCurrentTimer;
    private float _timerRedZoneForSet;
    private float _redZoneGameOverTime;

    private RedZoneUITimeTextView _redZoneUITimeTextView; 
    
    [Inject]
    public RedZoneCubeDetector(RedZoneAreaView redZoneAreaUIArg, GameOverController gameOverControllerArg, GameSettingsSO gameSettingsSoArg, RedZoneUITimeTextView redZoneUITimeTextViewArg)
    {
        
        _redZoneAreaUiViewer = redZoneAreaUIArg;
        _gameOverController = gameOverControllerArg;
        _timerRedZoneForSet = gameSettingsSoArg.timerRedZoneForSet;
        _redZoneGameOverTime = gameSettingsSoArg.redZoneGameOverTime;
        _redZoneUITimeTextView = redZoneUITimeTextViewArg;
        _redZoneAreaUiViewer.OnCubeInRedZoneEvent += RedZoneAreaHasCube;
    }



    public void Tick()
    {
        RedZoneNoCubeCheker();
    }


    private void RedZoneNoCubeCheker()
    {
        if (_timerRedZoneCurrentTime > 0)
        {
            _timerRedZoneCurrentTime -= Time.deltaTime;
        }
        else
        {
            CubeInRedZoneFlagSetter(false);
            _redZoneGameOverCurrentTimer = 0f;
            _redZoneUITimeTextView.HideText();
        }
    }


    private void RedZoneAreaHasCube()
    {
        _timerRedZoneCurrentTime = _timerRedZoneForSet;
        CubeInRedZoneFlagSetter(true);

        if (_redZoneGameOverCurrentTimer < _redZoneGameOverTime)
        {
            _redZoneGameOverCurrentTimer += Time.deltaTime;
            _redZoneUITimeTextView.ShowText();
            float difTime = _redZoneGameOverTime - _redZoneGameOverCurrentTimer;
            _redZoneUITimeTextView.DrawText(difTime);
        }
        else
        {
            GameOverRedZoneTimeLoose();
        }
    }


    private void CubeInRedZoneFlagSetter(bool flagArg)
    {
        if (_cubeInRedZoneFlag == flagArg)
            return;

        _cubeInRedZoneFlag = flagArg;

        if (_cubeInRedZoneFlag == true)
        {
            TurnOnRedZoneEffect();
        }

        if (_cubeInRedZoneFlag == false)
        {
            TurnOffRedZoneEffect();
        }
    }


    private void TurnOnRedZoneEffect()
    {
        _redZoneAreaUiViewer.RedPanelShow();
    }

    private void TurnOffRedZoneEffect()
    {
        _redZoneAreaUiViewer.RedPanelHide();
    }


    private void GameOverRedZoneTimeLoose()
    {
        _redZoneUITimeTextView.HideText();
        _gameOverController.GameOver();
    }

  
}