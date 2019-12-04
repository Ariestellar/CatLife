using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Недоделал
public class SkillCardsLevel01 : MonoBehaviour
{
    [SerializeField] private GameObject _bot = null;
    [SerializeField] private GameObject _catClose = null;

    [SerializeField] private GameObject _warningPanel = null;

    [SerializeField] private GameObject _skillCard1 = null;
    [SerializeField] private GameObject _skillCard2 = null;
    [SerializeField] private GameObject _skillCard3 = null;

    [SerializeField] private bool _usedСardMeow = false;
    [SerializeField] private bool _usedСardPurr = false;
    [SerializeField] private bool _usedСardRubAgainstFeet = false;

    /*[SerializeField] private int _costCardMeow = 7000;
    [SerializeField] private int _costCardPurr = 15000;
    [SerializeField] private int _costCard = 10000;*/

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void Meow()
    {
        if (_usedСardMeow)
        {
            _warningPanel.SetActive(true);
        }
        else
        {
            if (_bot.GetComponent<BotLevel01>()._doNotDisturb)
            {
                GetComponent<UILevel01>().addMajorProgress(-0.1f);
            }
            else if (!_bot.GetComponent<BotLevel01>()._doNotDisturb)
            {
                GetComponent<UILevel01>().addMajorProgress(0.1f);
            }
            _usedСardMeow = true;
            _skillCard1.GetComponent<Image>().color = Color.red;
        }
        
    }
    public void Purr()
    {
        if (_usedСardPurr)
        {
            _warningPanel.SetActive(true);
        }
        else
        {
            if (!_bot.GetComponent<BotLevel01>()._doNotDisturb && _catClose.GetComponent<CatCloseLevel01>()._catClose)
            {
                GetComponent<UILevel01>().addMajorProgress(0.2f);
            }
            _usedСardPurr = true;
            _skillCard2.GetComponent<Image>().color = Color.red;
        }
    }

    public void RubAgainstFeet() 
    {
        if (_usedСardRubAgainstFeet)
        {
            _warningPanel.SetActive(true);
        }
        else
        {
            if (_bot.GetComponent<BotLevel01>()._doNotDisturb && _catClose.GetComponent<CatCloseLevel01>()._catClose)
            {
                GetComponent<UILevel01>().addMajorProgress(-0.5f);
            }
            else if (!_bot.GetComponent<BotLevel01>()._doNotDisturb && _catClose.GetComponent<CatCloseLevel01>()._catClose)
            {
                GetComponent<UILevel01>().addMajorProgress(0.5f);
            }
            _usedСardRubAgainstFeet = true;
            _skillCard3.GetComponent<Image>().color = Color.red;
        }
    }

    public void BuyCards(bool usedСard, int costCard)
    {
        usedСard = false;
        GetComponent<CatIndicators>().ToSpendScore(costCard);
    }

    public void CloseWraningPanelNO()
    {
        _warningPanel.SetActive(false);
    }      
        

}
