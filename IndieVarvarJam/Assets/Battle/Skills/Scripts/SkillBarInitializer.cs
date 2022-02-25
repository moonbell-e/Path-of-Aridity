using System.Collections.Generic;
using UnityEngine;

namespace Battle.Skills
{
    public class SkillBarInitializer : MonoBehaviour
    {
        [SerializeField]
        private List<SkillBar> _skillBars;
        [SerializeField]
        private GameObject _skillCell;

        private void Awake()
        { 
            foreach(SkillBar skillBar in _skillBars)
                skillBar.HideBar();
        }

        public SkillBar InitilizeSkillBar(int cellsCount, Vector3 position)
        {
            SkillBar skillBar = null;
            foreach(SkillBar SB in _skillBars)
                if(SB.gameObject.activeSelf == false)
                {
                    skillBar = SB;
                    break;
                }
            
            if(skillBar == null) return null;

            skillBar.SetPosition(position);
            skillBar.ShowSkillCell(_skillCell, cellsCount);
            return skillBar;
        }
    }
}