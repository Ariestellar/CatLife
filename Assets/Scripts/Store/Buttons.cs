using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject _failurePanel = null;
    [SerializeField] private GameObject _lookPanel = null;
    [SerializeField] private GameObject _skillPanel = null;    
    [SerializeField] private SaveDate _save = null;
    [SerializeField] private LoadDate _load = null;
    [SerializeField] private TMP_Text _scoreTotalText = null;
    [SerializeField] private int _scoreTotal = 0;

    public GameData gameData;

    private void Start()
    {
        _scoreTotal = _load.Score();       
        
    }
    private void FixedUpdate()
    {
        _scoreTotalText.text = Convert.ToString(_scoreTotal);
    }
    
    public void ShowLookPanel()
    {
        _lookPanel.SetActive(true);
        _skillPanel.SetActive(false);
    }

    public void ShowSkillPanel()
    {
        _skillPanel.SetActive(true);
        _lookPanel.SetActive(false);
    }

    public void ColorCat(string color)
    {        
        
        if (_scoreTotal < 100)
        {
            _failurePanel.SetActive(true);
        }
        else 
        {
            _save.CatsColor(color);
            _scoreTotal -= 100;
        }        
        
    }
    public void CloseFailurePanel()
    {
        _failurePanel.SetActive(false);
    }

    public void BackGame(string scene)
    {
        _save.Score(_scoreTotal);
        SceneManager.LoadScene(scene);
    }
}
