using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Units;

namespace Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnit : MonoBehaviour
    {

        private NavMeshAgent _navMeshAgent;

        public int Health, Cost;

        public List<UnitSkills> UnitSkills;

        private void OnEnable()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void MoveUnit(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
        }

    }
}
