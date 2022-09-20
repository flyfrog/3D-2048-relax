 
using Pool;
using SO;
using UnityEngine;
using Zenject;

public class FXSpawner  
{
    private PoolFX _poolFX;
    private MaterialListForCubes _materialListForCubes;

    [Inject]
    public FXSpawner(MaterialListForCubes materialListForCubesArg, PoolFX poolFXArg)
    {
        _materialListForCubes = materialListForCubesArg;
        _poolFX = poolFXArg;
    }

    public void SpawnFXBoomParticleSystem(Vector3 position, int cubeNumber)
    {
        FXBoom newFXBoom = _poolFX.GetFreeFX();
        newFXBoom.transform.position = position;
        Material newMat = GetMaterial(cubeNumber);
        newFXBoom.gameObject.GetComponent<ParticleSystemRenderer>().material = newMat;
    }

    private Material GetMaterial(int number)
    {
        int index = (int)(Mathf.Log(number) / Mathf.Log(2)) - 1;
        return _materialListForCubes.MaterialAr[index];
    }

    
}