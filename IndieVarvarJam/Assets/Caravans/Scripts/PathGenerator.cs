using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator: MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public List<Transform> Points => _points;
    public Vector3 BieseCurvePoint(float progress, List<Vector3> points)
    {
        if (points.Count > 1)
        {
            List<Vector3> newPoints = new List<Vector3>();
            for (int i = 0; i < points.Count - 1; i++)
                newPoints.Add(Vector3.Lerp(points[i], points[i + 1], progress));
            return BieseCurvePoint(progress, newPoints);
        }
        else
        {
            return points[0];
        }
    }
    public  void OnDrawGizmos()
    {
        List<Vector3> newpoints = new List<Vector3>();
        foreach (Transform transform in _points)
            newpoints.Add(transform.position);
        Vector3 oldpointpos = BieseCurvePoint(0, newpoints);
        for (float i = 0; i < 1; i += 0.01f)
        {
            Vector3 newpointpos = BieseCurvePoint(i, newpoints);
            Gizmos.DrawLine(oldpointpos, newpointpos);
            oldpointpos = newpointpos;
        }
    }
}
