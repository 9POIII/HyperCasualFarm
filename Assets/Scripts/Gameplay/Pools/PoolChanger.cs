using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Pools
{
    public class PoolChanger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pools;
        private int maxCapacity;
        private int currentPool;
        public int CurrentPool
        {
            get => currentPool;
            set => currentPool = value;
        }

        private void Awake()
        {
            maxCapacity = pools.Count; 
        }

        public void PoolChange()
        {
            if (CurrentPool + 1 < maxCapacity)
            {
                pools[CurrentPool].SetActive(false);
                CurrentPool += 1;
                pools[CurrentPool].SetActive(true);
            }
            else if(CurrentPool + 1 >= maxCapacity)
            {
                pools[0].SetActive(true);
                pools[CurrentPool].SetActive(false);
                CurrentPool = 0;
            }
        }
    }
}
