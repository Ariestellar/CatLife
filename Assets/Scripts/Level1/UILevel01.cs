using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UILevel01 : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTotalText = null;   
    [SerializeField] private Image _barNaturalNeed = null;
    [SerializeField] private Image _barHunger = null;
    [SerializeField] private Image _barInstincts = null;
    [SerializeField] private CatIndicators _data = null;

    private void Start()
    {
        _data = GetComponent<CatIndicators>();        
    }

    private void FixedUpdate()
    {        
       _barNaturalNeed.fillAmount = _data._natural._currentIndexNeed;
       _barHunger.fillAmount = _data._hunger._currentIndexNeed;
       _barInstincts.fillAmount = _data._instincts._currentIndexNeed;
       _scoreTotalText.text = Convert.ToString(_data._scoreTotal);

    }

    //Кнопки на сцене
    public void ShowProgressBar(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
    }
    public void ShowDownPanel(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
    public void PlayArcade01()
    {
        SceneManager.LoadScene("Arcade01");
    }
    public void PlayArcade02()
    {
        SceneManager.LoadScene("Arcade02");
    }
    public void PlayArcade03()
    {
        SceneManager.LoadScene("Arcade03");
    }
    public void ExitLevel(string LevelLabel)
    {
        SceneManager.LoadScene(LevelLabel);
    }
}
