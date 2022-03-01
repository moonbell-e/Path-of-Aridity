using Battle.Spells;
using Battle.Controller;
using UnityEngine;
using System.Collections.Generic;
using Battle.Resolve;
using Battle.Effects;

namespace Battle.Units.AI
{
    public class AllAllySpellAI : MonoBehaviour
    {
        private ResolveBar _resolve;

        private void Awake()
        {
            _resolve = FindObjectOfType<ResolveBar>();    
        }

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, Guard guardian)
        {
            List<Guard> guards = unitsKeeper.Units<Guard>();
            foreach(Guard gu in guards)
                foreach(Effect effect in spell.Effects)
                    gu.AddEffect(effect);
            switch (spell.DamageType)
            {
                case DamageType.Heal:
                foreach(Guard guard in guards)
                    guard.ChangeHealth(spell.Damage);
                break;

                case DamageType.Shield:
                foreach(Guard guard in guards)
                    guard.AddShield(spell.Damage);
                break;

                case DamageType.Mental:
               _resolve.ChangeResolve(spell.Damage);
                break;
            }
        }
    }
}