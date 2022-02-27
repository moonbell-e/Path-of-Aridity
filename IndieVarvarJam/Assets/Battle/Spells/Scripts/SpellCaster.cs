using UnityEngine;
using Battle.Controller;
using Battle.Units.AI;

namespace Battle.Spells
{
    public delegate void SendState(bool state);

    public class SpellCaster : MonoBehaviour
    {
        public event SendState SpellUseState;
        private UnitsKeeper _unitsKeeper;
        private SingleSpell _singleSpell;
        private GlobalSpell _globalSpell;
        private AllEnemySpell _allEnemySpell;
        private AllAllySpell _allAllySpell;
        private SingleSpellAI _singleSpellAI;
        private GlobalSpellAI _globalSpellAI;
        private AllEnemySpellAI _allEnemySpellAI;
        private AllAllySpellAI _allAllySpellAI;
        private FMODUnity.EventReference _soundPath;

        private void Awake()
        {
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();
            _singleSpell = FindObjectOfType<SingleSpell>();    
            _globalSpell = FindObjectOfType<GlobalSpell>();
            _allEnemySpell = FindObjectOfType<AllEnemySpell>();
            _allAllySpell = FindObjectOfType<AllAllySpell>();
            _singleSpellAI = FindObjectOfType<SingleSpellAI>();    
            _globalSpellAI = FindObjectOfType<GlobalSpellAI>();
            _allEnemySpellAI = FindObjectOfType<AllEnemySpellAI>();
            _allAllySpellAI = FindObjectOfType<AllAllySpellAI>();
            SpellUseState += PlaySpellSound;
        }

        private void PlaySpellSound(bool state)
        {
            if(state == false) return;
            FMODUnity.RuntimeManager.PlayOneShot(_soundPath);
        }

        public void CastSpell(Spell spell, bool playerCast)
        {
            Debug.Log("Cast spell " + spell.name);
            _soundPath = spell.SoundPath;
            if(playerCast)
            {
                switch(spell.Target)
                {
                    case Target.Single:
                    _singleSpell.CastSpell(spell, _unitsKeeper, SpellUseState);
                    break;

                    case Target.Global:
                    _globalSpell.CastSpell(spell, _unitsKeeper, SpellUseState);
                    break;

                    case Target.AllEnemy:
                    _allEnemySpell.CastSpell(spell, _unitsKeeper, SpellUseState);
                    break;

                    case Target.AllAlly:
                    _allAllySpell.CastSpell(spell, _unitsKeeper, SpellUseState);
                    break;
                }
            }
            else
            {
                switch(spell.Target)
                {
                    case Target.Single:
                    _singleSpellAI.CastSpell(spell, _unitsKeeper);
                    break;

                    case Target.Global:
                    _globalSpellAI.CastSpell(spell, _unitsKeeper);
                    break;

                    case Target.AllEnemy:
                    _allEnemySpellAI.CastSpell(spell, _unitsKeeper);
                    break;

                    case Target.AllAlly:
                    _allAllySpellAI.CastSpell(spell, _unitsKeeper);
                    break;
                }
            }
        }
    }
}