using Pool;
using SO;
using UnityEngine;
using Zenject;

public class CubeSpawner
{
    public int _maxCubeNumber;
    private int _maxPow = 12;
    private Vector3 _defaultSpawnPosition;

    private PoolCubes _cubePool;
    private MaterialListForCubes _materialListForCubes;
    private SpawnerCubePlace _spawnerCubePlace;

    [Inject]
    public CubeSpawner(PoolCubes poolCubesArg, MaterialListForCubes materialListForCubesArg,
        SpawnerCubePlace spawnerCubePlaceArg)
    {
        _cubePool = poolCubesArg;
        _materialListForCubes = materialListForCubesArg;
        _spawnerCubePlace = spawnerCubePlaceArg;

        _maxCubeNumber = (int)Mathf.Pow(2, _maxPow);
        _defaultSpawnPosition = _spawnerCubePlace.GetSpawnPlaceTransformPosition();
    }


    public CubeView Spawn(int number, Vector3 position)
    {
        CubeView newCubeView = _cubePool.GetFreeCube();
        newCubeView.transform.position = position;
        newCubeView.SetNumber(number);
        newCubeView.SetMaterial(GetMaterial(number));
        return newCubeView;
    }

    public CubeView SpawnRandom()
    {
        return Spawn(GenerateRandomNumber(), _defaultSpawnPosition);
    }

    public void DestroyCube(CubeView cubeArg)
    {
        cubeArg.Deactivate();
    }

    public int GenerateRandomNumber()
    {
        int randomPow = Random.Range(1, 6);
        return (int)Mathf.Pow(2, randomPow);
    }

    private Material GetMaterial(int number)
    {
        int index = (int)(Mathf.Log(number) / Mathf.Log(2)) - 1;
        return _materialListForCubes.MaterialAr[index];
    }
}