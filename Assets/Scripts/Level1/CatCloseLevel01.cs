using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCloseLevel01 : MonoBehaviour
{
    //Тригер для определения близости кота
    [SerializeField] public bool _catClose { get; private set; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            _catClose = true;
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            _catClose = false;
        
    }
    
}
