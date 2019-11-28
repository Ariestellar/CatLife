using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{    
    [SerializeField] private GameObject [] _food = null;
    [SerializeField] private float _timer = 50f;//50f = 1 сек

    private float _counter;
    private BoxCollider2D _collider;
    private float _halfSize;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _halfSize = _collider.size.x / 2;
    }

    private void FixedUpdate()
    {
        _counter -= 1;
        if (_counter < 0)
        {
            Drop();
            _counter = _timer;
        }
            
    }

    private void Drop()
    {
        Instantiate(_food[Random.Range(0,_food.Length)], new Vector2(Random.Range(transform.position.x - _halfSize, transform.position.x + _halfSize),transform.position.y),Quaternion.identity);        
    }
}
