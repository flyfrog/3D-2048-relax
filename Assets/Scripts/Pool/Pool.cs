using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class Pool<T> where T : MonoBehaviour
    {
        public T prefab { get; }
        public Transform container { get; }
        private List<T> poolList;


        [Inject]
        public Pool(T prefabArg, int countArg, Transform containerArg = null)
        {
            prefab = prefabArg;
            container = containerArg;
            CreatePool(countArg);
        }


        private void CreatePool(int countArg)
        {
            poolList = new List<T>();
            for (int i = 0; i < countArg; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var newObject = UnityEngine.Object.Instantiate(prefab, container);
            newObject.gameObject.SetActive(isActiveByDefault);
            poolList.Add(newObject);
            return newObject;
        }


        public bool HasFreeElement(out T element)
        {
            foreach (var mono in poolList)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            return CreateObject(true);
        }
    }
}