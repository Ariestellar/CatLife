using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameData : MonoBehaviour
{  

    [Header("Потребности")]
    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;
    [SerializeField] public Needs _natural { get; private set; }
    [SerializeField] public Needs _hunger { get; private set; }
    [SerializeField] public Needs _instincts { get; private set; }

    [Header("Карточки навыков")]
    [SerializeField] private int _card1;
    [SerializeField] private int _card2;
    [SerializeField] private int _card3;

    [Header("Счёт")]
    [SerializeField] public int ScoreTotal;  


    private void Start()
    {
        _natural = _load.Needs("Naturals", 750);
        _hunger = _load.Needs("Hunger", 500);
        _instincts = _load.Needs("Instincts", 900);

        ScoreTotal = _load.Score();
        ScoreTotal += _load.ScoreArcade01();
        ScoreTotal += _load.ScoreArcade02();
        ScoreTotal += _load.ScoreArcade03();
    }
    private void FixedUpdate()
    {        
        _natural.DemandGrowth();
        _hunger.DemandGrowth();
        _instincts.DemandGrowth(); 
        
        _save.Score(ScoreTotal);
        _save.CatsNeeds(_natural);
        _save.CatsNeeds(_hunger);
        _save.CatsNeeds(_instincts);
    }

    public Color SetColor(string color)
    {       
        switch (color)
        {
            case "Red":
                return new Color(255, 0, 0, 255);                
            case "Blue":
                return new Color(0, 0, 255, 255);                
            case "Black":
                return new Color(0, 0, 0, 255);                
            case "Orange":
                return new Color(255, 100, 0, 255);
            case "White":
                return new Color(255, 255, 255, 255);
            default:
                return new Color(255, 255, 255, 255);                
        }
    }



}
