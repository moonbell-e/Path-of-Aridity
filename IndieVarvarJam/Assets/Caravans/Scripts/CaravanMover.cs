using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanMover : MonoBehaviour
{
    [SerializeField] private PathGenerator _pathGenerator;

    [SerializeField] private Transform[] _curvePoints;

    [SerializeField] private List<Vector3> _wayPoints;
    
    private float _step, _speed;

    private int _currentWayPointIndex;

    private void Awake()
    {
        _speed = 5f;
        List<Vector3> curvePoints = new List<Vector3>();
        foreach (Transform trf in _curvePoints)
            curvePoints.Add(trf.position);
        _wayPoints = new List<Vector3>();
        for (float i = 0; i <= 1; i += _step)
        {
            _wayPoints.Add(_pathGenerator.BieseCurvePoint(i, curvePoints));
        }
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _wayPoints[_currentWayPointIndex]) < 0.01f)
        {
            _currentWayPointIndex++;
            return;
        }
        else
        {
            transform.position += (_wayPoints[_currentWayPointIndex] - transform.position) * _speed * Time.deltaTime;
        }
    }
}
