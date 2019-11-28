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
}
