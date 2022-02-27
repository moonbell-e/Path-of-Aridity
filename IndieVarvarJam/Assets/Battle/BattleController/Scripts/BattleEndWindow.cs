using UnityEngine;
using UnityEngine.UI;

namespace Battle.Controller
{
    public class BattleEndWindow : MonoBehaviour
    {
        
        [SerializeField]
        private GameObject _battleUI;
        [SerializeField]
        private GameObject _loseScreen;
        [SerializeField]
        private GameObject _winScreen;
        [SerializeField]
        private Button _loseButton;

        private void Awake()
        {
            BattleReferee battleReferee = FindObjectOfType<BattleReferee>();
            battleReferee.BattleWin += ShowWinScreen;
            battleReferee.BattleLose += ShowLoseScreen;
            _loseButton.onClick.AddListener(FindObjectOfType<PauseManager>().GoToMainMenu);
            HideWindow();
        }

        public void HideWindow()
        {
            _battleUI.SetActive(true);
            _loseScreen.SetActive(false);
            _winScreen.SetActive(false);
            gameObject.SetActive(false);
        }

        public void ShowLoseScreen()
        {
            _battleUI.SetActive(false);
            gameObject.SetActive(true);
            _loseScreen.SetActive(true);
        }

        public void ShowWinScreen()
        {
            _battleUI.SetActive(false);
            gameObject.SetActive(true);
            _winScreen.SetActive(true);
        }
    }
}