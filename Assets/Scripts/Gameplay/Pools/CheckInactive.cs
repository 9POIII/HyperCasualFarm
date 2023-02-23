using System;
using Gameplay.Pools;
using UnityEngine;

namespace Gameplay
{
    public class CheckInactive : MonoBehaviour
    {
        public static CheckInactive Instance;

        [SerializeField] private PoolChanger poolChanger;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            ActivateAllChildrens();
        }

        public void ActivateAllChildrens()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        public void Check()
        {
            bool allChildrenInactive = true;
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    allChildrenInactive = false;
                    break;
                }
            }

            if (allChildrenInactive)
            {
                poolChanger.PoolChange();
            }
        }
    }
}
