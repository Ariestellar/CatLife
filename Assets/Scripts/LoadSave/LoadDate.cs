using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LoadDate
{    
    public int Score()
    {        
        if (PlayerPrefs.HasKey("ScoreTotal"))
        {
            return PlayerPrefs.GetInt("ScoreTotal");
        }
        else
        {
            return 0;
        }        
    }
    public int ScoreArcade01()
    {
        int score;

        if (PlayerPrefs.HasKey("ScoreArcade01"))
        {
            score = PlayerPrefs.GetInt("ScoreArcade01");
            PlayerPrefs.DeleteKey("ScoreArcade01");
        }
        else 
        {
            score = 0;
        }
        return score;
    }
    public int ScoreArcade02()
    {
        int score;

        if (PlayerPrefs.HasKey("ScoreArcade02"))
        {
            score = PlayerPrefs.GetInt("ScoreArcade02");
            PlayerPrefs.DeleteKey("ScoreArcade02");
        }
        else
        {
            score = 0;
        }
        return score;
    }
    public int ScoreArcade03()
    {
        int score;

        if (PlayerPrefs.HasKey("ScoreArcade03"))
        {
            score = PlayerPrefs.GetInt("ScoreArcade03");
            PlayerPrefs.DeleteKey("ScoreArcade03");
        }
        else
        {
            score = 0;
        }
        return score;
    }
    public Vector3 PositionPlayer()
    {        
        if (PlayerPrefs.HasKey("PositionPlayerX"))
        {
            return new Vector3(PlayerPrefs.GetFloat("PositionPlayerX"), PlayerPrefs.GetFloat("PositionPlayerY"), PlayerPrefs.GetFloat("PositionPlayerZ"));
        }
        else
        {
            return new Vector3(20f, -4.1f, 0f);
        }
    }
    public Vector3 PositionBot()
    {
        if (PlayerPrefs.HasKey("PositionBotX"))
        {
            return new Vector3(PlayerPrefs.GetFloat("PositionBotX"), PlayerPrefs.GetFloat("PositionBotY"), PlayerPrefs.GetFloat("PositionBotZ"));
        }
        else
        {
            return new Vector3(0f, -2.57f, 0f);
        }
    }

    public Needs Needs(string name, int timer)
    {        
        if (PlayerPrefs.HasKey($"Index{name}Needs"))
        {
            return new Needs(name, PlayerPrefs.GetFloat($"Index{name}Needs"), timer, PlayerPrefs.GetInt($"Counter{name}Needs"));
        }
        else
        {
            return new Needs(name, 0, timer, 0);
        }
    }

    public string CatsColor()
    {
        if (PlayerPrefs.HasKey("CatsColor"))
        {
            
            return PlayerPrefs.GetString("CatsColor");
        }
        else
        {
            return "White";
        }        
    }

}
