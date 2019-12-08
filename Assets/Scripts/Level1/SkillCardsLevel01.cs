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

    [SerializeField] private Skill _meow = new Skill("Мяу", 10000);
    [SerializeField] private Skill _purr = new Skill("Мрр", 20000);
    [SerializeField] private Skill _rubAgainstFeet = new Skill("Потереться о ноги", 50000);
   
    /*private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }*/

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
