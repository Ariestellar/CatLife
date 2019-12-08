using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerControllerLevel01 : MonoBehaviour
{
    [SerializeField] private bool _needToGo = false;
    [SerializeField] public static float PositionPlayerX;
    [SerializeField] public static float PositionPlayerY;

    [SerializeField] private ColorCatRenderer _rendererColor;
    [SerializeField] private GameObject _scripts = null;
    [SerializeField] private GameObject _screamSprite = null;

    //[SerializeField] private AudioClip _scream = null;
    //private AudioSource _audio;

    private Rigidbody2D _rigidBody2d;
    private Animator _animator;    
    private float _speed = 0.2f;
    private Vector2 _worldPos;

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    private void Start()
    {
        _rendererColor = _scripts.GetComponent<ColorCatRenderer>();        
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_audio = GetComponent<AudioSource>();


        GetComponent<SpriteRenderer>().color = _rendererColor.SetColor(_load.CatsColor());

        transform.position = _load.PositionPlayer();        
    }
    
    private void FixedUpdate()
    {
        _save.PositionPlayer(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonUp(0) == true)
        {
            Vector2 mousePos = Input.mousePosition;
            if (Input.mousePosition.y < 455.4f && Input.mousePosition.y > 331.1f)
            {
                _worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                _needToGo = true;
                _animator.SetBool("IsWalk", true);

            }

        }
        //Debug.Log(Input.mousePosition);
        if (_worldPos.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            _screamSprite.transform.localScale = new Vector2(-1, 1);
        }
        else if(_worldPos.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
            _screamSprite.transform.localScale = new Vector2(1, 1);
        }

        if (_needToGo)
        {
            _rigidBody2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(_worldPos.x, transform.position.y), _speed));

            if (Vector2.Distance(new Vector2(transform.position.x,0), new Vector2(_worldPos.x,0)) < 1)
            {
                _animator.SetBool("IsWalk", false);
                _needToGo = false;
            }            
        }        
    }
    //Нажимаем по кнопке двери и перемещаемся на другой этаж
    public void OnClickGoAnotherFloor()
    {
        if (transform.position.y < 0f)
        {
            transform.position = new Vector2(transform.position.x, 4f);
        }
        else if (transform.position.y > 0f)
        {
            transform.position = new Vector2(transform.position.x, -4f);
        }
    }
    //Попадаем в триггер Аркады
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arcade")
        {
            other.GetComponent<Image>().enabled = true;
        }
    }
    //Выходим из тригерра Аркады
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Arcade")
        {
            other.GetComponent<Image>().enabled = false;
        }
    }

   /*public void CatScream()
    {
        this._counter += 1;
        if (_counter == _needTimer)
        {
            _scripts.GetComponent<UILevel01>().addMajorProgress(-0.1f);
            _screamSprite.SetActive(true);
            this._counter = 0;
        }
        
        //_audio.PlayOneShot(_scream);
    }*/

}
