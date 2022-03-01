using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Skills;
using Battle.Controller;

namespace Battle.Units
{
    public class Undead : Unit
    {
        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private SkillBarInitializer _skillBarInitializer;
        private SkillBar _skillBar;
        private List<UnitSkills> _skills;
        private int _skillCellsCount;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize(Mesh mesh, Material[] materials, int maxHealth, int curHealth, List<UnitSkills> skills, int skillCellsCount)
        {
            _meshFilter.mesh = mesh;
            _meshRenderer.materials = materials;
            gameObject.SetActive(true);
            
            _skills = skills;
            _skillCellsCount = skillCellsCount;
            _skillBar = _skillBarInitializer.InitilizeSkillBar(skillCellsCount, transform.position);
            FindObjectOfType<EndTurnButton>().TurnEnded += RollSkill;
            _maxHealth = maxHealth;
            _curHealth = curHealth;
            InitilizeHealth();
            if(_healthBar == null) InitilizeHealth();

            RollSkill();
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

        protected override void Death()
        {
            FindObjectOfType<EndTurnButton>().TurnEnded -= RollSkill;
            base.Death();
        }

        public override void HideUnit()
        {
            if(_skillBar != null) _skillBar.HideBar();
            base.HideUnit();
        }
    }
}