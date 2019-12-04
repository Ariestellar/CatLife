using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIArcade01 : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;//Получить объект на котором висит скрипт класса, чтобы изнего получить счет
    [SerializeField] private TMP_Text _scoreText = null;
    [SerializeField] private SaveDate _save = null;
    
    private void Update()
    {        
        _scoreText.text = Convert.ToString(_player.GetComponent<PlayerControllerArcade01>()._score);
    }
    public void ExitArcade(string level)
    {
        SceneManager.LoadScene(level);
        _save.ScoreArcade01(_player.GetComponent<PlayerControllerArcade01>()._score);        
        Time.timeScale = 1;//Запускаем время игры, так как до этого при проигрыше оно останавливалось
    }    
}
