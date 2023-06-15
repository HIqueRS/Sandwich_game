using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;

public class Ingredient : MonoBehaviour
{

    public enumIngridient nameI;

    private void OnEnable()
    {
        GameManager.ResetState += ResetPosition;
    }

    private void OnDisable()
    {
        GameManager.ResetState -= ResetPosition;
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
