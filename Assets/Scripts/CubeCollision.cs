using SO;
using Sound;
using UnityEngine;
using Zenject;


public class CubeCollision : MonoBehaviour
{
    private float _explositionForse = 200f;
    private float _explositionRadius = 3.5f;
    private CubeSpawner _cubeSpawner;
    private FXSpawner _fxSpawner;
    private CubeSoundController _cubeSoundController;
    private ScoreController _scoreController;


    [Inject]
    private void Construct(CubeSpawner cubeSpawnerArg, FXSpawner fXSpawnerArg,
        CubeSoundController cubeSoundControllerArg, ExplosionSettingsSO explosionSettingsSOArg,
        ScoreController scoreControllerArg)
    {
        _explositionForse = explosionSettingsSOArg.explositionForse;
        _explositionRadius = explosionSettingsSOArg.explositionRadius;
        _cubeSpawner = cubeSpawnerArg;
        _fxSpawner = fXSpawnerArg;
        _cubeSoundController = cubeSoundControllerArg;
        _scoreController = scoreControllerArg;
    }


    public void OnCollisionTwoCubes(CubeView oneCubeViewArg, CubeView twoCubeViewArg, Vector3 contactPointArg,
        Collision collision)
    {
        _cubeSoundController.PlaySoundHit(collision);

        if (oneCubeViewArg.GetNumber() != twoCubeViewArg.GetNumber())
            return;

        if (twoCubeViewArg.GetNumber() >= _cubeSpawner._maxCubeNumber)
            return;
        
        SpawnFXBoom(oneCubeViewArg.transform.position, oneCubeViewArg.GetNumber());
        SpawnFXBoom(twoCubeViewArg.transform.position, twoCubeViewArg.GetNumber());
        DestroyBouthCollisonCubes(oneCubeViewArg, twoCubeViewArg);
        MakeExplosiveForveForNearCubes(contactPointArg);
        AddScore(oneCubeViewArg);
        SpawnNewCubeAfterCollisonTwoCubes(oneCubeViewArg, twoCubeViewArg);
    }

    private void AddScore(CubeView oneCubeViewArg)
    {
        int scoreIncrement = oneCubeViewArg.GetNumber() * 2;
        _scoreController.AddScore(scoreIncrement);
    }


    private void MakeExplosiveForveForNearCubes(Vector3 contactPointArg)
    {
        Collider[] surroundedCubes = Physics.OverlapSphere(contactPointArg, 2f);

        foreach (Collider coll in surroundedCubes)
        {
            if (coll.attachedRigidbody != null)
                coll.attachedRigidbody.AddExplosionForce(
                    _explositionForse,
                    contactPointArg,
                    _explositionRadius);
        }
    }


    private void SpawnNewCubeAfterCollisonTwoCubes(CubeView oneCubeViewArg, CubeView twoCubeViewArg)
    {
        Vector3 possitionMuddleTwoCubes =
            Vector3.Lerp(oneCubeViewArg.transform.position, twoCubeViewArg.transform.position, 0.5f);
        CubeView newCubeView = _cubeSpawner.Spawn(oneCubeViewArg.GetNumber() * 2, possitionMuddleTwoCubes);

        newCubeView.JumpUp();
    }

    private void DestroyBouthCollisonCubes(CubeView oneCubeViewArg, CubeView twoCubeViewArg)
    {
        _cubeSoundController.PlayBoom();
        _cubeSpawner.DestroyCube(oneCubeViewArg);
        _cubeSpawner.DestroyCube(twoCubeViewArg);
    }


    private void SpawnFXBoom(Vector3 positionArg, int cubeNumber)
    {
        _fxSpawner.SpawnFXBoomParticleSystem(positionArg, cubeNumber);
    }
}