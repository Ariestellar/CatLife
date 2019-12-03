using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseGame : MonoBehaviour
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
