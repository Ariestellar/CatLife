using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickClawSpotArcade02 : MonoBehaviour
{    
    void OnMouseDown()
    {
        GameObject.Find("Scripts").GetComponent<ScriptGameArcade02>().IncreaseScore(10);//Поиск объекта со скриптами по имени так как префабы не могут получить объект заранее
        Destroy(gameObject);
    }   
}
