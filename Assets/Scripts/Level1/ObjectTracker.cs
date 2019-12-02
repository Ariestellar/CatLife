using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    [SerializeField] private GameObject _objectTarget = null;
    private float _far = -10;
    void Update()
    {
        transform.position = new Vector3(_objectTarget.transform.position.x, _objectTarget.transform.position.y, _far);
        
    }
}
