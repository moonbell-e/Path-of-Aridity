using UnityEngine;
using System.Collections.Generic;
using Units;
using UnityEngine.UI;
using TMPro;
using Battle.Controller;
using UnityEditor;

namespace Battle.Spells
{
    public delegate void ActionDone();

    public class SpellCombinator : MonoBehaviour
    {
        const int combinationLenght = 2;
        public event ActionDone SpellUsed;
        public event ActionDone SpellCanceled;
        private SpellCaster _spellCaster;
        [SerializeField]
        private List<Spell> _spells;
        [SerializeField]
        private List<Image> _skillImages;
        [SerializeField]
        private Sprite _emptySprite;
        [SerializeField]
        private Button _castButton;
        [SerializeField]
        private TextMeshProUGUI _description;
        private Spell _curSpell;
        private List<UnitSkills> _skillCombination;

        private void Awake() 
        {
            _spellCaster = FindObjectOfType<SpellCaster>();
            _spellCaster.SpellUseState += ClearSpellData;
            ClearSpellData(false);
            FindObjectOfType<EndTurnButton>().TurnEnded += ClearSpellData;
        }

        // [ContextMenu ("Finf spells")]
        // private void FindSpells()
        // {
        //     string[] spellsGUID = AssetDatabase.FindAssets("t:Spell", new[] {"Assets/Battle/Spells/SpellsSO"});
        //     List<string> spellPaths = new List<string>();
        //     foreach(string GUID in spellsGUID)
        //         spellPaths.Add(AssetDatabase.GUIDToAssetPath(GUID));
        //     _spells = new List<Spell>();
        //     foreach(string path in spellPaths)
        //         _spells.Add(AssetDatabase.LoadAssetAtPath(path, typeof(Spell)) as Spell);
        // }

        public bool SetSkill(UnitSkills skill)
        {
            if(_skillCombination.Count >= combinationLenght) return false;
            foreach(Image image in _skillImages)
                if(image.sprite == _emptySprite)
                {
                    image.sprite = skill.SkillSprite;
                    break;
                } 
            _skillCombination.Add(skill);
            if(_skillCombination.Count == combinationLenght) CheckCombination();
            return true;
        }

        public void RemoveSkill(UnitSkills skill)
        {
            foreach(UnitSkills combSkill in _skillCombination)
                if(combSkill == skill)
                {
                    foreach(Image image in _skillImages)
                        if(image.sprite == skill.SkillSprite)
                        {
                            image.sprite = _emptySprite;
                            break;
                        } 
                    if(_curSpell != null) ChangeSpellCastAvailability(false);
                    _skillCombination.Remove(skill);
                    return;
                }
        }

        public void CastSpell()
        {
            if(_curSpell == null) return;
            _spellCaster.CastSpell(_curSpell);
        }

        private void CheckCombination()
        {
            foreach(Spell spell in _spells)
                if(spell.CheckCombination(_skillCombination))
                {
                    _curSpell = spell;
                    ChangeSpellCastAvailability(true);
                }    
        }

        public void ClearSpellData()
        {
            ClearSpellData(false);
        }

        public void ClearSpellData(bool spellCasted)
        {
            _skillCombination = new List<UnitSkills>();
            foreach(Image image in _skillImages)
                image.sprite = _emptySprite;
            ChangeSpellCastAvailability(false);
            if(spellCasted) SpellUsed?.Invoke();
            else SpellCanceled?.Invoke();
        }

        private void ChangeSpellCastAvailability(bool state)
        {
            if(state)
            {
                _description.text = _curSpell.Description;
                _castButton.interactable = true;
            }
            else
            {
                _curSpell = null;
                _description.text = string.Empty;
                _castButton.interactable = false;
            }
        }
    }
}