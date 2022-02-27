using System.Collections.Generic;
using UnityEngine;
using System;
using Battle.Units;

namespace Battle.Controller
{
    public class UnitsKeeper : MonoBehaviour
    {
        public event ActionHappened UnitsCountChanged;
        public event ActionHappened LoadEnded;
        private List<UnitData<Undead>> _undeadsData;
        private List<UnitData<Guard>> _guardsData;

        private void Awake()
        {
            Undead[] undeads = FindObjectsOfType<Undead>();
            _undeadsData = new List<UnitData<Undead>>(undeads.Length);
            for(int i = 0; i < undeads.Length; i++)
                _undeadsData.Add(new UnitData<Undead>(undeads[i]));

            Guard[] guards = FindObjectsOfType<Guard>();
            _guardsData = new List<UnitData<Guard>>(guards.Length);
            for(int i = 0; i < guards.Length; i++)
                _guardsData.Add(new UnitData<Guard>(guards[i])) ;

            foreach(Unit unit in Units<Unit>())
                unit.UnitDied += MarkUnitDeath;
        }

        private void Start() 
        {
            DeactivateAllUnits();
            LoadEnded?.Invoke();
        }

        public void InitializeUnits(List<LoadUndeadData> loadUndeadDatas, List<LoadGuardData> loadGuardDatas)
        {
            DeactivateAllUnits();

            List<UnitData<Undead>> undeadsData = UnitsData<Undead>();
            foreach(LoadUndeadData LUD in loadUndeadDatas)
            {
                UnitData<Undead> undeadData = null;
                foreach(UnitData<Undead> UD in undeadsData)
                {
                    if(UD.Active == false)
                    {
                        undeadData = UD;
                        break;
                    }
                }
                if(undeadData == null) 
                {
                    Debug.LogError("Undeads load error!");
                    break;
                }
                undeadData.Unit.Initialize(LUD.Mesh, LUD.Material, LUD.MaxHealth, LUD.CurHealth, LUD.Skills, LUD.SkillCellsCount);
                undeadData.Active = true;
            }

            List<UnitData<Guard>> guardsData = UnitsData<Guard>();
            foreach(LoadGuardData LGD in loadGuardDatas)
            {
                UnitData<Guard> guardData = null;
                foreach(UnitData<Guard> GD in guardsData)
                {
                    if(GD.Active == false)
                    {
                        guardData = GD;
                        break;
                    }
                }
                if(guardData == null) 
                {
                    Debug.LogError("Guards load error!");
                    break;
                }
                guardData.Unit.Initialize(LGD.Mesh, LGD.Material, LGD.MaxHealth, LGD.Spells);
                guardData.Active = true;
            }
        }

        public void DeactivateAllUnits()
        {
            foreach(UnitData<Undead> undeadData in UnitsData<Undead>())
            {
                undeadData.Unit.HideUnit();
                undeadData.Active = false;
            }
            foreach(UnitData<Guard> guardData in UnitsData<Guard>())
            {
                guardData.Unit.HideUnit();
                guardData.Active = false;
            }
        }

        private void MarkUnitDeath(Unit unit)
        {
            foreach(UnitData<Undead> undeadData in UnitsData<Undead>())
                if(undeadData.Unit == unit) 
                {
                    undeadData.Active = false;
                    UnitsCountChanged?.Invoke();
                    return;
                }
            foreach(UnitData<Guard> guardData in UnitsData<Guard>())
                if(guardData.Unit == unit) 
                {
                    guardData.Active = false;
                    UnitsCountChanged?.Invoke();
                    return;
                }
        }

        private List<UnitData<T>> UnitsData<T>() where T : Unit
        {
            List<UnitData<T>> unitsData = new List<UnitData<T>>();
            if(typeof(T) == typeof(Undead))
            {
                unitsData = (_undeadsData as List<UnitData<T>>);
                return unitsData;
            }

            unitsData = (_guardsData as List<UnitData<T>>);
            return unitsData;
        }

        public List<T> Units<T>() where T : Unit
        {
            List<T> units = new List<T>();
            if(typeof(T) == typeof(Undead))
            {
                foreach(UnitData<Undead> undeadData in _undeadsData)
                    if(undeadData.Active) units.Add(undeadData.Unit as T);
                return units;
            }

            if(typeof(T) == typeof(Guard))
            {
                foreach(UnitData<Guard> guardData in _guardsData)
                    if(guardData.Active) units.Add(guardData.Unit as T);
                return units;
            }

            foreach(UnitData<Undead> undeadData in _undeadsData)
                if(undeadData.Active) units.Add(undeadData.Unit as T);
            foreach(UnitData<Guard> guardData in _guardsData)
                if(guardData.Active) units.Add(guardData.Unit as T);
            return units;
        }
    }

    [Serializable]
    public class UnitData<T> where T : Unit
    {
        [SerializeField]
        private T _unit;
        public bool Active = true;

        public T Unit => _unit;

        public UnitData(T unit)
        {
            _unit = unit;
        }
    }
}