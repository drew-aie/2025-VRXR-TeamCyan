using HurricaneVR.Framework.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SugarBomb : MonoBehaviour
{

    [SerializeField]
    private float timeUntilDespawn = 5;
    
    [SerializeField]
    private float timeToRespawn = 10;


    private GameObject[] distractedAnts;

    private bool isActive = false;

    private bool isReady = false;

    private Vector3 startingLocation;


    // Start is called before the first frame update
    void Start()
    {
        startingLocation = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {


        if (isActive ==true)
        {
            timeUntilDespawn -= Time.deltaTime;
            Attract();
        }

        if (timeUntilDespawn <= 0)
        {
            ResetAnts();
            isActive = false;
            isReady = false;
        }

        if (isReady == false)
        {
            timeToRespawn -= Time.deltaTime;
        }

        if (timeToRespawn <= 0)
        {
            isReady = true;
            timeUntilDespawn = 5;
            timeToRespawn = 10;
            transform.localPosition = startingLocation;
        }

    }

    public void Attract()
    {
        isActive = true;
        distractedAnts = GameObject.FindGameObjectsWithTag("Ants");
        for (int i =0; i<distractedAnts.Length; i++)
        {
            GameObject ant = distractedAnts[i];
            ant.GetComponent<AntBehavior>().Target = GameObject.FindGameObjectWithTag("SugarCube");

            
        }
    }

    public void ResetAnts()
    {

        for (int i = 0; i < distractedAnts.Length; i++)
        {
            GameObject ant = distractedAnts[i];
            ant.GetComponent<AntBehavior>().Target = GameObject.FindGameObjectWithTag("Player");

        }
        
    }
}
