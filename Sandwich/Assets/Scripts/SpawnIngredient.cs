using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;
using UnityEngine.UI;

public class SpawnIngredient : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _ingredients;
    private int[] _ingredientsNumber;
    [SerializeField]
    private GameObject _position0;
    [SerializeField]
    private GameObject _position1;

    [SerializeField]
    private Button[] _buttons;

    private void OnEnable()
    {
        GameManager.ResetState += ResetCounter;
        GameManager.GameStart += StartButtons;
        GameManager.EndGame += DisableButtons;
    }

    private void OnDisable()
    {
        GameManager.ResetState -= ResetCounter;
        GameManager.GameStart -= StartButtons;
        GameManager.EndGame -= DisableButtons;

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

    private void StartButtons()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].enabled = true;
        }
    }

    private void DisableButtons()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].enabled = false;
        }
    }

    public void SpawningIngredient(int i)
    {
        if(i < 3)
        {
            if (_ingredientsNumber[i] < 3)
            {
                GameObject.Instantiate(_ingredients[i], _position0.transform);
                _ingredientsNumber[i]++;
            }
        }
        else
        {
            if (_ingredientsNumber[i] < 3)
            {
                GameObject.Instantiate(_ingredients[i], _position1.transform);
                _ingredientsNumber[i]++;
            }
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
