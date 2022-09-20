using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ExplosionSettings", menuName = "GameSO/ExplosionSettingsSO")]
    public class ExplosionSettingsSO : ScriptableObject
    {
        public float explositionForse = 200f;
        public float explositionRadius = 3.5f;
    }
}