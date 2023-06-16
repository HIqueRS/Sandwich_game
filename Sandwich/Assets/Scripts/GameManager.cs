using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    //ela tem q ser unica e disparar eventos

    //vai dar pra botar o tempo e a lista de sanduiches

    public static GameManager Instance { get; private set; }

    public static event Action ResetState;
    public static event Action EndGame;

    public SO_Sandwich[] sandwiches;

    public SO_Sandwich currentSandwich;

    public int points;
    public int endPoints;

    public float timer;

    private bool _end;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomSandwich();
        _end = false;
    }

    // Update is called once per frame
    void Update()
    {
        PassTime();
    }

    private void PassTime()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            if(!_end)
            {
                endPoints = points;
                EndGame?.Invoke();
                _end = true;
            }
        }
    }

    private void RandomSandwich()
    {

        currentSandwich = sandwiches[UnityEngine.Random.Range(0, sandwiches.Length)];
    }

    public void RestStateFunction()
    {
        RandomSandwich();

        ResetState?.Invoke();
        
    }
}
