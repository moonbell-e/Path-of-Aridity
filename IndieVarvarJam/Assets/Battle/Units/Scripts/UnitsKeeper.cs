using System.Collections.Generic;
using UnityEngine;
using System;

namespace Battle.Units
{
    public class UnitsKeeper : MonoBehaviour
    {
        [SerializeField]
        private List<UndeadData> _undeads;
        [SerializeField]
        private List<GuardData> _guards;

        public List<Unit> AllUnits()
        {
            List<Unit> units = new List<Unit>();
            foreach(Unit unit in AllUndeads())
                units.Add(unit);
            foreach(Unit unit in AllGuards())
                units.Add(unit);
            return units;
        }

        public List<Undead> AllUndeads()
        {
            List<Undead> undeads = new List<Undead>();
            foreach(UndeadData undeadData in _undeads)
                if(undeadData.Active) undeads.Add(undeadData.Undead);
            return undeads;
        }

        public List<Guard> AllGuards()
        {
            List<Guard> guards = new List<Guard>();
            foreach(GuardData guardData in _guards)
                if(guardData.Active) guards.Add(guardData.Guard);
            return guards;
        }
    }

    [Serializable]
    public struct UndeadData
    {
        [SerializeField]
        private Undead _undead;
        [SerializeField]
        private bool _active;

        public Undead Undead => _undead;
        public bool Active => _active;
    }

    [Serializable]
    public struct GuardData
    {
        [SerializeField]
        private Guard _guard;
        [SerializeField]
        private bool _active;

        public Guard Guard => _guard;
        public bool Active => _active;
    }
}