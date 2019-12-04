using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует уничтожение объектов вне камеры снизу, одновременно респавн объектов сверху на 18 пунктов и считает объекты которые уже были преодоленны игроком
public class DestroyerArcade03 : MonoBehaviour
{    
    [SerializeField] private GameObject _scripts = null;

    private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.tag == "Shelf") 
        {            
            _scripts.GetComponent<ScriptGameArcade03>().IncreaseScore(10);            
            _scripts.GetComponent<ScriptGameArcade03>().RespawnShelfSpot(transform.position.y + 18);
            Destroy(collision.gameObject);
        }
                
    }
   
}
