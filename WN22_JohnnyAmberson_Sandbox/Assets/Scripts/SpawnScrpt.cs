using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScrpt : MonoBehaviour
{
    [SerializeField]
    GameObject[] _spawns;
    [SerializeField]
    GameObject _gameObject;
    int _randnum;
    void Start()
    {
        _randnum = Random.Range(0, _spawns.Length-1);
        Instantiate(_gameObject, _spawns[_randnum].transform, false);
    }
}
