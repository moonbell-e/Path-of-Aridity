using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Skills;

namespace Battle.Units
{
    public class Undead : Unit
    {
        private SkillBarInitializer _skillBarInitializer;
        private SkillBar _skillBar;
        [SerializeField]
        private List<UnitSkills> _skills;
        [SerializeField]
        private int _skillCellsCount;
        private MeshFilter _meshFilter;

        private void Awake()
        {
            _skillBarInitializer = FindObjectOfType<SkillBarInitializer>();
            _meshFilter = GetComponent<MeshFilter>();
            if(_active == false)
            {
                Death();
                return;
            }
            InitilizeHealth();
            _skillBar = _skillBarInitializer.InitilizeSkillBar(_skillCellsCount, transform.position);
        }

        private void Start() 
        {
            RollSkill();
        }

        public void Initialize(Mesh mesh, int maxHealth, int curHealth, List<UnitSkills> skills, int skillCellsCount)
        {
            _meshFilter.mesh = mesh;
            gameObject.SetActive(true);
            
            _skills = skills;
            _skillCellsCount = skillCellsCount;
            _skillBar = _skillBarInitializer.InitilizeSkillBar(skillCellsCount, transform.position);

            _maxHealth = maxHealth;
            _curHealth = curHealth;
            InitilizeHealth();
        }
        
        public void RollSkill()
        {
            List<UnitSkills> choosedSkills = new List<UnitSkills>();
            for(int i = 0; i < _skillCellsCount; i++)
            {
                int skillIndex = Random.Range(0, _skills.Count);
                choosedSkills.Add(_skills[skillIndex]);
            }
            _skillBar.InitilizeSkillCell(choosedSkills, _skillCellsCount);
        }

        public override void ChangeHealth(int value)
        {
            base.ChangeHealth(value);
        }

        public override void Death()
        {
            base.Death();
            if(_skillBar == null) return;
            _skillBar.HideBar();
        }
    }
}