using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Battle.Group;

namespace Units
{
    public class UnitHandler : MonoBehaviour
    {
        //public event SendUndeadSO UnitSpawned;
        public static UnitHandler instance;
        public static int Counter;

        [SerializeField]
        private Unit _rangeWarrior, _meleeWarrior, _playerWarrior;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Debug.Log("Two!");
                Destroy(this);
                return;
            }
            instance = this;
        }

        public (int cost, int health, List<UnitSkills>, Unit undead) GetUnitStats(string type)
        {
            Unit unit;
            switch(type)
            {
                case "RangeW":
                    unit = _rangeWarrior;
                    break;
                case "MeleeW":
                    unit = _meleeWarrior;
                    break;
                case "Player":
                    unit = _playerWarrior;
                    break;
                default:
                    Debug.Log("Error type");
                    return (0, 0, null, null);

            }
            return (unit.Cost, unit.Health, unit.UnitSkills, unit);
        }

        public void SetUnitStats(Transform type)
        {
            foreach(Transform unit in type)
            {
                string unitName = unit.name.Substring(0, 6);
                var stats = GetUnitStats(unitName);
                PlayerUnit playerUnit = unit.GetComponent<PlayerUnit>();

                playerUnit.Cost = stats.cost;
                playerUnit.Health = stats.health;
                playerUnit.UnitSkills = stats.Item3;
                //UnitSpawned?.Invoke(playerUnit.Undead);
            }    
        }
    }
}



