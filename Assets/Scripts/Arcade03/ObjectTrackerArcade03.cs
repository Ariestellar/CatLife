using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует следование камеры за игроком 
public class ObjectTrackerArcade03 : MonoBehaviour
{
    [SerializeField] private GameObject _objectTarget = null;
    private float _far = -10;
    void Update()
    {
        if(_objectTarget.transform.position.y >= transform.position.y)//если игрок прыгает то камера следует за ним
        transform.position = new Vector3(_objectTarget.transform.position.x, _objectTarget.transform.position.y, _far);
        else if (_objectTarget.transform.position.y < transform.position.y)//если игрок падает то камера не следует за ним
        transform.position = new Vector3(_objectTarget.transform.position.x, transform.position.y, _far);

    }
}
