using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerControllerArcade03 : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;       
    private float _direction;
    private GroundChecker _groundChecker = null;
    [SerializeField] private LoadDate _load = null;
    [SerializeField] private GameData _gameData;
    [SerializeField] private string _colorCat;
    [SerializeField] private GameObject _scripts = null;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _speed = 0.2f;

    private void Start()
    {
        _gameData = _scripts.GetComponent<GameData>();
        _colorCat = _load.CatsColor();
        GetComponent<SpriteRenderer>().color = _gameData.SetColor(_colorCat);

        _groundChecker = GetComponent<GroundChecker>();               
        _rigidBody2d = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CheckGround())
            _rigidBody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        _direction = Input.GetAxis("Horizontal");
        _rigidBody2d.velocity = new Vector2(_direction*_speed, _rigidBody2d.velocity.y);
        if (_direction < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_direction > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }
}
