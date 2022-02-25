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
        public static int Counter;
        public Transform Units;

        private void Start()
        {
            instance = this;
            Counter++; if (Counter > 1) Debug.LogError("Two PlayerHandlers on the scene!");

            UnitHandler.instance.SetUnitStats(Units);
        }
        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

