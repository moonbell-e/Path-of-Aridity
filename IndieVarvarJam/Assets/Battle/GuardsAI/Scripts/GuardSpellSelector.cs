using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;
using Battle.Resolve;
using Battle.Controller;
using Battle.Units;

namespace Battle.Units.AI
{
    public class GuardSpellSelector : MonoBehaviour
    {
        [SerializeField]
        private UnitsKeeper _unitsKeeper;
        [SerializeField]
        private SpellCaster _spellCaster;
        [SerializeField]
        private ResolveBar _resolveBar;

        private void Awake()
        {
            FindObjectOfType<EndTurnButton>().TurnEnded += SelectSpell;
        }

        public void SelectSpell()
        {
            int spellCount = SpellCount();
            List<Guard> guards = _unitsKeeper.Units<Guard>();
            foreach(Guard guard in guards)
            {
                for(int i = 0; i < spellCount; i++)
                {
                    int spellIndex = Random.Range(0, guard.Spells.Count);
                    _spellCaster.CastSpell(guard.Spells[spellIndex], guard);
                }
            }
        }

        private int SpellCount()
        {
            int resolve = _resolveBar.Resolve;
            if(resolve <= 60) return 1;
            else return 2;
        }
    }
}

