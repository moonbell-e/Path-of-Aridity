using Battle.Spells;
using Battle.Controller;
using UnityEngine;
using System.Collections.Generic;
using Battle.Effects;

namespace Battle.Units.AI
{
    public class AllEnemySpellAI : MonoBehaviour
    {
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, Guard guardian)
        {
            List<Undead> undeads = unitsKeeper.Units<Undead>();
            switch (spell.DamageType)
            {
                case DamageType.Physical:
                foreach(Undead undead in undeads)
                {
                    undead.ChangeHealth(-spell.Damage);
                    foreach(Effect effect in spell.Effects)
                        undead.AddEffect(effect);
                }
                break;
            }
        }
    }
}