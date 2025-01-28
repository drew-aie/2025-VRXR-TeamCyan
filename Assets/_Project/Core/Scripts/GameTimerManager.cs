using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEngine.Events;
public class GameTimerManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField]
    private float gameTime;
    [SerializeField]
    TextMeshProUGUI timeTextBox;
    bool allowTimer;

    enum GameState
    {
        Waiting,
        Playing,
        Completed,
        End
    }
    private GameState gamestate;
    [Header("Timer Events")]
    public UnityEvent onTimerExpire;
    // Start is called before the first frame update
    void Start()
    {
        allowTimer = true;
        gamestate = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowTimer)
        {
            UpdateGameTimer();

        }
        if(gamestate == GameState.Playing)
            CheckTime();
    }

    private void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime - minutes * 60);


        string gameTimeClockDisplay = String.Format("{0:0}, {1:00}", minutes, seconds);

        timeTextBox.text = gameTimeClockDisplay;
    }

    private void CheckTime()
    {
        if(gameTime <= 0)
        {
            allowTimer = false;

            timeTextBox.text = "Goodbye";
            
            onTimerExpire.Invoke();
            
            gamestate = GameState.End;
        }
    }
}
