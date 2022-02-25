using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Battle.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        protected bool _active;
        [SerializeField]
        protected Slider _healthBar; 
        protected TextMeshProUGUI _curHealthText; 
        [SerializeField]
        protected int _maxHealth;
        [SerializeField]
        protected int _curHealth;

        public int MaxHealth => _maxHealth;
        public int CurHealth => _curHealth;

        protected void InitilizeHealth()
        {
            Vector3 healthBarPosition = transform.position;
            healthBarPosition = Camera.main.WorldToScreenPoint(healthBarPosition);
            healthBarPosition.y -= 75;
            _healthBar.transform.position = healthBarPosition;
            _healthBar.maxValue = _maxHealth;
            _healthBar.value = _curHealth;
            _curHealthText = _healthBar.GetComponentInChildren<TextMeshProUGUI>();
            _curHealthText.text = _curHealth.ToString();
            _healthBar.gameObject.SetActive(true);
        }

        public virtual void ChangeHealth(int value)
        {
            _curHealth += value;
            if(_curHealth > _maxHealth) _curHealth = _maxHealth;
            if(_curHealth <= 0) Death();
            _curHealthText.text = _curHealth.ToString();
            _healthBar.value = _curHealth;
        } 

        public virtual void Death()
        {
            Debug.Log("Unit " + gameObject.name + " dead");
            _healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}

