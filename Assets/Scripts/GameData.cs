using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    [Header("Потребности")]
    [SerializeField] private int _naturalNeed;
    [SerializeField] private int _hunger;
    [SerializeField] private int _instincts;

    [Header("Карточки навыков")]
    [SerializeField] private int _card1;
    [SerializeField] private int _card2;
    [SerializeField] private int _card3;

    [Header("Счёт")]
    [SerializeField] public int ScoreTotal;

    private void Start()
    {
        ScoreTotal = _load.Score();
        ScoreTotal += _load.ScoreArcade01();
    }
    private void Update()
    {
        _save.Score(ScoreTotal);
    }


}
