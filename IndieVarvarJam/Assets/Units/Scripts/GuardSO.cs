using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;

namespace Units
{
    [CreateAssetMenu(fileName = "New Guard", menuName ="New Guard")]
    public class GuardSO : ScriptableObject
    {
        public  GameObject UnitPrefab;
        public int Health;
        public List<Spell> UnitSkills = new List<Spell>();
    }
}