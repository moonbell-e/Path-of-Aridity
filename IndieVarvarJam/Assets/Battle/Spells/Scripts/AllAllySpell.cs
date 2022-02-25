using UnityEngine;
using Battle.Units;

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
                foreach(Undead undead in unitsKeeper.AllUndeads())
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
                foreach(Guard guard in unitsKeeper.AllGuards())
                    guard.ChangeHealth(spell.Damage);
                stateEvent?.Invoke(true);
            }
        }
    }
}