using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameArcade02 : MonoBehaviour
{
    [SerializeField] private GameObject _clawSpot = null;
    [SerializeField] public static int Score;
    [SerializeField] private int _timer = 50;

    private float _counter;

    void Start()
    {
        Score = 0;
    }
    
    void FixedUpdate()
    {
        _counter -= 1;
        if (_counter < 0)
        {
            RespawnClawSpot();
            _counter = _timer;
        }
    }

    public void RespawnClawSpot()
    {
        Instantiate(_clawSpot, new Vector2(Random.Range(-5, 5), Random.Range(3, -3)), Quaternion.identity);
    }
}
