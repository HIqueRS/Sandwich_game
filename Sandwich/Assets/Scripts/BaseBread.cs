using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;

public class BaseBread : MonoBehaviour
{
    //[SerializeField]
    //private bool[] _ingredient;

    private List<enumIngridient> _ingredients;
    private List<enumIngridient> _orderIngredient;

    // Start is called before the first frame update
    void Start()
    {
        //_ingredient = new bool[6];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ingredient"))
        {
            GameObject gameobj;
            Ingredient colided;
            int i;

            gameobj = collision.transform.gameObject;
            colided = gameobj.GetComponent<Ingredient>();
            i = (int)colided.nameI;

            
        }
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ingredient"))
        {
            GameObject gameobj;
            Ingredient colided;
            int i;

            gameobj = collision.transform.gameObject;
            colided = gameobj.GetComponent<Ingredient>();
            i = (int)colided.nameI;

            

           
        }
    }


    private void TestEnd()
    {
        int points;
        int i = 0;

        points = 10;
        

        Debug.Log(points);

    }
}
