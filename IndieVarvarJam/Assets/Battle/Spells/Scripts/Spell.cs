using System.Collections.Generic;
using UnityEngine;
using Units;
using Battle.Skills;
using System.Linq;
using FMODUnity;

namespace Battle.Spells
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "New Spell")]
    public class Spell : ScriptableObject
    {
        [SerializeField]
        private List<UnitSkills> _combination;
        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private Target _target;
        [SerializeField]
        private int _damage;
        [SerializeField] [TextArea (5, 10)]
        private string _description;
        [SerializeField] 
        private EventReference _soundPath;

        public DamageType DamageType => _damageType;
        public Target Target => _target;
        public int Damage => _damage;
        public string Description => _description;
        public EventReference SoundPath => _soundPath;
        
        public bool CheckCombination(List<UnitSkills> skills)
        {
            skills.Sort(new SkillsNameComparer());
            _combination.Sort(new SkillsNameComparer());
            if(_combination.SequenceEqual(skills)) return true;
            return false;
        }
    }
    
    public enum DamageType
    {
        Physical,
        Shield,
        Mental,
        Heal
    }

    public enum Target
    {
        Single,
        Global,
        AllEnemy,
        AllAlly
    }
}