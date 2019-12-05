using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует управление игрока в Аркаде№1
public class PlayerControllerArcade01 : MonoBehaviour
{
    [SerializeField] private GameObject _panelLoos = null;//Панель проигрыша  
    [SerializeField] private GameObject _scripts = null;//Объект со скриптами
    //Классы
    [SerializeField] private ColorCatRenderer _rendererColor;
    [SerializeField] private LoadDate _load = null;
    //Свойство
    [SerializeField] public int _score { get; private set; }
    private void Start()
    {
        _score = 0;
        _rendererColor = _scripts.GetComponent<ColorCatRenderer>();
        
        GetComponent<SpriteRenderer>().color = _rendererColor.SetColor(_load.CatsColor());
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);        
        transform.position = new Vector3(objPosition.x,transform.position.y,transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sausage")
        {            
            _score += 10;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Snag")
        {
            _score += 20;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Spoon")
        {
            _panelLoos.SetActive(true);
            Time.timeScale = 0;            
        }
    }

}
