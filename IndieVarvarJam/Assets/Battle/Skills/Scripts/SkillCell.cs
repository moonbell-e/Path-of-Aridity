using UnityEngine;
using UnityEngine.UI;
using Units;

namespace Battle.Skills
{
    public delegate void SendSkillCell(SkillCell skill);
    
    public class SkillCell : MonoBehaviour
    {
        public event SendSkillCell CellClicked;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Button _button;
        private UnitSkills _skill;
        private bool _cellChoosed;
        private bool _cellUsed;

        public UnitSkills Skill => _skill;
        public bool CellChoosed => _cellChoosed;
        public bool CellUsed => _cellUsed;
 
        public void ClickOnCell()
        {
            if(_cellUsed == true) return;
            CellClicked?.Invoke(this);
        }

        public void ChangeChooseState(bool state)
        {
            _cellChoosed = state;
            if(state) _image.color /= 1.2f;
            else _image.color *= 1.2f;
        }

        public void InitilizeCell(UnitSkills skill)
        {
            _skill = skill;
            _image.sprite = skill.SkillSprite;
            if(skill.Name == "Empty")
            {
                DisableCell();
            } 
            else 
            {
                _cellUsed = false;
                _cellChoosed = false;
                _button.interactable = true;
            }
        }

        public void DisableCell()
        {
            ChangeChooseState(false);
            _cellUsed = true;
            _cellChoosed = true;
            _button.interactable = false;
        }
    }
}
