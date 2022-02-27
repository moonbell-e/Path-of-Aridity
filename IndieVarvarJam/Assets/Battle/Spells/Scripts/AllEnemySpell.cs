using UnityEngine;
using Battle.Units;
using Battle.Controller;
using Battle.Resolve;
using System.Collections.Generic;

namespace Battle.Spells
{
    public class AllEnemySpell : MonoBehaviour
    {
        private ResolveBar _resolve;

        private void Awake()
        {
            _resolve = FindObjectOfType<ResolveBar>();    
        }

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, SendState stateEvent)
        {
            List<Guard> guards = unitsKeeper.Units<Guard>();
            switch (spell.DamageType)
            {
                case DamageType.Physical:
                foreach(Guard guard in guards)
                    guard.ChangeHealth(-spell.Damage);
                stateEvent?.Invoke(true);
                break;

                case DamageType.Mental: 
                _resolve.ChangeResolve(-spell.Damage);
                break;
            }
        }
    }
}