using UnityEngine;
using Battle.Controller;
using Battle.Units;

namespace Battle.Resolve
{
    public class ResolveEventViewer : MonoBehaviour
    {
        [SerializeField]
        private int resolveFromGuardDeath;
        [SerializeField]
        private int resolveFromUndeadDeath;
        private ResolveBar _resolveBar;
        private UnitsKeeper _unitsKeeper;

        private void Awake()
        {
            _unitsKeeper = FindObjectOfType<UnitsKeeper>();  
            _resolveBar = FindObjectOfType<ResolveBar>();  
        }

        private void Start() 
        {
            foreach(Unit unit in _unitsKeeper.Units<Unit>())
                unit.UnitDied +=  ChangeResolveFromDeath;
        }

        private void ChangeResolveFromDeath(Unit unit)
        {
            if(unit.GetType() == typeof(Undead))
                _resolveBar.ChangeResolve(resolveFromUndeadDeath);

            if(unit.GetType() == typeof(Guard))
                _resolveBar.ChangeResolve(-resolveFromGuardDeath);
        }
    }
}