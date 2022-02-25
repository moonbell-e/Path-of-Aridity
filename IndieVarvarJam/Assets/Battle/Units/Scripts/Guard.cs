using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;

namespace Battle.Units
{
    public class Guard : Unit
    {
        [SerializeField]
        private List<Spell> _spells; 
        private MeshFilter _meshFilter;

        private void Awake()
        {
            if(_active == false)
            {
                Death();
                return;
            } 
            _meshFilter = GetComponent<MeshFilter>();
            InitilizeHealth();
        }

        public void Initialize(Mesh mesh, int maxHealth, List<Spell> spells)
        {
            _meshFilter.mesh = mesh;
            gameObject.SetActive(true);

            _maxHealth = maxHealth;
            _curHealth = maxHealth;
            InitilizeHealth();

            _spells = spells;
        }

        public override void ChangeHealth(int value)
        {
            base.ChangeHealth(value);
        }

        public override void Death()
        {
            base.Death();
        }
    }
}
