using System.Collections.Generic;
using UnityEngine;
using Player;

namespace InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;
        public static int Counter;

        private RaycastHit _hit;

        private List<GameObject> _units = new List<GameObject>();

        private void Awake()
        {
            instance = this;
            Counter++; if (Counter > 1) Debug.LogError("Two InputHandlers on the scene!");

            _units.AddRange(GameObject.FindGameObjectsWithTag("Unit"));
        }

        public void HandleUnitMovement()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hit))
                {
                    LayerMask layerhit = _hit.transform.gameObject.layer;

                    switch (layerhit.value)
                    {
                        case 6: //Units layer
                            break;
                        default:
                            foreach(GameObject unit in _units)
                            {
                                PlayerUnit playerUnit = unit.gameObject.GetComponent<PlayerUnit>();
                                playerUnit.MoveUnit(_hit.point);
                            }
                            break;
                    }
                }
            }
        }

    }

}
