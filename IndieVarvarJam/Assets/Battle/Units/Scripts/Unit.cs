using UnityEngine;
using System.Collections.Generic;
using Battle.Effects;

namespace Battle.Units
{
    public delegate void SendUnit(Unit unit);

    public abstract class Unit : MonoBehaviour
    {
        public event SendUnit UnitDied;
        [SerializeField]
        protected HealthBarInitializer _healthBarInitializer;
        protected List<ActivateEffect> _activeEffects;
        protected HealthBar _healthBar;
        protected int _maxHealth;
        protected int _curHealth;

        public int MaxHealth => _maxHealth;
        public int CurHealth => _curHealth;
        public List<ActivateEffect> ActiveEffects => _activeEffects;

        protected virtual void Awake()
        {
            _activeEffects = new List<ActivateEffect>();
        }
        
        public void AddEffect(Effect effect)
        {
            _activeEffects.Add(new ActivateEffect(effect));
        }

        public void RemoveEffect(ActivateEffect effect)
        {
            _activeEffects.Remove(effect);
        }

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

    public struct ActivateEffect
    {
        private Effect _effect;
        private int _remainingTurns;

        public Effect Effect => _effect;
        public int RemainingTurns => _remainingTurns;

        public bool EffectEnded()
        {
            _remainingTurns--;
            if(_remainingTurns <= 0) return false;
            else return true;
        }

        public ActivateEffect(Effect effect)
        {
            _effect = effect;
            _remainingTurns = effect.Duration;
        }
    }
}

