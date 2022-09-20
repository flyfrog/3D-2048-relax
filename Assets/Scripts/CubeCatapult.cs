using ModestTree;
using Sound;
using UnityEngine;
using Zenject;

public class CubeCatapult : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] Transform leftBorder;
    [SerializeField] Transform rightBorder;

    private CubeView _mainCubeView;
    private bool _isPointerDown;
    private Vector3 _cubePosition;
    private InputConroller _inputConrollerSystem;
    private bool _canClick;
    private CubeSpawner _cubeSpawner;
    private CubeSoundController _cubeSound;
    private float _timePauseBetweenSpawnCubes = 0.4f;

    private float _minXPositionForCubeDraging;
    private float _maxXPositionForCubeDraging;

    [Inject]
    private void Construct(CubeSoundController cubeSoundArg, CubeSpawner cubeSpawnerArg,
        InputConroller inputConrollerArg)
    {
        _cubeSound = cubeSoundArg;
        _cubeSpawner = cubeSpawnerArg;
        _inputConrollerSystem = inputConrollerArg;
    }


    private void Start()
    {
        SpawnCube();
        _canClick = true;
        _inputConrollerSystem.SliderOnDown += OnPointerDown;
        _inputConrollerSystem.SliderOnUp += OnPointerUp;
        MathMinAndMaxValueXPositionForCube();
    }

    private void Update()
    {
        DragCube(_inputConrollerSystem.GetClamp01Pointerposition());
    

        MoveCube();
    }

    private void MoveCube()
    {
        if (_isPointerDown) // эта проверка двойная она под вопросом
        {
            _mainCubeView.transform.position = Vector3.Lerp(
                _mainCubeView.transform.position,
                _cubePosition,
                _moveSpeed * Time.deltaTime);
        }
    }


    private void OnPointerDown()
    {
        _isPointerDown = true;
    }
 

    private void DragCube(float Clamp01PointerXPositionValue)
    {
        if (_isPointerDown)
        {
            _cubePosition = _mainCubeView.transform.position;

            float newXPositionForCube = Mathf.Lerp( _minXPositionForCubeDraging, _maxXPositionForCubeDraging, Clamp01PointerXPositionValue);
            _cubePosition.x = newXPositionForCube;
        }
    }


    private void OnPointerUp()
    {
        if (_isPointerDown && _canClick)
        {
            _isPointerDown = false;
            _canClick = false;

            ShotCube();
            Invoke(nameof(SpawnNewCube), _timePauseBetweenSpawnCubes);
        }
    }

    private void ShotCube()
    {
        _mainCubeView.MoveForward();
        _cubeSound.PlaySlide();
    }


    private void SpawnNewCube()
    {
        _mainCubeView.isMainCube = false;
        _canClick = true;
        SpawnCube();
    }

    private void SpawnCube()
    {
        _mainCubeView = _cubeSpawner.SpawnRandom();
        _mainCubeView.isMainCube = true;
        _cubePosition = _mainCubeView.transform.position;
        _cubeSound.PlaySpawn();
    }

    private void MathMinAndMaxValueXPositionForCube()
    {
        float halfWidthCube = _mainCubeView.transform.localScale.x / 2f;
        _maxXPositionForCubeDraging = rightBorder.position.x - halfWidthCube;
        _minXPositionForCubeDraging = leftBorder.position.x + halfWidthCube;
    }

    private void OnDestroy()
    {
        _inputConrollerSystem.SliderOnDown -= OnPointerDown;
        _inputConrollerSystem.SliderOnUp -= OnPointerUp;
    }
}