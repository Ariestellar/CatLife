using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Уничтожаем ненужные префабы падающие за экран
public class DestroyFoodArcade01 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {        
        Destroy(other.gameObject);       
    }
    
}
