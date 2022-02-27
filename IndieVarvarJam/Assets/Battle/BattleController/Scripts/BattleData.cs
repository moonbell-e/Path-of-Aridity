using System.Collections.Generic;
using Units;
using Battle.Spells;
using UnityEngine;

namespace Battle.Controller
{
    public class BattleData : MonoBehaviour
    {
        [SerializeField]
        private int _startResolve;
        [SerializeField]
        private List<LoadUndeadData> _loadUndeadsData;
        [SerializeField]
        private List<LoadGuardData> _loadGuardsData;

        public int StartResolve => _startResolve;
        public List<LoadUndeadData> LoadUndeadsData => _loadUndeadsData;
        public List<LoadGuardData> LoadGuardsData => _loadGuardsData;

        public void InitializeBattleData(int startResolve, List<LoadUndeadData> loadUndeadDatas, List<LoadGuardData> loadGuardDatas)
        {
            _startResolve = startResolve;
            _loadUndeadsData = loadUndeadDatas;
            _loadGuardsData = loadGuardDatas;
        }
    }

    [System.Serializable]
    public abstract class LoadUnitData
    {
        [SerializeField]
        protected Mesh _mesh;
        [SerializeField]
        protected Material _material;
        [SerializeField]
        protected int _maxHealth;

        public Mesh Mesh => _mesh;
        public Material Material => _material;
        public int MaxHealth => _maxHealth;
    }

    [System.Serializable]
    public class LoadUndeadData : LoadUnitData
    {
        [SerializeField]
        private int _curHealth;
        [SerializeField]
        private List<UnitSkills> _skills;
        [SerializeField]
        private int _skillCellsCount;
        
        public List<UnitSkills> Skills => _skills;
        public int SkillCellsCount => _skillCellsCount;
        public int CurHealth => _curHealth;

        public LoadUndeadData(Mesh mesh, Material material, int maxHealth, int curHealth, List<UnitSkills> skills, int skillCellsCount)
        {
            _mesh = mesh;
            _material = material;
            _maxHealth = maxHealth;
            _curHealth = curHealth;
            _skills = skills;
            _skillCellsCount = skillCellsCount;
        }
    }

    [System.Serializable]
    public class LoadGuardData : LoadUnitData
    {
        [SerializeField]
        private List<Spell> _spells;

        public List<Spell> Spells => _spells;

        public LoadGuardData(Mesh mesh, Material material, int maxHealth, List<Spell> spells)
        {
            _mesh = mesh;
            _material = material;
            _maxHealth = maxHealth;
            _spells = spells;
        }
    }
}