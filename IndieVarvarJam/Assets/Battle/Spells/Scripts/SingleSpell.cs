using UnityEngine;
using System.Collections.Generic;
using Battle.Units;
using Battle.Controller;

namespace Battle.Spells
{
    public class SingleSpell : MonoBehaviour
    {
        private Spell _spell;
        private UnitsKeeper _unitsKeeper;
        private SendState _stateEvent;
        private bool _needChooseTarget;

        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper, SendState stateEvent)
        {
            _spell = spell;
            _unitsKeeper = unitsKeeper;
            _stateEvent = stateEvent;
            _needChooseTarget = true;
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
            ActivateSpell(hit);
        }

        private void ActivateSpell(RaycastHit hit)
        {
            Undead undead = hit.collider.GetComponent<Undead>();
            Guard guard = hit.collider.GetComponent<Guard>();
            switch(_spell.DamageType)
            {
                case DamageType.Heal:
                if(undead == null) return;
                undead.ChangeHealth(_spell.Damage);
                _stateEvent?.Invoke(true);
                _needChooseTarget = false;
                break;

                case DamageType.Physical:
                if(guard == null) return;
                guard.ChangeHealth(-_spell.Damage);
                _stateEvent?.Invoke(true);
                _needChooseTarget = false;
                break;

                case DamageType.Shield:
                if(undead == null) return;
                undead.AddShield(_spell.Damage);
                _stateEvent?.Invoke(true);
                _needChooseTarget = false;
                break;
            }
        }
    }
}