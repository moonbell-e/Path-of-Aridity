using Battle.Spells;
using Battle.Controller;
using UnityEngine;
using System.Collections.Generic;
using Battle.Resolve;

namespace Battle.Units.AI
{
    public class AllAllySpellAI : MonoBehaviour
    {
        private ResolveBar _resolve;

        private void Awake()
        {
            _resolve = FindObjectOfType<ResolveBar>();    
        }

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper)
        {
            List<Guard> guards = unitsKeeper.Units<Guard>();
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