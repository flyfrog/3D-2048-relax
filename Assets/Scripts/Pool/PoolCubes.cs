using SO;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class PoolCubes  
    {
        private int _poolCount = 10;
        private CubeView _cubeViewPrefab;
        private const string namePoolContainer = "CUBES_POOL_CONTAINER";
  
        private Pool<CubeView> pool;
    
        [Inject]
        public PoolCubes(CubePoolSettingsSO cubePoolSettingsSoArg)
        {
        
            _poolCount = cubePoolSettingsSoArg.poolCount;
            _cubeViewPrefab = cubePoolSettingsSoArg.cubeViewPrefab;
            GameObject poolContainer = new GameObject(namePoolContainer);
            pool = new Pool<CubeView>(_cubeViewPrefab, _poolCount, poolContainer.transform);
        }


        public CubeView GetFreeCube()
        {
            return pool.GetFreeElement();
        }
    }
}