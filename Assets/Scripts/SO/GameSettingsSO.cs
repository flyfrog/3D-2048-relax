using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSO/GameSettingsSO")]
    public class GameSettingsSO : ScriptableObject
    {
        public float timerRedZoneForSet = 1f;
        public float redZoneGameOverTime = 5f;
    }
}