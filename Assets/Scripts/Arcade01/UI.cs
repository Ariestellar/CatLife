using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText = null;
    private void Update()
    {
        _scoreText.text = Convert.ToString(PlayerControllerArcade01.Score);
    }
    public void ExitArcade(string level)
    {
        SceneManager.LoadScene(level);
        PlayerPrefs.SetInt("ScoreArcade01", PlayerControllerArcade01.Score);
        Time.timeScale = 1;
    }    
}
