using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует окончание игры, игрок падает за камеру и пересекает объект
public class LooseGameArcade03 : MonoBehaviour
{    
    [SerializeField] private GameObject _loosePanel = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _loosePanel.SetActive(true);
        }
       
    }

}
