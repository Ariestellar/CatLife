using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

//Недоделал
public class Skill 
{
    private int _costCard;
    private bool _usedСard;
    private string _name;

    public Skill(string name, int _costCard, bool _usedСard)
    {
        this._costCard = _costCard;
        this._usedСard = _usedСard;
        this._name = name;
    }

    public int BuyCards(int totalScore)
    {
        this._usedСard = false;
        return totalScore -= this._costCard;
    }    
}
