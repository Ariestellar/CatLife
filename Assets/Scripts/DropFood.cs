using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    private BoxCollider2D _collider;
    private float _halfSize;
    private GameObject _food;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _halfSize = _collider.size.x / 2;
    }

    public void Drop()
    {
        Instantiate(_food, new Vector2(Random.Range(transform.position.x - _halfSize, transform.position.x + _halfSize),transform.position.y),Quaternion.identity);
        
    }
}
