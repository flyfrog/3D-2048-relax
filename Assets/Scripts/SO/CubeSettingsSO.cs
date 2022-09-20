using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "CubeSettings", menuName = "GameSO/CubeSettingsSO")]
    public class CubeSettingsSO : ScriptableObject
    {
        public float jumpForce = 10f;
        public float moveForvardForce = 40f;
        public float rotationForce = 60;
    }
}