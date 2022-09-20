using SO;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class PoolFX
    {
        private int _poolCount;
        private FXBoom _FxPrefab;

        private Pool<FXBoom> pool;
        private const string namePoolContainer = "FX_POOL_CONTAINER";

        [Inject]
        public PoolFX(FXPoolSettingsSO poolSettingArg)
        {
            _poolCount = poolSettingArg.poolCount;
            _FxPrefab = poolSettingArg.FxPrefab;
            GameObject poolContainer = new GameObject(namePoolContainer);
            pool = new Pool<FXBoom>(_FxPrefab, _poolCount, poolContainer.transform);
        }


        public FXBoom GetFreeFX()
        {
            return pool.GetFreeElement();
        }
    }
}