using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Skills;
using Battle.Controller;

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
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _skillBarInitializer = FindObjectOfType<SkillBarInitializer>();
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Initialize(Mesh mesh, Material material, int maxHealth, int curHealth, List<UnitSkills> skills, int skillCellsCount)
        {
            _meshFilter.mesh = mesh;
            _meshRenderer.material = material;
            gameObject.SetActive(true);
            
            _skills = skills;
            _skillCellsCount = skillCellsCount;
            _skillBar = _skillBarInitializer.InitilizeSkillBar(skillCellsCount, transform.position);
            FindObjectOfType<EndTurnButton>().TurnEnded += RollSkill;

            _maxHealth = maxHealth;
            _curHealth = curHealth;
            InitilizeHealth();

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