using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGrabing : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private float _velocity;
    private float _rotationVelocity;
    private float _rotationAngle;

    private Vector3 _newPosition;

    private GameObject _ingredient;
    private Rigidbody2D _rb2dIng;


    // Start is called before the first frame update
    void Start()
    {
        _velocity = 10f;
        _rotationVelocity = 15f;
        _rotationAngle = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Grab();
    }

    private void Grab()
    {
        _newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            CanGrab();

            if (_ingredient != null)
            {
                _rb2dIng = _ingredient.GetComponent<Rigidbody2D>();

                _rb2dIng.isKinematic = true;
                _rb2dIng.velocity = Vector2.zero;
                _rb2dIng.angularVelocity = 0;

                _newPosition = new Vector3(_newPosition.x, _newPosition.y, 0);

                _ingredient.transform.position += _velocity * Time.deltaTime * (_newPosition - _ingredient.transform.position);

                RotateIng();

            }
        }
        else
        {
            if (_ingredient != null)
            {
                if(_rb2dIng != null)
                {
                    _rb2dIng.isKinematic = false;
                    _rb2dIng = null;
                }


                _ingredient = null;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (_ingredient != null)
            {
                if (_rb2dIng != null)
                {
                    _rb2dIng.isKinematic = false;
                    _rb2dIng = null;
                }


                _ingredient = null;
            }
        }


       

       
    }


    private void RotateIng()
    {
        //rotate
        if (Input.GetKey(KeyCode.E))
        {

            _ingredient.transform.Rotate(Vector3.forward, -_rotationAngle * Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _ingredient.transform.Rotate(Vector3.forward, _rotationAngle * Time.deltaTime * _rotationVelocity);
        }
    }

    private void CanGrab()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(_newPosition, Vector3.up,1f);

        if (hit)
        {
            if (hit.transform.CompareTag("Ingredient"))
            {
                if (_ingredient == null)
                    _ingredient = hit.transform.gameObject;
            }
        }
    }
}
