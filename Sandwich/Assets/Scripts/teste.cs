using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{

    [SerializeField]
    private Camera _mainCamera;

    private Vector3 _newPosition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = new Vector3(_newPosition.x,_newPosition.y,-2);
    }
}
