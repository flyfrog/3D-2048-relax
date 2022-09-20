using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "FXPoolSettings", menuName = "GameSO/FXPoolSettingsSO")]
    public class FXPoolSettingsSO : ScriptableObject
    {
        public int poolCount = 10;
        public FXBoom FxPrefab;
    }
}