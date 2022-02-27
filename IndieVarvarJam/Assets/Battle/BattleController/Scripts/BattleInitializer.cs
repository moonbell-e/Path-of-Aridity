using System.Collections.Generic;
using UnityEngine;
using Battle.Resolve;

namespace Battle.Controller
{
    public class BattleInitializer : MonoBehaviour
    {
        [SerializeField]
        private BattleData _battleData;
        private UnitsKeeper _unitsKeeper;
        private ResolveBar _resolveBar;

        private void Awake()
        {
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();
            _resolveBar = FindObjectOfType<ResolveBar>();
        }

        private void Update() 
        {
            if(Input.GetKeyDown(KeyCode.R))
                InitializeBattle(_battleData);
        }

        public void InitializeBattle(BattleData battleData)
        {
            _unitsKeeper.InitializeUnits(battleData.LoadUndeadsData, battleData.LoadGuardsData);
            _resolveBar.InitializeResolve(battleData.StartResolve);
        }
    }
}