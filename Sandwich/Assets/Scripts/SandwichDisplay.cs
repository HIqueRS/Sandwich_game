using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Configurations;

public class SandwichDisplay : MonoBehaviour
{
    [SerializeField]
    private SO_Sandwich _sandwich;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private Image _displayImage;

    [SerializeField]
    private bool _canChange;

    [SerializeField]
    private TextMeshProUGUI[] _ingredients;

    [SerializeField]
    private TextMeshProUGUI _score;

    [SerializeField]
    private TextMeshProUGUI _timerText;
   

    private void OnEnable()
    {
        GameManager.ResetState += ChangeDisplay;
        GameManager.ResetState += ChangeScore;
    }

    private void OnDisable()
    {
        GameManager.ResetState -= ChangeDisplay;
        GameManager.ResetState -= ChangeScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        _canChange = true;

       
    }

    

    // Update is called once per frame
    void Update()
    {
        if(_canChange)
        {
            ChangeDisplay();
            _canChange = false;
        }


        ChangeTimer();
    }

    void ChangeTimer()
    {
        _timerText.text = GameManager.Instance.timer.ToString("0");
    }

    void ChangeScore()
    {
        _score.text = string.Concat( "Score:" ,GameManager.Instance.points);
    }

    void ChangeDisplay()
    {
        _sandwich = GameManager.Instance.currentSandwich;

        _name.text = _sandwich.nameText;
        _displayImage.sprite = _sandwich.icon;

        for (int i = 0; i < _sandwich.ingredient.Length; i++)
        {
            switch (_sandwich.ingredient[i])
            {
                case EnumIngridient.BreadTop:
                    break;
                case EnumIngridient.Cheese: 
                    _ingredients[i].text = "Cheese";

                    break;
                case EnumIngridient.Hamburguer:
                    _ingredients[i].text = "Hamburguer";

                    break;
                case EnumIngridient.Lettuce:
                    _ingredients[i].text = "Lettuce";

                    break;
                case EnumIngridient.Pickle:
                    _ingredients[i].text = "Pickle";

                    break;
                case EnumIngridient.Tomato:
                    _ingredients[i].text = "Tomato";

                    break;
                default:
                    break;
            }
        }
    }
}
