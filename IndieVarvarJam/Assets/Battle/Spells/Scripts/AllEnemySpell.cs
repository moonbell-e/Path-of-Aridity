using UnityEngine;
using Battle.Units;
using Battle.Controller;

namespace Battle.Spells
{
    public class AllEnemySpell : MonoBehaviour
    {
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, bool playerCast, SendState stateEvent)
        {
            if(playerCast)
            {
                if(spell.DamageType != DamageType.Physical)
                {
                    stateEvent?.Invoke(false);
                    return;
                }
                foreach(Guard guard in unitsKeeper.Units<Guard>())
                    guard.ChangeHealth(-spell.Damage);
                stateEvent?.Invoke(true);
            }
            else
            {
                if(spell.DamageType != DamageType.Physical)
                {
                    stateEvent?.Invoke(false);
                    return;
                }
                foreach(Undead undead in unitsKeeper.Units<Undead>())
                    undead.ChangeHealth(-spell.Damage);
            }
        }
    }
}