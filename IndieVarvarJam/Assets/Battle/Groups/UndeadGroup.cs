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

        public List<LoadUndeadData> LoadUndeadsData => _loadUndeadsData;

        private void Awake()
        {
            _loadUndeadsData = new List<LoadUndeadData>();
            FindObjectOfType<UnitHandler>().UnitSpawned += AddUndead;
        }

        public void AddUndead(Unit undead)
        {
            _loadUndeadsData.Add(new LoadUndeadData(undead.UnitPrefab.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh,
            undead.UnitPrefab.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterials, undead.Health, undead.Health, undead.UnitSkills, undead.SkillCellsCount));
        }

        public void ClearUndeads()
        {
            _loadUndeadsData.Clear();
        }
    }
}