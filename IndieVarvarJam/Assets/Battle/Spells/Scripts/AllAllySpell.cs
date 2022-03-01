using UnityEngine;
using Battle.Units;
using Battle.Controller;
using System.Collections.Generic;
using Battle.Effects;

namespace Battle.Spells
{
    public class AllAllySpell : MonoBehaviour
    {
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, SendState stateEvent)
        {
            List<Undead> undeads = unitsKeeper.Units<Undead>();
            foreach(Undead un in undeads)
                foreach(Effect effect in spell.Effects)
                    un.AddEffect(effect);
            switch (spell.DamageType)
            {
                case DamageType.Heal:
                foreach(Undead undead in undeads)
                    undead.ChangeHealth(spell.Damage);
                stateEvent?.Invoke(true);
                break;

                case DamageType.Shield:
                foreach(Undead undead in undeads)
                    undead.AddShield(spell.Damage);
                stateEvent?.Invoke(true);
                break;
            }
        }
    }
}