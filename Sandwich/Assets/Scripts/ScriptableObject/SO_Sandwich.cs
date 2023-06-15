using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Configurations;

[CreateAssetMenu(fileName = "Sandwich", menuName = "ScriptableObjects/Sandwich")]
public class SO_Sandwich : ScriptableObject
{
    public string nameText;
    public Sprite icon;
     
    public enumIngridient[] ingredient;
}
