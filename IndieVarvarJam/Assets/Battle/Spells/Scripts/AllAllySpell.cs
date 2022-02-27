using UnityEngine;
using Battle.Units;
using Battle.Controller;

namespace Battle.Spells
{
    public class AllAllySpell : MonoBehaviour
    {
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, bool playerCast, SendState stateEvent)
        {
            if(playerCast)
            {
                if(spell.DamageType != DamageType.Heal)
                {
                    stateEvent?.Invoke(false);
                    return;
                }
                foreach(Undead undead in unitsKeeper.Units<Undead>())
                    undead.ChangeHealth(spell.Damage);
                stateEvent?.Invoke(true);
            }
            else
            {
                if(spell.DamageType != DamageType.Heal)
                {
                    stateEvent?.Invoke(false);
                    return;
                }
                foreach(Guard guard in unitsKeeper.Units<Guard>())
                    guard.ChangeHealth(spell.Damage);
            }
        }
    }
}