using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Battle.Units
{
    public delegate void SendUnit(Unit unit);

    public abstract class Unit : MonoBehaviour
    {
        public event SendUnit UnitDied;
        private HealthBarInitializer _healthBarInitializer;
        protected HealthBar _healthBar;
        [SerializeField]
        protected int _maxHealth;
        [SerializeField]
        protected int _curHealth;

        public int MaxHealth => _maxHealth;
        public int CurHealth => _curHealth;
        
        protected void InitilizeHealth()
        {
            if(_healthBarInitializer == null) 
                _healthBarInitializer = FindObjectOfType<HealthBarInitializer>();
            _healthBar = _healthBarInitializer.InitilizeHealthBar(_maxHealth, _curHealth, transform.position);
        }

        public void AddShield(int value)
        {
            _healthBar.AddShield(value);
        }

        public virtual void ChangeHealth(int value)
        {
            if(_healthBar == null) InitilizeHealth();
            if(value < 0) value = _healthBar.WasteShield(value);
            _curHealth += value;
            if(_curHealth > _maxHealth) _curHealth = _maxHealth;
            if(_curHealth <= 0) Death();
            _healthBar.ChangeHealth(_curHealth);
        } 

        protected virtual void Death()
        {
            Debug.Log("Unit " + gameObject.name + " dead");
            UnitDied?.Invoke(this);
            HideUnit();
        }

        public virtual void HideUnit()
        {
            if(_healthBar != null) _healthBar.HideBar();
            gameObject.SetActive(false);
        }
    }
}

