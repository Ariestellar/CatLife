using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Недоделал
public class SkillCardsLevel01 : MonoBehaviour
{
    [SerializeField] private GameObject _bot = null;
    [SerializeField] private GameObject _scripts = null;
    [SerializeField] private GameObject _catClose = null;
    [SerializeField] private GameObject _warningPanelAnswerBar = null;
    [SerializeField] private GameObject _warningPanelAnswerBarSingle = null;

    [SerializeField] private GameObject _warningPanel = null;
    [SerializeField] private TMP_Text _warningPanelText = null;

    [SerializeField] private SaveDate _save = null;
    [SerializeField] private LoadDate _load = null;

    [SerializeField] private GameObject _meowButton = null;
    [SerializeField] private GameObject _purrButton = null;
    [SerializeField] private GameObject _rubAgainstFeetButton = null;

    [SerializeField] private Skill _meow = new Skill("Мяу", 10000);
    [SerializeField] private Skill _purr = new Skill("Мрр", 20000);
    [SerializeField] private Skill _rubAgainstFeet = new Skill("Потереться о ноги", 50000);
   
    private void Start()
    {
        _meow._usedСard = _load.UsedCard(_meow);
        _purr._usedСard = _load.UsedCard(_purr);
        _rubAgainstFeet._usedСard = _load.UsedCard(_rubAgainstFeet);

        if (_meow._usedСard == true)
        {
            _meowButton.GetComponent<Image>().color = Color.red;
        }
        if (_purr._usedСard == true)
        {
            _purrButton.GetComponent<Image>().color = Color.red;
        }
        if (_rubAgainstFeet._usedСard == true)
        {
            _rubAgainstFeetButton.GetComponent<Image>().color = Color.red;
        }

    }

    private void FixedUpdate()
    {
        _save.UsedCard(_meow);
        _save.UsedCard(_purr);
        _save.UsedCard(_rubAgainstFeet);

        

    }

    public void EnableSkill(string nameSkill)
    {
        Skill card = null;
        switch (nameSkill)
        {
            case "Мяу":
                card = _meow;
                break;
            case "Мурр":
                card = _purr;                
                break;
            case "Потереться о ноги":
                card = _rubAgainstFeet;               
                break;
            default:
                break;
        }

        if (card._usedСard == false)
        {            
            _scripts.GetComponent<UILevel01>().addMajorProgress(card.ActionCard(_bot.GetComponent<BotLevel01>()._doNotDisturb, _catClose.GetComponent<CatCloseLevel01>()._catClose));
            card.UsedCardDeActivity();
            GetComponentInChildren<Button>().GetComponent<Image>().color = Color.red;
            
        }
        else if (card._usedСard == true) 
        {
            _warningPanel.SetActive(true);
            _warningPanelText.text = $"Хотите разблокировать карту? {card._name} за {card._costCard / 4}";
            _warningPanelAnswerBar.SetActive(true);
            _warningPanelAnswerBarSingle.SetActive(false);
        }
        
    }
    //Разблокировать активность карты за очки(т.к при однократном использовании карта блокируется)
    public void BuyActivityCards(string nameSkill)
    {       
        Skill card = null;
        switch (nameSkill)
        {
            case "Мяу":
                card = _meow;                
                break;
            case "Мурр":
                card = _purr;                
                break;
            case "Потереться о ноги":
                card = _rubAgainstFeet;                
                break;
            default:
                break;
        }

        if (_scripts.GetComponent<CatIndicators>()._scoreTotal >= card._costCard / 4)
        {
            _scripts.GetComponent<CatIndicators>().ToSpendScore(card.CardActivity());
            _warningPanel.SetActive(false);
        }
        else if (_scripts.GetComponent<CatIndicators>()._scoreTotal < card._costCard / 4) 
        {
            _warningPanelText.text = "У вас нехватает котоочков(";
            _warningPanelAnswerBar.SetActive(false);
           _warningPanelAnswerBarSingle.SetActive(true);
        }
    }

    public void CloseWraningPanelNO()
    {
        _warningPanel.SetActive(false);
    }      
        

}
