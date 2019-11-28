using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]private GameObject _checkGroundPoint = null;
    [SerializeField] private LayerMask _isGround = 0;
    private float _radiusCircle = 0.2f;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.transform.position, _radiusCircle, _isGround);
    }
    
}
