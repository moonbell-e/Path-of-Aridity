using Battle.Resolve;
using UnityEngine;
using Battle.Units;

namespace Battle.Controller
{
    public class BattleReferee : MonoBehaviour
    {
        public event ActionHappened BattleWin;
        public event ActionHappened BattleLose;
        private UnitsKeeper _unitsKeeper;

        private void Awake()
        {
            FindObjectOfType<ResolveBar>().ResolveLost += WinBattle;
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();
            _unitsKeeper.UnitsCountChanged += CheckFightingUnits;
        }

        private void CheckFightingUnits()
        {
            if(_unitsKeeper.Units<Undead>().Count == 0)
            {
                LoseBattle();
                return;
            } 
            if(_unitsKeeper.Units<Guard>().Count == 0)
            {
                WinBattle();
                return;
            }
        }

        private void LoseBattle()
        {
            Debug.Log("You lose!");
            BattleLose?.Invoke();
        }

        private void WinBattle()
        {
            Debug.Log("You win!");
            BattleWin?.Invoke();
        }
    }
}