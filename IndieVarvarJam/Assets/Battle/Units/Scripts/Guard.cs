using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;
using Battle.Units.AI;

namespace Battle.Units
{
    public class Guard : Unit
    {
        private GuardSpellSelector _spellSelector;
        [SerializeField]
        private List<Spell> _spells; 
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _spellSelector = FindObjectOfType<GuardSpellSelector>();
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Initialize(Mesh mesh, Material material, int maxHealth, List<Spell> spells)
        {
            _meshFilter.mesh = mesh;
            _meshRenderer.material = material;
            gameObject.SetActive(true);

            _maxHealth = maxHealth;
            _curHealth = maxHealth;
            InitilizeHealth();

            _spells = spells;
            foreach(Spell spell in spells)
                _spellSelector.AddSpell(spell);
        }

        public override void ChangeHealth(int value)
        {
            base.ChangeHealth(value);
        }

        protected override void Death()
        {
            foreach(Spell spell in _spells)
                _spellSelector.RemoveSpell(spell);
            base.Death();
        }

        public override void HideUnit()
        {
            base.HideUnit();
        }
    }
}
