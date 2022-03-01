using Battle.Spells;
using Battle.Controller;
using UnityEngine;
using Battle.Resolve;
using System.Collections.Generic;
using Battle.Effects;

namespace Battle.Units.AI
{
    public class GlobalSpellAI : MonoBehaviour
    {
        
        private ResolveBar _resolve;

        private void Awake()
        {
            _resolve = FindObjectOfType<ResolveBar>();    
        }

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, Guard guardian)
        {
            List<Unit> units = unitsKeeper.Units<Unit>();
            foreach(Unit u in units)
                foreach(Effect effect in spell.Effects)
                    u.AddEffect(effect);
            switch(spell.DamageType)
            {
                case DamageType.Mental:
                _resolve.ChangeResolve(spell.Damage);
                break;

                case DamageType.Physical:
                foreach(Unit unit in units)
                    unit.ChangeHealth(-spell.Damage);
                break;

                case DamageType.Heal:
                foreach(Unit unit in units)
                    unit.ChangeHealth(spell.Damage);
                break;

                case DamageType.Shield:
                foreach(Unit unit in units)
                    unit.AddShield(spell.Damage);
                break;
            }
        }
    }
}