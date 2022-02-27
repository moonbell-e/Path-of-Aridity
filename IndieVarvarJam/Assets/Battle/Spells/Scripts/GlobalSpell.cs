using UnityEngine;
using Battle.Units;
using Battle.Resolve;
using System.Collections.Generic;
using Battle.Controller;

namespace Battle.Spells
{
    public class GlobalSpell : MonoBehaviour
    {
        private ResolveBar _resolve;

        private void Awake()
        {
            _resolve = FindObjectOfType<ResolveBar>();    
        }
        
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, bool playerCast, SendState stateEvent)
        {
            List<Unit> units = unitsKeeper.Units<Unit>();
            switch(spell.DamageType)
            {
                case DamageType.Mental:
                if(playerCast) _resolve.ChangeResolve(-spell.Damage);
                else _resolve.ChangeResolve(spell.Damage);
                break;

                case DamageType.Physical:
                foreach(Unit unit in units)
                    unit.ChangeHealth(-spell.Damage);
                break;

                case DamageType.Heal:
                foreach(Unit unit in units)
                    unit.ChangeHealth(spell.Damage);
                break;
            }
            if(playerCast) stateEvent?.Invoke(true);
        }
    }
}