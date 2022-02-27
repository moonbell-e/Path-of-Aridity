using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Battle.Units
{
    public class HealthBar : MonoBehaviour
    {
        private Transform _transform;
        private ShieldBar _shieldBar;
        private Slider _slider;
        private TextMeshProUGUI _curHealthText;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _slider = GetComponent<Slider>();
            _curHealthText = GetComponentInChildren<TextMeshProUGUI>();    
        }

        public void Initialize(int maxHealth, Vector3 position)
        {
            if(_slider == null) _slider = GetComponent<Slider>();
            _slider.maxValue = maxHealth;
            position = Camera.main.WorldToScreenPoint(position);
            position.y -= 75;
            _transform.position = position;
            gameObject.SetActive(true);
        }

        public void ChangeHealth(int curHealth)
        {
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