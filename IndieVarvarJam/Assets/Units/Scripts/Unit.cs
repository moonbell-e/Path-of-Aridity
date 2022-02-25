using UnityEngine;
using System.Collections.Generic;
using Units;

namespace Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName ="New Unit")]
    public class Unit : ScriptableObject
    {
        public enum unitType
        {
            RangeWarrior,
            MeleeWarrior,
            PlayerWarrior
        };

        [Header("Unit Settings")]
        public unitType Type;

        public  GameObject UnitPrefab;

        public List<UnitSkills> UnitSkills = new List<UnitSkills>();


        [Header("Unit Stats")]
        public int Health;

        public int Cost;

    }
}