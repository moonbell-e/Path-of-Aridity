using System.Collections.Generic;
using Units;

namespace Battle.Skills
{
    public class SkillsNameComparer : IComparer<UnitSkills>
    {
        public int Compare(UnitSkills a, UnitSkills b)
        {
            return a.Name.CompareTo(b.Name);
        }
    }
}

