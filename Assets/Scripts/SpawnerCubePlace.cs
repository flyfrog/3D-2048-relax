using UnityEngine;

public class SpawnerCubePlace : MonoBehaviour
{

    private Vector3 _spawnCubeCoordinate; 
    
    public Vector3 GetSpawnPlaceTransformPosition()
    {
        _spawnCubeCoordinate = transform.position;
        return _spawnCubeCoordinate;
    }
}
