using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "New UnitSkill", menuName = "New Skill")]
    public class UnitSkills : ScriptableObject
    {
        public string Name;

        public Sprite SkillSprite;
    }
}

