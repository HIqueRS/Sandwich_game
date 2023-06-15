using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;

public class SpawnIngredient : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _ingredients;
    private int[] _ingredientsNumber;
    [SerializeField]
    private GameObject _position;

    private void OnEnable()
    {
        GameManager.ResetState += ResetCounter;
    }

    private void OnDisable()
    {
        GameManager.ResetState -= ResetCounter;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _ingredientsNumber = new int[6];

        for (int i = 0; i < _ingredientsNumber.Length; i++)
        {
            _ingredientsNumber[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawningIngredient(int i)
    {
        if(_ingredientsNumber[i] < 3)
        {
            GameObject.Instantiate(_ingredients[i], _position.transform);
            _ingredientsNumber[i]++;
        }
        
    }

    public void ResetCounter()
    {
        for (int i = 0; i < _ingredientsNumber.Length; i++)
        {
            _ingredientsNumber[i] = 0;
        }
    }
}
