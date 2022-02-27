using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _caravans;


    private void Update()
    {
        _caravans[Random.Range(0, _caravans.Count - 1)].SetActive(true);
    }
}
