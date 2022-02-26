using UnityEngine;
using Battle.Controller;

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

        private void Awake()
        {
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();
            _singleSpell = FindObjectOfType<SingleSpell>();    
            _globalSpell = FindObjectOfType<GlobalSpell>();
            _allEnemySpell = FindObjectOfType<AllEnemySpell>();
            _allAllySpell = FindObjectOfType<AllAllySpell>();
        }

        public void CastSpell(Spell spell, bool playerCast)
        {
            Debug.Log("Cast spell " + spell.name);
            switch(spell.Target)
            {
                case Target.Single:
                _singleSpell.CastSpell(spell, _unitsKeeper, playerCast, SpellUseState);
                break;

                case Target.Global:
                _globalSpell.CastSpell(spell, _unitsKeeper, playerCast, SpellUseState);
                break;

                case Target.AllEnemy:
                _allEnemySpell.CastSpell(spell, _unitsKeeper, playerCast, SpellUseState);
                break;

                case Target.AllAlly:
                _allAllySpell.CastSpell(spell, _unitsKeeper, playerCast, SpellUseState);
                break;
            }
        }
    }
}