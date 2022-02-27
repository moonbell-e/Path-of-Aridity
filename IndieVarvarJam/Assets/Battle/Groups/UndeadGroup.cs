using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Controller;

namespace Battle.Group
{
    public class UndeadGroup : MonoBehaviour
    {
        private List<LoadUndeadData> _loadUndeadsData;

        private void Awake()
        {
            _loadUndeadsData = new List<LoadUndeadData>();    
        }

        public void AddUndead(Unit undead)
        {
            _loadUndeadsData.Add(new LoadUndeadData(undead.UnitPrefab.GetComponent<MeshFilter>().mesh,
            undead.UnitPrefab.GetComponent<MeshRenderer>().material, undead.Health, undead.Health, undead.UnitSkills, undead.SkillCellsCount));
        }

        public void ClearUndeads()
        {
            _loadUndeadsData.Clear();
        }
    }
}