using UnityEngine;

namespace Battle.Effects
{
    [CreateAssetMenu(fileName = "New Effect", menuName = "New Effect")]
    public class Effect : ScriptableObject
    {
        [SerializeField]
        private EffectType _type;
        [SerializeField]
        private int _power;
        [SerializeField]
        private int _duration;

        public EffectType Type => _type;
        public int Power => _power;
        public int Duration => _duration;
    }

    public enum EffectType
    {
        Stan,
        Damaging,
        Healing
    }
}