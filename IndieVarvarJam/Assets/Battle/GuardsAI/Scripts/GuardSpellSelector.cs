using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;
using Battle.Resolve;
using Battle.Controller;

namespace Battle.Units.AI
{
    public class GuardSpellSelector : MonoBehaviour
    {
        private SpellCaster _spellCaster;
        private ResolveBar _resolveBar;
        [SerializeField]
        private List<Spell> _availableSpells;

        private void Awake()
        {
            _spellCaster = FindObjectOfType<SpellCaster>();
            _resolveBar = FindObjectOfType<ResolveBar>();
            FindObjectOfType<EndTurnButton>().TurnEnded += SelectSpell;
        }

        public void AddSpell(Spell spell)
        {
            _availableSpells.Add(spell);
        }

        public void RemoveSpell(Spell spell)
        {
            _availableSpells.Remove(spell);
        }

        public void SelectSpell()
        {
            if(_availableSpells.Count == 0) return;
            int spellCount = SpellCount();
            for(int i = 0; i < spellCount; i++)
            {
                int spellIndex = Random.Range(0, _availableSpells.Count);
                _spellCaster.CastSpell(_availableSpells[spellIndex], false);
            }
        }

        private int SpellCount()
        {
            int resolve = _resolveBar.Resolve;
            if(resolve <= 30) return 1;
            else if(resolve < 70) return 2;
            else if(resolve <= 90) return 3;
            else return 4;
        }
    }
}

