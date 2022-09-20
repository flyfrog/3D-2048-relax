using System;
using GameManagmentControllers;
using UnityEngine;
using Zenject;

public class InputConroller : ITickable
{
    public event Action SliderOnDown;
    public event Action SliderOnUp;
    
    private float _positionPlayerPointerX;
    private Camera _camera;
    private PauseController _pauseController;
    private float _halfVerticalSizeScreen;
    private float _screenWidth;

    [Inject]
    public InputConroller(PauseController pauseControllerArg)
    {
        _camera = Camera.main;
        _pauseController = pauseControllerArg;
        _halfVerticalSizeScreen = Screen.height / 2f;
        _screenWidth = Screen.width;
    }

    public void Tick()
    {
        if (_pauseController.GetPauseState())
            return;
        
        if (Input.GetMouseButtonUp(0))
        {
            OnUp();
        }

        if(CheckInputInForbiddenScreenArea())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            OnDown();
        }
    }

 
 
    public float GetClamp01Pointerposition()
    {
        float pointerX=0.5f; // 0.5 middle position for Lerp 
        float mouseXPosition = Input.mousePosition.x;

        pointerX = 1 / ( _screenWidth / mouseXPosition);
        return pointerX;
    }


    public void OnDown()
    {
        SliderOnDown?.Invoke();
    }

    public void OnUp()
    {
        SliderOnUp?.Invoke();
    }

    private bool CheckInputInForbiddenScreenArea()
    {
        if (Input.mousePosition.y > _halfVerticalSizeScreen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}