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

    public SO_Sandwich[] sandwiches;

    public SO_Sandwich currentSandwich;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomSandwich();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomSandwich()
    {

        currentSandwich = sandwiches[UnityEngine.Random.Range(0, sandwiches.Length)];
    }

    public void RestStateFunction()
    {
        ResetState?.Invoke();
    }
}
