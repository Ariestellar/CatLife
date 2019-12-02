using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[System.Serializable]
public class Needs
{
    private int _needTimer;
    public float _currentIndexNeed { get; private set; }       
    public int _counter { get; private set; }
    public string _name {get; private set;}
    public Needs(string name, float currentIndexNeed, int needTimer, int _counter)
    {
        this._currentIndexNeed = currentIndexNeed;
        this._needTimer = needTimer;
        this._name = name;
    }

    public void DemandGrowth()
    {
        this._counter += 1;
        if (_counter == _needTimer)
        {
            this._currentIndexNeed +=0.1f;
            this._counter = 0;
        }        
    }

}

