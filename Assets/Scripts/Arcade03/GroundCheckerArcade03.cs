using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Реализует проверку нахождения на земле игрока
public class GroundCheckerArcade03 : MonoBehaviour
{
    [SerializeField] private GameObject _checkGroundPoint = null;
    [SerializeField] private LayerMask _isGround = 0;
    private float _radiusCircle = 0.2f;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(_checkGroundPoint.transform.position, _radiusCircle, _isGround);
    }
    
}
