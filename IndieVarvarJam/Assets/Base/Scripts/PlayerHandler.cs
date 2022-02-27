using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputManager;
using Units;

namespace Player
{
    public class PlayerHandler: MonoBehaviour
    {
        public static PlayerHandler instance;
        public Transform Units;

        private void Start()
        {
            if (instance != null && instance != this)
            {
                Debug.Log("Two!");
                Destroy(this);
                return;
            }
            instance = this;
            UnitHandler.instance.SetUnitStats(Units);
        }
        
        private void Update()
        {
            
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

