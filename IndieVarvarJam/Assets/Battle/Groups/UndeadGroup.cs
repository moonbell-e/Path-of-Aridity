using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Controller;

namespace Battle.Group
{
    public delegate void SendUndeadSO(Unit undead);

    public class UndeadGroup : MonoBehaviour
    {
        private List<LoadUndeadData> _loadUndeadsData;

        private void Awake()
        {
            FindObjectOfType<UnitHandler>().UnitSpawned += AddUndead;
            _loadUndeadsData = new List<LoadUndeadData>();    
        }

        public void AddUndead(Unit undead)
        {
            if(undead == null) return;
            _loadUndeadsData.Add(new LoadUndeadData(undead.UnitPrefab.GetComponent<MeshFilter>().sharedMesh,
            undead.UnitPrefab.GetComponent<MeshRenderer>().sharedMaterial, undead.Health, undead.Health, undead.UnitSkills, undead.SkillCellsCount));
        }

        public void ClearUndeads()
        {
            _loadUndeadsData.Clear();
        }
    }
}