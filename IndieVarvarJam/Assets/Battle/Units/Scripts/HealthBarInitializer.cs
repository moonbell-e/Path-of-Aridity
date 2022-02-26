using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Units
{
    public class HealthBarInitializer : MonoBehaviour
    {
        private HealthBar[] _healthBars;

        private void Awake()
        {
            _healthBars = FindObjectsOfType<HealthBar>();
            foreach(HealthBar healthBar in _healthBars)
                healthBar.HideBar();
        }

        public HealthBar InitilizeHealthBar(int maxHealth, int curHealth, Vector3 position)
        {
            HealthBar healthBar = null;
            foreach(HealthBar HB in _healthBars)
                if(HB.gameObject.activeSelf == false)
                {
                    healthBar = HB;
                    break;
                }
            
            if(healthBar == null) return null;

            healthBar.Initialize(maxHealth, position);
            healthBar.ChangeHealth(curHealth);
            return healthBar;
        }
    }
}