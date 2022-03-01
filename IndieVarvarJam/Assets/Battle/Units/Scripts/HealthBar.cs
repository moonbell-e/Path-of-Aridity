using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Battle.Units
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private ShieldBar _shieldBar;
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private TextMeshProUGUI _curHealthText;

        public void Initialize(int maxHealth, Vector3 position)
        {
            if(_slider == null) _slider = GetComponent<Slider>();
            _slider.maxValue = maxHealth;
            position = Camera.main.WorldToScreenPoint(position);
            position.y -= 75;
            if(_transform == null) _transform = GetComponent<Transform>();
            _transform.position = position;
            if(_shieldBar == null) _shieldBar = GetComponentInChildren<ShieldBar>();
            _shieldBar.InitializeShield();
            gameObject.SetActive(true);
        }

        public void ChangeHealth(int curHealth)
        {
            if(_curHealthText == null) _curHealthText = GetComponentInChildren<TextMeshProUGUI>();
            _curHealthText.text = curHealth.ToString();
            _slider.value = curHealth;
        }

        public int WasteShield(int value)
        {
            return _shieldBar.WasteShield(value);
        }

        public void AddShield(int value)
        {
            _shieldBar.AddShield(value);
        }

        public void HideBar()
        {
            gameObject.SetActive(false);
        }
    }
}