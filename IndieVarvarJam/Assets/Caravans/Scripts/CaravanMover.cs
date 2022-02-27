using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanMover : MonoBehaviour
{
    [SerializeField] private PathGenerator _pathGenerator;

    [SerializeField] private Transform[] _curvePoints;

    public List<Vector3> _wayPoints;

    private float _step, _speed;

    private int _currentWayPointIndex;

    private Transform _transform;

    private void Awake()
    {
        _speed = 1f;
        _step = 0.05f;
        List<Vector3> curvePoints = new List<Vector3>();
        foreach (Transform trf in _curvePoints)
            curvePoints.Add(trf.position);
        _wayPoints = new List<Vector3>();
        for (float i = 0; i <= 1; i += _step)
        {
            _wayPoints.Add(_pathGenerator.BieseCurvePoint(i, curvePoints));
        }

        _transform = transform;
        transform.position = _wayPoints[0];

    }

    private void Update()
    {

        if (Vector3.Distance(_transform.position, _wayPoints[_currentWayPointIndex]) < 0.05f)
        {
            _currentWayPointIndex++;
            return;
        }
        else
        {
            _transform.position += (_wayPoints[_currentWayPointIndex] - _transform.position) * _speed * Time.deltaTime;
        }
    }
}
