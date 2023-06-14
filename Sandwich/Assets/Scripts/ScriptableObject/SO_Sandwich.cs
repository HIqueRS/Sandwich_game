using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Sandwich", menuName = "ScriptableObjects/Sandwich")]
public class SO_Sandwich : ScriptableObject
{
    public string nameText;
    public Sprite icon;
     
    public bool hamburguer;
    public bool cheese;
    public bool tomato;
    public bool pickle;
    public bool lettuce;
}
