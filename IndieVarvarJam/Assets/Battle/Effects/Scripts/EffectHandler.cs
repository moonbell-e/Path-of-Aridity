using Battle.Units;
using UnityEngine;

namespace Battle.Effects
{
    public class EffectHandler : MonoBehaviour
    {
        public void HandleEffect(Effect effect, Unit target)
        {
            switch(effect.Type)
            {
                case EffectType.Stan:
                Debug.Log("Step brother, I'm stuck!");
                break;

                case EffectType.Damaging: 
                target.ChangeHealth(-effect.Power);
                break;

                case EffectType.Healing:
                target.ChangeHealth(effect.Power);
                break;
            }
        }
    }
}