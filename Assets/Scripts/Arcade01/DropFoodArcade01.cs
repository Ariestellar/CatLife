using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует респавн префабов еды в аркаде.
public class DropFoodArcade01 : MonoBehaviour
{    
    [SerializeField] private GameObject [] _food = null;//Массив префабов еды.
    [SerializeField] private int _timer = 50;//Для отсчета респавна. 50 единиц с FixedUpdate = 1сек.

    private int _counter;
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
