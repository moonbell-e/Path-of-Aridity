using UnityEngine;
using System.Collections.Generic;
using Battle.Units;

namespace Battle.Spells
{
    public class SingleSpell : MonoBehaviour
    {
        private Spell _spell;
        private UnitsKeeper _unitsKeeper;
        private SendState _stateEvent;
        private bool _needChooseTarget;

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, bool playerCast, SendState stateEvent)
        {
            if(playerCast) 
            { 
                _spell = spell;
                _unitsKeeper = unitsKeeper;
                _stateEvent = stateEvent;
                _needChooseTarget = true;
            }
            else
            {
                if(spell.DamageType == DamageType.Heal)
                {
                    List<Guard> guards = unitsKeeper.AllGuards();
                    foreach(Guard guard in guards)
                        if(guard.MaxHealth == guard.CurHealth) guards.Remove(guard);
                    if(guards.Count > 0)
                    {
                        int index = (Random.Range(0, guards.Count));
                        guards[index].ChangeHealth(spell.Damage);
                    }
                    _stateEvent?.Invoke(true);
                }
                else
                {
                    List<Undead> undeads = unitsKeeper.AllUndeads();
                    int index = (Random.Range(0, undeads.Count));
                    undeads[index].ChangeHealth(spell.Damage);
                    _stateEvent?.Invoke(true);
                }
            }
        }

        private void Update()
        {
            if(_needChooseTarget == false) return;

            if(Input.GetMouseButtonDown(1))
            {
                _stateEvent?.Invoke(false);
                _needChooseTarget = false;
                return;
            }

            if(Input.GetMouseButtonDown(0) == false) return;
            Vector3 inputPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) == false) return;

            if(_spell.DamageType == DamageType.Heal)
            {
                Undead undead = hit.collider.GetComponent<Undead>();
                if(undead == null) return;
                undead.ChangeHealth(_spell.Damage);
                _stateEvent?.Invoke(true);
                _needChooseTarget = false;
            }
            else
            {
                Guard undead = hit.collider.GetComponent<Guard>();
                if(undead == null) return;
                undead.ChangeHealth(-_spell.Damage);
                _stateEvent?.Invoke(true);
                _needChooseTarget = false;
            }
        }
    }
}