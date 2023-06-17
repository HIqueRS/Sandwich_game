using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;

public class Ingredient : MonoBehaviour
{

    public EnumIngridient nameI;

    private void OnEnable()
    {
        GameManager.ResetState += ResetPosition;
        GameManager.EndGame += ResetPosition;
    }

    private void OnDisable()
    {
        GameManager.ResetState -= ResetPosition;
        GameManager.EndGame -= ResetPosition;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        GameObject.Destroy(this.gameObject);
    }
}
