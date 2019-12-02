using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTotalText = null;   
    [SerializeField] private Image _barNaturalNeed = null;
    [SerializeField] private Image _barHunger = null;
    [SerializeField] private Image _barInstincts = null;
    [SerializeField] private GameData Data = null;

    private void Start()
    {
        Data = GetComponent<GameData>();        
    }

    private void FixedUpdate()
    {        
       _barNaturalNeed.fillAmount = Data._natural._currentIndexNeed;
       _barHunger.fillAmount = Data._hunger._currentIndexNeed;
       _barInstincts.fillAmount = Data._instincts._currentIndexNeed;
       _scoreTotalText.text = Convert.ToString(Data.ScoreTotal);

    }
    public void ShowProgressBar(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
    }
    public void ShowDownPanel(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}
