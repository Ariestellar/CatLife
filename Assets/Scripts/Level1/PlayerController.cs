using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool _needToGo = false;
    [SerializeField] public static float PositionPlayerX;
    [SerializeField] public static float PositionPlayerY;

    [SerializeField]  private string _colorCat;
    [SerializeField] private GameObject _scripts = null;
    private GameData _gameData;    

    private Rigidbody2D _rigidBody2d;
    private Animator _animator;    
    private float _speed = 0.2f;
    private Vector2 _worldPos;

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    private void Start()
    {
        _gameData = _scripts.GetComponent<GameData>();
        _colorCat = _load.CatsColor();                                        
        GetComponent<SpriteRenderer>().color = _gameData.SetColor(_colorCat);
        transform.position = _load.PositionPlayer();
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        _save.PositionPlayer(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonUp(0) == true)
        {
            Vector2 mousePos = Input.mousePosition;
            _worldPos = Camera.main.ScreenToWorldPoint(mousePos);            
            _needToGo = true;
            _animator.SetBool("IsWalk", true);
        }        

        if (_worldPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(_worldPos.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arcade")
        {
            other.GetComponent<Image>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Arcade")
        {
            other.GetComponent<Image>().enabled = false;
        }
    }


}
