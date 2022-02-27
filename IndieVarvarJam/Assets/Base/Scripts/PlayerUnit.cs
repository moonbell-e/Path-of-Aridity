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
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private const string isMoving = "isMoving";


        public int Health, Cost;

        public List<UnitSkills> UnitSkills;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void MoveUnit(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
            _animator.SetBool(isMoving, _navMeshAgent.velocity.magnitude > 0.01f);
        }

    }
}
