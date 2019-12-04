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
    private void Update()
    {
        _scoreText.text = Convert.ToString(GetComponent<ScriptGameArcade03>()._score);
    }
    public void ExitArcade(string level)
    {
        SceneManager.LoadScene(level);
        _save.ScoreArcade03(GetComponent<ScriptGameArcade03>()._score);
    }
}
