using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;
using Battle.Units.AI;

namespace Battle.Units
{
    public class Guard : Unit
    {
        [SerializeField]
        private GuardSpellSelector _spellSelector;
        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;
        private List<Spell> _spells; 
        
        public List<Spell> Spells => _spells;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize(Mesh mesh, Material[] materials, int maxHealth, List<Spell> spells)
        {
            _meshFilter.mesh = mesh;
            _meshRenderer.materials = materials;
            gameObject.SetActive(true);

            _maxHealth = maxHealth;
            _curHealth = maxHealth;
            InitilizeHealth();
            if(_healthBar == null) InitilizeHealth();

            _spells = spells;
        }

        public override void ChangeHealth(int value)
        {
            base.ChangeHealth(value);
        }

        protected override void Death()
        {
            base.Death();
        }

        public override void HideUnit()
        {
            base.HideUnit();
        }
    }
}
