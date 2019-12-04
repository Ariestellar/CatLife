using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует движение камеры за игроком на сцене Level01
public class ObjectTrackerLevel01 : MonoBehaviour
{
    [SerializeField] private GameObject _objectTarget = null;
    private float _far = -10;
    void Update()
    {
        transform.position = new Vector3(_objectTarget.transform.position.x, _objectTarget.transform.position.y, _far);        
    }
}
