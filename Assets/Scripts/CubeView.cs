using SO;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(Rigidbody))]
public class CubeView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _numbersText;
    [SerializeField] private MeshRenderer _cubeMeshRenderer;

    
    [SerializeField] private CubeSettingsSO cubeSettingsSO;
    
    [HideInInspector]
    public bool isMainCube; // !!!!!!!!! убрать флаг в старт зоне сделать проверку через сам куб на другой куб 

    private int _number; // !!!!!!!!! делать метод получения цифры и метод установки 
    private CubeCollision _cubeCollision;
    private Rigidbody _rigidBody; // !!!!!!!!! убрать  место где вызывается и перенести add forece сюда 

    private float _jumpForce;
    private float _moveForvardForce;
    private float _rotationForce;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _jumpForce = cubeSettingsSO.jumpForce;
        _moveForvardForce = cubeSettingsSO.moveForvardForce;
        _rotationForce = cubeSettingsSO.rotationForce;
        _cubeCollision = FindObjectOfType<CubeCollision>(); // !!!!!!!!!
    }


    public void SetMaterial(Material matArg)
    {
        _cubeMeshRenderer.material = matArg;
    }

    public void SetNumber(int number)
    {
        _number = number;
        DrawTextNumberOnSides(number);
    }

    private void DrawTextNumberOnSides(int number)
    {
        for (int i = 0; i < 6; i++)
        {
            _numbersText[i].text = number.ToString();
        }
    }

    public int GetNumber()
    {
        return _number;
    }


    public void Deactivate()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        isMainCube = false;
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<CubeView>())
        {
            _cubeCollision.OnCollisionTwoCubes(this, other.gameObject.GetComponent<CubeView>(), other.contacts[0].point,
                other);
        }
    }

    public void MoveForward()
    {
        _rigidBody.AddForce(Vector3.forward * _moveForvardForce, ForceMode.Impulse);
    }

    public void JumpUp()
    {
        _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        float randomValue = Random.Range(-_rotationForce, _rotationForce);
        Vector3 randomDirection = Vector3.one * randomValue;
        _rigidBody.AddTorque(randomDirection);
    }
 
}


