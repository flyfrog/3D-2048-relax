using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "DuckSettingsSO", menuName = "GameSO/DuckSettingsSO")]
    public class DuckSettingsSO : ScriptableObject
    {
        public float rotationSpeed = 2f;
        public float movingSpeed = 0.65f;
    }
}