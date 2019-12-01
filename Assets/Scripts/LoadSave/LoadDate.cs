﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LoadDate
{
    public int Score()
    {
        return PlayerPrefs.GetInt("ScoreTotal");
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
    public Vector3 PositionPlayer()
    {
        Vector3 position = new Vector3(PlayerPrefs.GetFloat("PositionPlayerX"), PlayerPrefs.GetFloat("PositionPlayerY"), PlayerPrefs.GetFloat("PositionPlayerZ"));
        return position;
    }
    public Vector3 PositionBot()
    {
        Vector3 position = new Vector3(PlayerPrefs.GetFloat("PositionBotX"), PlayerPrefs.GetFloat("PositionBotY"), PlayerPrefs.GetFloat("PositionBotZ"));
        return position;
    }

    public Needs Needs(string name, int timer)
    {
        Needs needs;
        if (PlayerPrefs.HasKey($"Index{name}Needs"))
        {
            return needs = new Needs(name, PlayerPrefs.GetFloat($"Index{name}Needs"), timer, PlayerPrefs.GetInt($"Counter{name}Needs"));
        }
        else
        {
            return needs = new Needs(name, 0, timer, 0);
        }
    }

   }
