using SO;
using UnityEngine;
using Zenject;

namespace Duck
{
    public class Duck : MonoBehaviour
    {
        private float _rotationSpeed;
        private float _movingSpeed;
        private Transform[] _walkingWayPointsArray;
        private int _curentPointIndex = 0;
        private DuckWalkingPathPointController _duckWalkingPathPointController;

        [Inject]
        private void Constructor(DuckSettingsSO duckSettingsSoArg,
            DuckWalkingPathPointController duckWalkingPathPointControllerArg)
        {
            _rotationSpeed = duckSettingsSoArg.rotationSpeed;
            _movingSpeed = duckSettingsSoArg.movingSpeed;
            _duckWalkingPathPointController = duckWalkingPathPointControllerArg;
        }

        private void Start()
        {
            _walkingWayPointsArray = _duckWalkingPathPointController.GetWalkingWayPointsArray();
        }


        private void Update()
        {
            DuckWalk();
        }

        private void DuckWalk()
        {
            Transform targetPoint = _walkingWayPointsArray[_curentPointIndex];

            MoveDuck(targetPoint);
            RotateDuck(targetPoint);
            CheckDuckHasArrived(targetPoint);
        }

        private void MoveDuck(Transform targetPoint)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, targetPoint.position, _movingSpeed * Time.deltaTime);
        }

        private void RotateDuck(Transform targetPoint)
        {
            Vector3 direction = targetPoint.position - transform.position;
        
            if(direction==Vector3.zero)
                return;
        
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }

        private void CheckDuckHasArrived(Transform targetPoint)
        {
            if (transform.position == targetPoint.position)
            {
                _curentPointIndex++;
            }

            if (_curentPointIndex >= _walkingWayPointsArray.Length)
            {
                _curentPointIndex = 0;
            }
        }
    }
}