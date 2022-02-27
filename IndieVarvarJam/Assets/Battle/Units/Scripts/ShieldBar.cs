using UnityEngine;
using TMPro;

namespace Battle.Units
{
    public class ShieldBar : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private int _shield;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();   
            _shield = 0; 
            HideShield();
        }
        
        private void ShowShield()
        {
            gameObject.SetActive(true);
        }

        private void HideShield()
        {
            gameObject.SetActive(false);
        }

        public int WasteShield(int value)
        {
            if(_shield + value <= 0)
            {
                value += _shield;
                _shield = 0;
                _text.text = _shield.ToString();
                HideShield();
                return value;
            }
            else
            {
                _shield += value;
                _text.text = _shield.ToString();
                return 0;
            }
        }

        public void AddShield(int value)
        {
            if(_shield == 0) ShowShield();
            _shield += value; 
            _text.text = _shield.ToString();
        }
    }
}