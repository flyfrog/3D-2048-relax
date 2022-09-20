using UnityEngine;

namespace Duck
{
    public class DuckWalkingPathPointController : MonoBehaviour
    {
        private Transform[] _childrenPointsArray; 
        
        private void Awake()
        {
            TakeMyChildrenPoint();
        }

        private void TakeMyChildrenPoint()
        {
            int childCount = transform.childCount;
            _childrenPointsArray = new Transform [childCount];

            for (int j = 0; j < childCount; j++)
            {
                _childrenPointsArray[j] = transform.GetChild(j);
            }
        }

        public Transform[] GetWalkingWayPointsArray()
        {
            return _childrenPointsArray;
        }
    }
}