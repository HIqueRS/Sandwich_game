using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        _canChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_canChange)
        {
            ChangeDisplay();
        }
    }

    void ChangeDisplay()
    {
        _name.text = _sandwich.nameText;
        _displayImage.sprite = _sandwich.icon;
    }
}
