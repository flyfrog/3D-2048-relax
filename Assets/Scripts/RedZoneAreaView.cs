using System;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
public class RedZoneAreaView: MonoBehaviour
{
    [SerializeField] private float _speedPulse; 
    [SerializeField] private float _speedHideRedPanel;

    private MeshRenderer _redZoneMeshRenderer;
    private float _currentAlphaForRedZoneRendererMaterialColor = 0f;
    private bool _pulsationFlag = false;
    private Color _startColorRedZoneMaterial;
    public event Action OnCubeInRedZoneEvent;
    

    private void Start()
    {
        _redZoneMeshRenderer = GetComponent<MeshRenderer>();
        _startColorRedZoneMaterial = _redZoneMeshRenderer.material.color;
        RedPanelHide();
    }

    private void Update()
    {
        RedZonePulsation();
    }

    private void RedZonePulsation()
    {
        if (_pulsationFlag)
        {
            _currentAlphaForRedZoneRendererMaterialColor = Mathf.PingPong(Time.time * _speedPulse, 1);
        }

        if (!_pulsationFlag)
        {
            if (_currentAlphaForRedZoneRendererMaterialColor > 0)
            {
                _currentAlphaForRedZoneRendererMaterialColor -= Time.deltaTime * _speedHideRedPanel;
                _currentAlphaForRedZoneRendererMaterialColor = Mathf.Clamp01(_currentAlphaForRedZoneRendererMaterialColor);
            }
        }

        DrawRedZonePulsationColorChanging();
    }

    private void DrawRedZonePulsationColorChanging()
    {
        Color color = _startColorRedZoneMaterial;
        color.a = _currentAlphaForRedZoneRendererMaterialColor;
        _redZoneMeshRenderer.material.color = color;
    }


    private void OnTriggerStay(Collider other)
    {
        CubeView cubeView = other.GetComponent<CubeView>();

        if (cubeView == null)
            return;

        if (cubeView.isMainCube)
            return;

        OnCubeInRedZoneEvent?.Invoke();
    }

    public void RedPanelShow()
    {
        _pulsationFlag = true;
        _currentAlphaForRedZoneRendererMaterialColor = 0f;
    }

    public void RedPanelHide()
    {
        _pulsationFlag = false;
        
    }
}
