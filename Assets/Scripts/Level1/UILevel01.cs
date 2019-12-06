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
    //[SerializeField] private PlayerControllerLevel01 _playerController = null;

    [SerializeField] private Image _barPositiveMajorProgress = null;
    [SerializeField] private Image _barNegativeMajorProgress = null;

    [SerializeField] public float _majorProgress { get; private set; }

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;

    private void Start()
    {
        _data = GetComponent<CatIndicators>();
        _majorProgress = _load.MajorProgress();
    }

    private void FixedUpdate()
    {
        _save.MajorProgress(_majorProgress);
        if (_majorProgress > 0)
        {
            _barPositiveMajorProgress.fillAmount = _majorProgress;
            _barNegativeMajorProgress.fillAmount = 0;
        }
        else if (_majorProgress < 0)
        {
            _barNegativeMajorProgress.fillAmount = -_majorProgress;
            _barPositiveMajorProgress.fillAmount = 0;
        }
        else 
        {
            _barPositiveMajorProgress.fillAmount = 0;
            _barNegativeMajorProgress.fillAmount = 0;
        }             

       _barNaturalNeed.fillAmount = _data._natural._currentIndexNeed;
       _barHunger.fillAmount = _data._hunger._currentIndexNeed;
       _barInstincts.fillAmount = _data._instincts._currentIndexNeed;
       _scoreTotalText.text = Convert.ToString(_data._scoreTotal);

        /*if (_barNaturalNeed.fillAmount >= 1 || _barHunger.fillAmount >= 1 || _barInstincts.fillAmount >= 1)
        {
            _playerController.CatScream();
        }*/

    }

    public void addMajorProgress(float point)
    {
        Mathf.Clamp(this._majorProgress += point, 0,1);
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
