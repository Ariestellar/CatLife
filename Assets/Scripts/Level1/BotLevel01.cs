using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Image _barWorkBot = null;
    private float _progressWorkBot;    

    [SerializeField] private float _currentTrafficForAnotherFloor = 0;//Номер текущего объекта к которому движется бот
    [SerializeField] private bool _needToGo = false;//Состояние движения бота false- пока не получил новую точку передвижения, true- получил новую точку
    [SerializeField] private bool _botStop = false;
   

    //Координаты объекта к которому нужно идти
    [SerializeField] private float _newTrafficPositionX;
    [SerializeField] private float _newTrafficPositionY;

    [SerializeField] public bool goAnotherFloor{ get; private set;}//Нужно ли воспользоваться дверью на другой этаж(если объект на другом этаже).

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;
    
    [SerializeField] private int _counter;
    [SerializeField] private int _counterPart;

    [SerializeField] public bool _doNotDisturb { get; private set; }//Статус человека, когда его можно беспокоить а когда нет

    void Start()
    {
        transform.position = _load.PositionBot();
        _traffic = GameObject.FindGameObjectsWithTag("Traffic");//Ищем объекта на сцене с тегом "Traffic"
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _counter = 100;
        _counterPart = 10;
        _barWorkBot.GetComponent<Image>().color = Color.green;
        _doNotDisturb = false;
        _progressWorkBot = 1;
        
    }

    private void FixedUpdate()
    {
        _barWorkBot.fillAmount = _progressWorkBot;
        _save.PositionBot(transform.position.x, transform.position.y, transform.position.z);

        

        if (_botStop)
        {            
            _counter -= 1;
            if (_counter % _counterPart == 0)
            {
                _progressWorkBot -= 0.1f;
            }
            if (_counter < _counterPart)
            {
                _botStop = false;                
                _progressWorkBot = 0;
                _counter = Random.Range(100, 1000);
                _counterPart = _counter / 10;
                if (_counter > 500)
                {
                    _barWorkBot.GetComponent<Image>().color = Color.green;
                    _doNotDisturb = false;
                    _progressWorkBot = 1;
                }
                else 
                {
                    _barWorkBot.GetComponent<Image>().color = Color.red;
                    _doNotDisturb = true;
                    _progressWorkBot = 1;
                }
                
            }
        }
        else 
        {
            if (_needToGo == false)//Если персонаж никуда не идет:
            {
                if (_currentTrafficForAnotherFloor != 0)//Если у персонажа текущий траффик не равен нулю, значит его цель находится на другом этаже:
                {
                    //когда бот доходит до двери т.е needToGo = false мы:
                    _newTrafficPositionX = _currentTrafficForAnotherFloor;//меняем ему ранее запомненную позицию на другом этаже
                    _currentTrafficForAnotherFloor = 0;//Необходимость искать дверь ставим на ноль
                    goAnotherFloor = false;
                }
                else//Иначе, при остановке, ищем другую позицию
                {
                    _botStop = true;
                    _numberRandomTraffic = Random.Range(0, _traffic.Length - 1);
                    _newTrafficPositionX = _traffic[_numberRandomTraffic].transform.position.x;
                    _newTrafficPositionY = _traffic[_numberRandomTraffic].transform.position.y;
                }
                //Если объект находится на другом этаже, то сначало задаем персонажу траекторию до двери
                if ((_newTrafficPositionY == -2.7f && _newTrafficPositionY < transform.position.y) || (_newTrafficPositionY == 5.5f && _newTrafficPositionY > transform.position.y))
                {
                    goAnotherFloor = true;
                    _currentTrafficForAnotherFloor = _newTrafficPositionX;//Записываем координаты объекта на другом этаже что бы потом их заменить
                    _newTrafficPositionX = 8;//ставим координаты двери в позицию для перемещения               
                }
                _needToGo = true;
                _animator.SetBool("IsWalk", true);

            }

            if (_needToGo)
            {
                DirectionCheck();
                _rigidBody2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(_newTrafficPositionX, transform.position.y), _speed));

                if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(_newTrafficPositionX, 0)) < 1)//если до позиции меньше одного пункта, то пришли:
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
