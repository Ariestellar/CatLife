using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Недоделал
public class SkillCardsLevel01 : MonoBehaviour
{
    [SerializeField] private GameObject _bot = null;
    //[SerializeField] private GameObject _catClose = null;

    [SerializeField] private GameObject _warningPanel = null;

    [SerializeField] private Skill _meow = new Skill("Мяу", 10000);
    [SerializeField] private Skill _purr = new Skill("Мрр", 20000);
    [SerializeField] private Skill _rubAgainstFeet = new Skill("Потереться о ноги", 50000);
   
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    public void EnableSkill(string nameSkill)
    {
        Skill name = null;
        switch (nameSkill)
        {
            case "Мяу":
                name = _meow;
                break;
            case "Мурр":
                name = _purr;
                break;
            case "Потереться о ноги":
                name = _rubAgainstFeet;
                break;
            default:
                break;
        }
        GetComponent<UILevel01>().addMajorProgress(name.ActionCard(_bot.GetComponent<BotLevel01>()._doNotDisturb));
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
