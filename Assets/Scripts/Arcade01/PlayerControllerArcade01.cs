using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArcade01 : MonoBehaviour
{
    [SerializeField] private GameObject _panelLoos = null;
    [SerializeField] public static int Score;

    private void Start()
    {
        Score = 0;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 100f, 10f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);        
        transform.position = objPosition; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sausage")
        {            
            Score += 10;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Snag")
        {
            Score += 20;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Spoon")
        {
            _panelLoos.SetActive(true);
            Time.timeScale = 0;            
        }
    }

}
