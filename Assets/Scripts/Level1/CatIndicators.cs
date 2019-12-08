using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CatIndicators : MonoBehaviour
{      
    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    [SerializeField] public Needs _natural { get; private set; }
    [SerializeField] public Needs _hunger { get; private set; }
    [SerializeField] public Needs _instincts { get; private set; }    
    
    [SerializeField] public int _scoreTotal { get; private set; }
    private int _scoreArcade01;
    private int _scoreArcade02;
    private int _scoreArcade03;



    private void Start()
    {
        _natural = _load.Needs("Naturals", 750);
        _hunger = _load.Needs("Hunger", 500);
        _instincts = _load.Needs("Instincts", 900);

        _scoreArcade01 = _load.ScoreArcade01();
        _scoreArcade02 = _load.ScoreArcade02();
        _scoreArcade03 = _load.ScoreArcade03();
        
        _scoreTotal = _load.Score();

        _scoreTotal += _scoreArcade01;
        if (_scoreArcade01 > 0)
        {
            _hunger.FillTheNeed();
        }

        _scoreTotal += _scoreArcade02;

        _scoreTotal += _scoreArcade03;        
        if (_scoreArcade03 > 0)
        {
            _instincts.FillTheNeed();
        }

    }
    private void FixedUpdate()
    {        
        _natural.DemandGrowth();
        _hunger.DemandGrowth();
        _instincts.DemandGrowth(); 
        
        _save.Score(_scoreTotal);
        _save.CatsNeeds(_natural);
        _save.CatsNeeds(_hunger);
        _save.CatsNeeds(_instincts);
    }

    public void ToSpendScore(int coast)
    {
        _scoreTotal -= coast;
    }
}
