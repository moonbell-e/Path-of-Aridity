using UnityEngine;
using Battle.Effects;
using Battle.Units;
using System.Collections.Generic;

namespace Battle.Controller
{
    public class EffectActivator : MonoBehaviour
    {
        [SerializeField]
        private UnitsKeeper _unitsKeeper;
        [SerializeField]
        private EffectHandler _effectHandler;

        private void Awake()
        {
            FindObjectOfType<EndTurnButton>().TurnEnded += ActivateEffects;    
        }

        public void ActivateEffects()
        {
            List<Unit> units = _unitsKeeper.Units<Unit>();
            foreach(Unit unit in units)
            {
                foreach(ActivateEffect activateEffect in unit.ActiveEffects)
                {
                    _effectHandler.HandleEffect(activateEffect.Effect, unit);
                    if(activateEffect.EffectEnded())
                        unit.RemoveEffect(activateEffect);
                }
            }
        }
    }
}