using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameArcade03 : MonoBehaviour
{
    [SerializeField] private GameObject _shelfPrefab = null;
    [SerializeField] public int _score {  get; private set; }   

    void Start()
    {
        _score = 0;
    }
    //Респавн предметов для аркады очков в Аркаде
    public void RespawnShelfSpot(float positionY)
    {
        Instantiate(_shelfPrefab, new Vector2(Random.Range(-5, 5), positionY), Quaternion.identity);
    }
    //Получение очков в Аркаде
    public void IncreaseScore(int numberPoints)
    {
        _score += numberPoints;
    }
}
