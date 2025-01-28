using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawner;
    [SerializeField]
    private GameObject[] Bugs;

    private GameObject _currentBug;
    private bool _isBugSpawned = false;

    private void SetCurrentBug()
    {

    }
    private void SpawnObjects()
    {
        Instantiate(_currentBug, transform.position, transform.rotation);
        _isBugSpawned = true;
    }

    private void DespawnObjects()
    {
        _currentBug.SetActive(false);
        _isBugSpawned = false;
    }
}
