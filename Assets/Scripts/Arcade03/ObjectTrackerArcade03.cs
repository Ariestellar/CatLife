using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrackerArcade03 : MonoBehaviour
{
    [SerializeField] private GameObject _objectTarget = null;
    private float _far = -10;
    void Update()
    {
        if(_objectTarget.transform.position.y >= transform.position.y)
        transform.position = new Vector3(_objectTarget.transform.position.x, _objectTarget.transform.position.y, _far);
        else if (_objectTarget.transform.position.y < transform.position.y)
        transform.position = new Vector3(_objectTarget.transform.position.x, transform.position.y, _far);

    }
}
