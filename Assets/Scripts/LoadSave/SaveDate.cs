using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveDate
{
    public void Score(int scoreTotal)
    {
        PlayerPrefs.SetInt("ScoreTotal", scoreTotal);
    }
    public void ScoreArcade01(int scoreArcade01)
    {
        PlayerPrefs.SetInt("ScoreArcade01", scoreArcade01);
    }
    public void ScoreArcade02(int scoreArcade02)
    {
        PlayerPrefs.SetInt("ScoreArcade02", scoreArcade02);
    }
    public void ScoreArcade03(int scoreArcade03)
    {
        PlayerPrefs.SetInt("ScoreArcade03", scoreArcade03);
    }
    public void PositionPlayer(float positionX, float positionY, float positionZ)
    {
        PlayerPrefs.SetFloat("PositionPlayerX", positionX);
        PlayerPrefs.SetFloat("PositionPlayerY", positionY);
        PlayerPrefs.SetFloat("PositionPlayerZ", positionZ);
    }
    public void PositionBot(float positionX, float positionY, float positionZ)
    {
        PlayerPrefs.SetFloat("PositionBotX", positionX);
        PlayerPrefs.SetFloat("PositionBotY", positionY);
        PlayerPrefs.SetFloat("PositionBotZ", positionZ);
    }
    public void CatsNeeds(Needs needs)
    {
        PlayerPrefs.SetFloat($"Index{needs._name}Needs", needs._currentIndexNeed);
        PlayerPrefs.SetFloat($"Counter{needs._name}Needs", needs._counter);       
    }

    public void CatsColor(string color)
    {        
        PlayerPrefs.SetString ("CatsColor", color);        
    }

    public void MajorProgress(float majorProgress)
    {
        PlayerPrefs.SetFloat("MajorProgress", majorProgress);
    }
    public void StatusUIPanels(int showProgressBar, int showDownPanel)
    {
        PlayerPrefs.SetInt("ShowProgressBar", showProgressBar);
        PlayerPrefs.SetInt("ShowDownPanel", showDownPanel);
    }

    public void TutorialPanel (int tutorialCompleted)
    {
        PlayerPrefs.SetInt("TutorialCompleted", tutorialCompleted);        
    }
    public void UsedCard(Skill usedCard)
    {
        PlayerPrefs.SetInt($"UsedCard{usedCard._name}", Convert.ToInt32(usedCard._usedСard));
    }

    public void LerningPanelArcade01(bool lerningPanel)
    {
        PlayerPrefs.SetInt($"LerningPanelArcade01", Convert.ToInt32(lerningPanel));
    }

    public void LerningPanelArcade02(bool lerningPanel)
    {
        PlayerPrefs.SetInt($"LerningPanelArcade02", Convert.ToInt32(lerningPanel));
    }

}
