using System.Collections.Generic;
using UnityEngine;
using Player;
using UIPresenter;
using Battle.Group;
namespace InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;
        public static int Counter;

        private UIHud _uiHud;

        private RaycastHit _hit;

        private List<GameObject> _selectedUnits = new List<GameObject>();

        private UndeadGroup _undeadGroup;
        private void Awake()
        {
            _undeadGroup = FindObjectOfType<UndeadGroup>();
            _uiHud = gameObject.GetComponent<UIHud>();
            if (instance != null && instance != this)
            {
                Debug.Log("Two!");
                Destroy(this);
                return;
            }
            instance = this;
        }

        private void Update()
        {
            _selectedUnits.AddRange(GameObject.FindGameObjectsWithTag("Unit"));
        }

        public void HandleUnitMovement()
        {
            if (Input.GetMouseButton(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hit))
                {
                    LayerMask layerhit = _hit.transform.gameObject.layer;

                    switch (layerhit.value)
                    {
                        case 9:
                            foreach (GameObject unit in _selectedUnits)
                            {
                                PlayerUnit playerUnit = unit.gameObject.GetComponent<PlayerUnit>();
                                playerUnit.MoveUnit(_hit.point);
                            }
                            break;
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hit))
                {
                    LayerMask layerhit = _hit.transform.gameObject.layer;

                    switch (layerhit.value)
                    {
                        case 6: //The MainGuy layer
                            _uiHud.StartDialoguePanel.SetActive(true);
                            break;
                        case 7: //Graveyard layer
                            _uiHud.GraveyardShopPanel.SetActive(true);
                            break;
                        case 8: //Caravan layer
                            Debug.Log(_hit.collider.GetComponentInParent<GuardGroup>());
                            Debug.Log(_hit.collider);

                            Debug.Log(_undeadGroup.LoadUndeadsData);

                            _hit.collider.GetComponentInParent<GuardGroup>().StartBattle(_undeadGroup.LoadUndeadsData);
                            break;
                    }
                }
            }


        }

    }

}
