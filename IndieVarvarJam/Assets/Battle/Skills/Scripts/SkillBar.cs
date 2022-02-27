using System.Collections.Generic;
using UnityEngine;
using Battle.Spells;
using Units;

namespace Battle.Skills
{
    public class SkillBar : MonoBehaviour
    {
        private Transform _transform;
        private SpellCombinator _spellCombinator;
        private List<SkillCell> _skillCells= new List<SkillCell>();
        private bool _active;

        public int CellsCount => _skillCells.Count;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _spellCombinator = FindObjectOfType<SpellCombinator>();
            _spellCombinator.SpellUsed += DisableUsedCells;
            _spellCombinator.SpellCanceled += UnselectChoosedCells;
        }
        
        public void SetPosition(Vector3 position)
        {
            position = Camera.main.WorldToScreenPoint(position);
            position.y += 75;
            position.x -= 20;
            _transform.position = position;
            gameObject.SetActive(true);
        }

        public void HideBar()
        {
            foreach(SkillCell skillCell in _skillCells)
                skillCell.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        public void ShowSkillCell(GameObject skillCell, int cellsCount)
        {
            if(cellsCount <= CellsCount)
            {
                for(int i = 0; i < cellsCount; i++)
                    _skillCells[i].gameObject.SetActive(true);
            }
            else
            {
                foreach(SkillCell cell in _skillCells)
                    cell.gameObject.SetActive(true);

                cellsCount -= CellsCount;
                for(int i = 0; i < cellsCount; i++)
                {
                    SkillCell cell = Instantiate(skillCell, _transform.position, Quaternion.identity, _transform).GetComponent<SkillCell>();
                    _skillCells.Add(cell);
                    cell.CellClicked += SendSkill;
                }
            }
        }

        public void InitilizeSkillCell(List<UnitSkills> skills, int cellsCount)
        {
            for(int i = 0; i < cellsCount; i++)
                _skillCells[i].InitilizeCell(skills[i]);
        }

        private void UnselectChoosedCells()
        {
            foreach(SkillCell skillCell in _skillCells)
                if(skillCell.CellChoosed && skillCell.CellUsed == false) 
                    skillCell.ChangeChooseState(false);
        }

        private void DisableUsedCells()
        {
            foreach(SkillCell skillCell in _skillCells)
                if(skillCell.CellChoosed) skillCell.DisableCell();
        }

        private void SendSkill(SkillCell skillCell)
        {
            if(skillCell.CellChoosed == false)
            {
                if(_spellCombinator.SetSkill(skillCell.Skill))
                    skillCell.ChangeChooseState(true);
            } 
            else
            {
                _spellCombinator.RemoveSkill(skillCell.Skill);
                skillCell.ChangeChooseState(false);
            } 
        }
    }
}