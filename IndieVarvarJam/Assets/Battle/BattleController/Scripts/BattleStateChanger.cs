using Battle.Spells;
using UnityEngine;
using Battle.Resolve;

namespace Battle.Controller
{
    public class BattleStateChanger : MonoBehaviour
    {
        [SerializeField]
        private GameObject _battleField;
        [SerializeField]
        private GameObject _battleWindow;
        [SerializeField]
        private Camera _battleCamera;
        [SerializeField]
        private Camera _worldCamera;
        [SerializeField]
        private BattleData _battleData;
        private UnitsKeeper _unitsKeeper;
        private ResolveBar _resolveBar;

        private void Awake()
        {
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();
            _resolveBar = FindObjectOfType<ResolveBar>();
            FindObjectOfType<BattleReferee>().BattleWin += EndBattle;
            foreach(GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
                {
                    var battleEvent = obj.GetComponent<IBattleEvent>();
                    if(battleEvent != null) battleEvent.BattleEventStarted += InitializeBattle;
                }
        }
        private void Start()
        {
            EndBattle();    
        }

        private void EndBattle()
        {
            _battleCamera.enabled = false;
            _worldCamera.enabled = true;
            _unitsKeeper.DeactivateAllUnits();
            _battleField.SetActive(false);
            _battleWindow.SetActive(false);
        }

        private void Update() 
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                InitializeBattle(_battleData);
                FindObjectOfType<SpellCombinator>().ClearSpellData(false);
            }
        }

        public void InitializeBattle(BattleData battleData)
        {
            _battleField.SetActive(true);
            _battleWindow.SetActive(true);
            _battleCamera.enabled = true;
            _worldCamera.enabled = false;
            _unitsKeeper.InitializeUnits(battleData.LoadUndeadsData, battleData.LoadGuardsData);
            _resolveBar.InitializeResolve(battleData.StartResolve);
            
        }
    }
}