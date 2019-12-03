using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameArcade03 : MonoBehaviour
{
    [SerializeField] private GameObject _shelfSpot = null;
    [SerializeField] public static int Score;   

    void Start()
    {
        Score = 0;
    }

    void FixedUpdate()
    {
       
    }

    public void RespawnShelfSpot()
    {
        Instantiate(_shelfSpot, new Vector2(Random.Range(-5, 5), Random.Range(3, -3)), Quaternion.identity);
    }
}
