using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
//Реализует передвижения и действия бота в игре
public class BotLevel01 : MonoBehaviour
{
    private GameObject[] _traffic;//Массив с точками передвижения
    private Rigidbody2D _rigidBody2d;
    private Animator _animator;
    private float _speed = 0.1f;//Скорость движения
    private int _numberRandomTraffic;

    [SerializeField] private float _currentTraffic = 0;//Номер текущего объекта к которому движется бот
    [SerializeField] private bool _needToGo = false;//Состояние движения бота false- пока не получил новую точку передвижения, true- получил новую точку
    //Координаты объекта к которому нужно идти
    [SerializeField] private float _newTrafficPositionX;
    [SerializeField] private float _newTrafficPositionY;

    [SerializeField] public bool goAnotherFloor{ get; private set;}//Нужно ли воспользоваться дверью на другой этаж(если объект на другом этаже).

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    void Start()
    {
        transform.position = _load.PositionBot();
        _traffic = GameObject.FindGameObjectsWithTag("Traffic");//Ищем объекта на сцене с тегом "Traffic"
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _save.PositionBot(transform.position.x, transform.position.y, transform.position.z);
        if (_needToGo == false)
        {
            if (_currentTraffic != 0)
            {
                _newTrafficPositionX = _currentTraffic;
                _currentTraffic = 0;
                goAnotherFloor = false;
            }
            else
            {
                _numberRandomTraffic = Random.Range(0, _traffic.Length - 1);
                _newTrafficPositionX = _traffic[_numberRandomTraffic].transform.position.x;
                _newTrafficPositionY = _traffic[_numberRandomTraffic].transform.position.y;
            }
            
            if ((_newTrafficPositionY == -2.7f && _newTrafficPositionY < transform.position.y) || (_newTrafficPositionY == 5.5f && _newTrafficPositionY > transform.position.y))
            {
                goAnotherFloor = true;
                _currentTraffic = _newTrafficPositionX;
                _newTrafficPositionX = 8;
               
            }           
            _needToGo = true;
            _animator.SetBool("IsWalk", true);          
            
        }
       
        if (_needToGo)
        {
            DirectionCheck();
            _rigidBody2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(_newTrafficPositionX, transform.position.y), _speed));

            if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(_newTrafficPositionX, 0)) < 1)
            {
                _animator.SetBool("IsWalk", false);
                _needToGo = false;
                if (_newTrafficPositionY == -2.7f)
                {
                    transform.position = new Vector2(transform.position.x, -2.7f);
                }
                else if (_newTrafficPositionY == 5.5f)
                {
                    transform.position = new Vector2(transform.position.x, 5.6f);
                }
            }
        }
    }
    //Определяет направление спрайта
    private void DirectionCheck()
    {
        if (_newTrafficPositionX > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_newTrafficPositionX < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
