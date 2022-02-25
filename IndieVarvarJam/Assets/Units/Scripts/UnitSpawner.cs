using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Units
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _meleeWarriors;
        [SerializeField] private List<GameObject> _rangeWarriors;

        public static UnitSpawner instance;
        public static int Counter;

        private int _rangeCount;
        private int _meleeCount;

        public static Action <int> OnSpawnRangeUnit;

        public static Action<int> OnSpawnMeleeUnit;

        private void Awake()
        {
            instance = this;
            Counter++; if (Counter > 1) Debug.LogError("Two UnitSpawners on the scene!");

        }
        public void SpawnRangeUnit()
        {
            if (_rangeCount == 5)
                return;
            else
            {
                _rangeCount++;
                OnSpawnRangeUnit?.Invoke(_rangeCount);
                foreach (GameObject unit in _rangeWarriors)
                {
                    unit.SetActive(true);
                }
            }
        }

        public void SpawnMeleeUnit()
        {
            if (_meleeCount == 5)
                return;
            else
            {
                _meleeCount++;
                OnSpawnMeleeUnit?.Invoke(_meleeCount);
                foreach (GameObject unit in _meleeWarriors)
                {
                    unit.SetActive(true);
                }
            }
        }

    }
}


