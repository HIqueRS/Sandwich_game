using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Configurations;

public class BaseBread : MonoBehaviour
{
   
    

    private List<EnumIngridient> _ingredients;
    private List<EnumIngridient> _orderIngredient;

    private int points;

    // Start is called before the first frame update
    void Start()
    {
        //_ingredient = new bool[6];

        _ingredients = new List<EnumIngridient>();
        _orderIngredient = new List<EnumIngridient>();
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
            

            gameobj = collision.transform.gameObject;
            colided = gameobj.GetComponent<Ingredient>();

            if(colided.nameI != EnumIngridient.BreadTop)
            {
                _ingredients.Add(colided.nameI);
            }
            else
            {
                TestEnd();
            }
           
            
        }
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ingredient"))
        {
            GameObject gameobj;
            Ingredient colided;
           

            gameobj = collision.transform.gameObject;
            colided = gameobj.GetComponent<Ingredient>();


            _ingredients.Remove(colided.nameI);

           
        }
    }


    private void TestEnd()
    {
        
       

        points = 10;

        _orderIngredient.Clear();

        foreach (EnumIngridient item in GameManager.Instance.currentSandwich.ingredient)
        {
            _orderIngredient.Add(item);
        }

        for (int i = 0; i < _ingredients.Count; i++)
        {
            if(_orderIngredient.Contains(_ingredients[i]))
            {
                _orderIngredient.Remove(_ingredients[i]);

                points += 30;
            }
            else
            {
                points -= 30;
            }
            
        }

        foreach (EnumIngridient item in _orderIngredient)
        {
            points -= 30;
        }

        StartCoroutine(EndSandwich());
        
       

    }

    IEnumerator EndSandwich()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.points += points;
        GameManager.Instance.RestStateFunction();
    }
}
