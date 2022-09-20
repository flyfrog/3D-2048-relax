using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "CubePoolSettings", menuName = "GameSO/CubePoolSettingsSO")]
    public class CubePoolSettingsSO : ScriptableObject
    {
        public int poolCount = 10;
        public CubeView cubeViewPrefab;
    }
}