using UnityEngine;

namespace Battle.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        protected int _maxHealth;
        protected int _curHealth;

        public virtual void ChangeHealth(int value)
        {
            _curHealth += value;
            if(_curHealth > _maxHealth) _curHealth = _maxHealth;
            if(_curHealth <= 0) Death();
        } 

        public virtual void Death()
        {
            Debug.Log("Unit " + gameObject.name + " dead");
            gameObject.SetActive(false);
        }
    }
}

