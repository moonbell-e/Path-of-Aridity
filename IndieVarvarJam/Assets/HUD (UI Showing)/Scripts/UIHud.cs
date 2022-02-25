using UnityEngine;
using UnityEngine.UI;
using Units;
using TMPro;

namespace UIPresenter
{
    public class UIHud : MonoBehaviour
    {
        [SerializeField] private GameObject _startDialoguePanel;
        [SerializeField] private GameObject _graveyardShopPanel;

        public GameObject StartDialoguePanel => _startDialoguePanel;
        public GameObject GraveyardShopPanel => _graveyardShopPanel;

        [SerializeField] private TMP_Text  _meleeCount;
        [SerializeField] private TMP_Text _rangeCount;

        private void OnEnable()
        {
            UnitSpawner.OnSpawnRangeUnit += AddRangeUnit;
            UnitSpawner.OnSpawnMeleeUnit += AddMeleeUnit;
        }

        private void OnDisable()
        {
            UnitSpawner.OnSpawnRangeUnit -= AddRangeUnit;
            UnitSpawner.OnSpawnMeleeUnit -= AddMeleeUnit;
        }

        public void AddRangeUnit(int count)
        {
            _rangeCount.text = count.ToString();
        }

        public void AddMeleeUnit(int count)
        {
            _meleeCount.text = count.ToString();
        }
    }
}


