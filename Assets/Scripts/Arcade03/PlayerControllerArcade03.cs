using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
//Реализует управление игрока в Аркаде№3
public class PlayerControllerArcade03 : MonoBehaviour
{    
    [SerializeField] private GameObject _scripts = null;//объект со скриптами
    //Классы    
    [SerializeField] private LoadDate _load = null;    
    [SerializeField] private ColorCatRenderer _rendererColor;
    private Rigidbody2D _rigidBody2d;
    private GroundCheckerArcade03 _groundChecker;
    //Поля
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _speed = 0.2f;
    private float _direction;

    private void Start()
    {
        _rendererColor = _scripts.GetComponent<ColorCatRenderer>();             
        _groundChecker = GetComponent<GroundCheckerArcade03>();               
        _rigidBody2d = GetComponent<Rigidbody2D>();
        //рендерим цвет персонажу подгружая его из памяти и обрабатывая методом
        GetComponent<SpriteRenderer>().color = _rendererColor.SetColor(_load.CatsColor());
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
