using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
//Реализует UI для Аркады03
public class UIArcade03 : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText = null;
    [SerializeField] private SaveDate _save = null;
    [SerializeField] private LoadDate _load = null;

    [SerializeField] private GameObject _learningPanel = null;
    [SerializeField] private bool _learningPanelShow;

    private void Start()
    {
        _learningPanelShow = _load.LerningPanelArcade02();
        if (!_learningPanelShow)
        {
            _learningPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void Update()
    {
        _scoreText.text = Convert.ToString(GetComponent<ScriptGameArcade03>()._score);
    }
    public void ExitArcade(string level)
    {
        SceneManager.LoadScene(level);
        _save.ScoreArcade03(GetComponent<ScriptGameArcade03>()._score);
    }
    public void ShowLerningPanel()
    {
        _learningPanel.SetActive(false);
        _learningPanelShow = true;
        _save.LerningPanelArcade02(_learningPanelShow);
        Time.timeScale = 1;
    }
}
