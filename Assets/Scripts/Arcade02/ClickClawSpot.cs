using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickClawSpot : MonoBehaviour//, IPointerDownHandler
{
    void OnMouseDown()
    {
        ScriptGameArcade02.Score += 10;
        Destroy(gameObject);
    }   
}
