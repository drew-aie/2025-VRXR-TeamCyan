using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _objectArray;

    private void Start()
    {
        GameObject obj = _objectArray[Random.Range(0, _objectArray.Length)];
    }

    public GameObject GetRandom()
    {
        GameObject rand = _objectArray[Random.Range(0, _objectArray.Length)];
        Debug.Log(_objectArray.Length);
        return rand;
    }
}
