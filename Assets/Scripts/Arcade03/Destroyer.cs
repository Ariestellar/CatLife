using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject _shelfPrefab = null;
    private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.tag == "Shelf") 
        {
            ScriptGameArcade03.Score += 10;
            Instantiate(_shelfPrefab, new Vector3(Random.Range(-5, 5), transform.position.y + 18, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);
        }
                
    }
   
}
