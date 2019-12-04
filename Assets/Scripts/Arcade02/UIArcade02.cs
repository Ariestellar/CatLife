using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIArcade02 : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText = null;
    [SerializeField] private SaveDate _save = null;   
    private void Update()
    {
        _scoreText.text = Convert.ToString(GetComponent<ScriptGameArcade02>()._score);
    }
    public void ExitArcade(string level)
    {
        SceneManager.LoadScene(level);
        _save.ScoreArcade02(GetComponent<ScriptGameArcade02>()._score);        
    }
}
