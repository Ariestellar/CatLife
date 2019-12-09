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
    [SerializeField] private LoadDate _load = null;


    [SerializeField] private GameObject _learningPanel = null;
    [SerializeField] private bool _learningPanelShow;


    private void Start()
    {
        _learningPanelShow = _load.LerningPanelArcade01();
        if (!_learningPanelShow) 
        {
            _learningPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
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

    public void ShowLerningPanel()
    {
        _learningPanel.SetActive(false);
        _learningPanelShow = true;
        _save.LerningPanelArcade01(_learningPanelShow);
        Time.timeScale = 1;
    }
}
