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

    [SerializeField] private Image _barPositiveMajorProgress = null;
    [SerializeField] private Image _barNegativeMajorProgress = null;

    [SerializeField] public float _majorProgress { get; private set; }

    [SerializeField] private LoadDate _load = null;
    [SerializeField] private SaveDate _save = null;
    [SerializeField] private GameObject _player = null;


    [SerializeField] private bool _showProgressBar = false;
    [SerializeField] private bool _showDownPanel = false;
    [SerializeField] public Animator animatorProgressBar;
    [SerializeField] public Animator animatorDownPanel;

    [SerializeField] public GameObject _tutorialPanel;
    [SerializeField] public bool _tutorialCompleted = false;

    [SerializeField] public GameObject _infoPanel1;
    [SerializeField] public GameObject _infoPanel2;

    [SerializeField] public GameObject _winPanel;

    [SerializeField] private GameObject _screamSprite = null;
    [SerializeField] private int _needTimer = 50;
    [SerializeField] private int _counter;


    private void Start()
    {        
        _data = GetComponent<CatIndicators>();
        _majorProgress = _load.MajorProgress();
        _showProgressBar =_load.StatusUIPanelsProgressBar();
        _showDownPanel = _load.StatusUIPanelsShowDownPanel();
        _tutorialCompleted = _load.TutorialPanel();        

        if (!_tutorialCompleted)
        {
            _tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (_showProgressBar)
        {
            animatorProgressBar.SetBool("isOpen", !animatorProgressBar.GetBool("isOpen"));
        }
        if (_showDownPanel)
        {
            animatorDownPanel.SetBool("isOpen", !animatorDownPanel.GetBool("isOpen"));
        }

    }

    private void FixedUpdate()
    {
        if (_majorProgress == 1)
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        _save.MajorProgress(_majorProgress);
        _save.StatusUIPanels(Convert.ToInt32(_showProgressBar), Convert.ToInt32(_showDownPanel));

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

        if (_barNaturalNeed.fillAmount >= 1 || _barHunger.fillAmount >= 1 || _barInstincts.fillAmount >= 1)
        {
            _counter += 1;
            if (_counter == _needTimer)
            {
                _majorProgress -= 0.1f;
                _screamSprite.SetActive(true);
                _player.GetComponent<PlayerControllerLevel01>().CatScream();
                _counter = 0;
            }            
        }

    }

    public void addMajorProgress(float point)
    {        
        this._majorProgress = Mathf.Clamp(this._majorProgress += point, -1,1);
    }
    //Кнопки на сцене
    public void ShowProgressBar(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
        _showProgressBar = !_showProgressBar;
    }
    public void ShowDownPanel(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
        _showDownPanel = !_showDownPanel;
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
    public void GoToTheToilet()
    {
        GetComponent<CatIndicators>()._natural.FillTheNeed();
    }
    public void ExitLevel(string LevelLabel)
    {
        SceneManager.LoadScene(LevelLabel);
    }
    public void ShowTutorialPanel()
    {
        _tutorialPanel.SetActive(false);
        _tutorialCompleted = true;
        _save.TutorialPanel(Convert.ToInt32(_tutorialCompleted));
        Time.timeScale = 1;
    }
    public void ShowInfoPanel(int number)
    {
        if (number == 1) 
        {
            _infoPanel1.SetActive(true);
        }
        else if (number == 2)
        {
            _infoPanel1.SetActive(false);
            _infoPanel2.SetActive(true);
        }
        else if (number == 3)
        {
            _infoPanel2.SetActive(false);            
        }

    }

    public void OkWinPanel()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
    }
}
