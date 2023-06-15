using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGrabing : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;

    private Vector3 _newPosition;

    private GameObject _ingredient;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            if (_ingredient != null)
            {
                _ingredient.GetComponent<Rigidbody2D>().isKinematic = true;
                _ingredient.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                _newPosition = new Vector3(_newPosition.x, _newPosition.y, 0);

                _ingredient.transform.position += (_newPosition - _ingredient.transform.position) * Time.deltaTime * 10;
                // _ingredient.transform.position = new Vector3(_newPosition.x, _newPosition.y, -2);
            }
        }
        else
        {
            if (_ingredient != null)
            {
                _ingredient.GetComponent<Rigidbody2D>().isKinematic = false;
                _ingredient = null;
            }
        }
        

        RaycastHit2D hit;

        hit = Physics2D.Raycast(_newPosition, _newPosition);
       
        if(hit)
        {
            if(hit.transform.CompareTag("Ingredient"))
            {
                if(_ingredient == null)
                _ingredient = hit.transform.gameObject;
            }
        }
    }
}
